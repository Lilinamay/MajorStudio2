using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class emoteBehavior : MonoBehaviour
{
    float speed = 7;
    public int Damage;
    Image myH;
    Vector2 pos;
    public bool isheart = false;
    public int hit = 3;
    public Sprite[] HeartBREAK;
    public int index = 0;
    float waitTimer = 3;
    bool play = false;
    
    // Start is called before the first frame update
    void Start()
    {
        myH = GetComponent<Image>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (myH.enabled)
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0);
        }
        else
        {
            transform.position = pos;
            isheart = false;
        }
        if (isheart)
        {
            Damage = 10;
            
        }
        else
        {
            Damage = 5;
        }
        if(hit ==1 && index<2 &&isheart)
        {
            myH.sprite = HeartBREAK[index];
            //Debug.Log("INDEX" + index);
            if (!play)
            {
                waitTimer = 0.1f;
                play = true;
            }
            if (waitTimer > 0)
            {
                waitTimer -= Time.deltaTime;
            }
            else
            {
                index++;
            }
        }
        if (hit == 0 && index < 4 && isheart)
        {
            myH.sprite = HeartBREAK[index];
            //Debug.Log("INDEX" + index);
            if (play)
            {
                waitTimer = 0.1f;
                play = false;
            }
            if (waitTimer > 0)
            {
                waitTimer -= Time.deltaTime;
            }
            else
            {
                index++;
            }
        }
        if (hit == 0 && index >= 4 && isheart)
        {
            myH.enabled = false;
            transform.position = pos;
            play = false;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if (collision.name == "Friend")
        {
            hit = 0;
            Player1Update.heartMove = false;
            Player1Update.girlHP -= Damage;
            Audiomanager.Instance.PlaySound(Audiomanager.Instance.girlHurt, Audiomanager.Instance.girlHurtVolume);
            //gameObject.SetActive(false);
            myH.enabled = false;
            transform.position = pos;
            //StartCoroutine(HitAfter());
        }
    }

}
