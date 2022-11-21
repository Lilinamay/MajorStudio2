using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerWalk : MonoBehaviour
{
    private Touch t;
    float speed = 0;
    bool down = false;
    public static bool camTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(speed * Time.deltaTime, 0);
        if (Input.touchCount > 0)
        {
            t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                if (Camera.main.ScreenToWorldPoint(t.position).x <= this.transform.position.x)
                {
                    //start walk animation
                    speed = 2;
                }
            }
            else if (t.phase == TouchPhase.Ended)
            {
                down = true;
                DOTween.To(() => speed, x => speed = x, 0, 1).SetEase(Ease.InQuart).OnComplete(() =>
                {
                    //stop animation
                    Debug.Log("finished");
                });
            }
        }

        //if (down)
        //{
        //    if (speed > 0)
        //    {
        //        speed -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        down = false;
        //    }
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name== "camTrigger")
        {
            Debug.Log("triggered");
            camTrigger = true;
        }
    }
}
