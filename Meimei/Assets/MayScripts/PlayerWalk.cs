using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerWalk : MonoBehaviour
{
    private Touch t;
    public float speed = 0;
    bool down = false;
    public static bool camTrigger = false;
    private Animator animator;
    public Tweener currentTween;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
                if (currentTween != null)
                {
                    currentTween.Kill();
                }
                if (Camera.main.ScreenToWorldPoint(t.position).x <= this.transform.position.x)
                {
                    //start walk animation
                    animator.SetBool("walk", true);
                    speed = 2;

                }
            }
            else if (t.phase == TouchPhase.Ended)
            {
                down = true;
                currentTween=DOTween.To(() => speed, x => speed = x, 0, 1).SetEase(Ease.InQuart).OnComplete(() =>
                {
                    //stop animation
                    animator.SetBool("walk", false);
                    Debug.Log("finished");
                    currentTween = null;
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
