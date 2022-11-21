using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    int c = 0;
    float ct = 0;
    // Start is called before the first frame update
    void Start()
    {
        rank.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        HPbar();
        //x = this.transform.position.x - BoyBehavior.currentHeart.transform.position.x;
        if (Input.touchCount > 0)
        {
            t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                if (BoyBehavior.currentHeart != null)
                {
                    if (BoyBehavior.currentHeart.activeSelf == true)
                    {
                        x = this.transform.position.x - BoyBehavior.currentHeart.transform.position.x;
                        if (BoyBehavior.currentHeart.tag == "heart")
                        {
                            //player attack 1 animation
                            Debug.Log(x);
                            if (x <= 1.3f && x > 0.5f)
                            {
                                
                                Debug.Log("perfect!");
                                textTimer = 1.5f;
                                rank.text = "perfect";
                                BoyBehavior.currentHeart.SetActive(false);
                                boyHP -= 15;
                            }
                            else if (x <= 1.9f && x > 1.3f)
                            {
                                Debug.Log("ok");
                                textTimer = 1.5f;
                                rank.text = "ok";
                                BoyBehavior.currentHeart.SetActive(false);
                                boyHP -= 5;
                            }
                        }else if(BoyBehavior.currentHeart.tag == "heartB")
                        {
                            c++;
                            if (x <= 1.9f && x > 0.5f)
                            {
                                ct += x;
                                if (c == 2)
                                {
                                    //player attack part 2
                                    if (ct <= 2.6)
                                    {
                                        Debug.Log("big perfect!");
                                        textTimer = 1.5f;
                                        rank.text = "perfect";
                                        BoyBehavior.currentHeart.SetActive(false);
                                        boyHP -= 20;
                                    }
                                    else if (ct<=3.5)
                                    {
                                        textTimer = 1.5f;
                                        Debug.Log("big ok");
                                        rank.text = "ok";
                                        BoyBehavior.currentHeart.SetActive(false);
                                        boyHP -= 10;
                                    }
                                    c = 0;
                                    ct = 0;
                                }
                                else
                                {
                                    //player attack 1
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
}
