using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Player1 : MonoBehaviour
{
    private Touch t;
    public float x;
    public static float boyHP=100;
    public static float girlHP=100;
    [SerializeField] Image boy;
    [SerializeField] Image girl;
    [SerializeField] TMP_Text rank;
    float textTimer = 0;
    float hitTimer = 0;
    int c = 0;
    float ct = 0;
    Animator animator;
    int hit= 0;
    int hitHealth = 0;
    
    public static float cgTimer = 5; //the amount of time for cutscene before accepting player input
    // Start is called before the first frame update
    void Start()
    {
        rank.text = "";
        animator = GetComponent<Animator>();
        //play power up animation from start or in update if(cgTimer = 3....etc) play animation
    }

    // Update is called once per frame
    void Update()
    {
        HPbar();
        HitTimer();
        //x = this.transform.position.x - BoyBehavior.currentHeart.transform.position.x;
        if (cgTimer >= 0)
        {
            cgTimer -= Time.deltaTime;
        }
        if (Input.touchCount > 0 && cgTimer<0)
        {
            t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                Vector3 wp = Camera.main.ScreenToWorldPoint(t.position);
                Vector2 touchPos = new Vector2(wp.x, wp.y);
                Collider2D hit = Physics2D.OverlapPoint(touchPos);
                if (hit && hit == gameObject.GetComponent<Collider2D>())
                {
                    animator.SetTrigger("attack1");
                    if (BoyBehavior.currentHeart != null)
                    {
                        if (BoyBehavior.currentHeart.activeSelf == true)
                        {
                            x = this.transform.position.x - BoyBehavior.currentHeart.transform.position.x;
                            if (BoyBehavior.currentHeart.tag == "heart")
                            {
                                //player attack 1 animation
                                animator.SetTrigger("attack1");
                                Debug.Log(x);
                                if (x <= 2.6f && x > 1.6f)
                                {
                                    HitSet(2, 15);
                                    //PerfectHit();
                                    Debug.Log("perfect!");

                                }
                                else if (x <= 3.1f && x > 2.6)
                                {
                                    HitSet(1, 5);
                                    Debug.Log("ok");
                                }
                            }
                            else if (BoyBehavior.currentHeart.tag == "heartB")
                            {
                                c++;
                                if (x <= 3.1f && x > 1.6f)
                                {
                                    ct += x;
                                    if (c == 2)
                                    {
                                        //player attack part 2
                                        Debug.Log("big attack: " + ct);
                                        animator.SetTrigger("attack1");
                                        if (ct <= 4.8)
                                        {
                                            HitSet(2, 20);
                                            Debug.Log("big perfect!");
                                        }
                                        else if (ct <= 5.6)
                                        {
                                            HitSet(1, 10);
                                            Debug.Log("big ok!");
                                        }
                                        c = 0;
                                        ct = 0;
                                    }
                                    else
                                    {
                                        //player attack 1
                                        animator.SetTrigger("attack1");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    void HPbar()
    {
        boy.fillAmount = boyHP / 100;
        girl.fillAmount = girlHP / 100;
        if(textTimer > 0)
        {
            textTimer -= Time.deltaTime;
        }
        else
        {
            rank.text = "";
        }
    }
    void HitTimer()
    {
        if (hitTimer > 0)
        {
            hitTimer -= Time.deltaTime;
        }
        else
        {
            if (hit>0)
            {
                StartCoroutine(HitAfter());
                if (hit == 2)
                {
                    StartCoroutine(HitPerfAfter());
                    rank.text = "perfect";
                    Time.timeScale = 0.4f;
                    
                }else if(hit == 1)
                {
                    rank.text = "OK";
                }
                boyHP -= hitHealth;
                textTimer = 1.5f;
                BoyBehavior.currentHeart.SetActive(false);
                
                hit = 0;
                hitHealth = 0;
                Debug.Log("onHit");
                
            }
        }
    }

    IEnumerator HitAfter()
    {
        yield return new WaitForSeconds(0.1f);
        if (hit == 2)
        {
            DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1, 0.2f).SetEase(Ease.InQuart);  //if perfect hit
        }
        Camera.main.DOOrthoSize(5f, 0.2f).SetEase(Ease.InQuart);
    }
    IEnumerator HitPerfAfter()
    {
        yield return new WaitForSeconds(0.1f);
        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1, 0.2f).SetEase(Ease.InQuart);  //if perfect hit
    }
    void HitSet(int h,int health)
    {
        Debug.Log("origin size" + Camera.main.orthographicSize);
        hit = h;
        hitTimer = 0.4f;
        hitHealth = health;
        Camera.main.DOOrthoSize(4.8f,0.39f).SetEase(Ease.InQuart);
        //Debug.Log("after size" + Camera.main.orthographicSize);
    }

}
