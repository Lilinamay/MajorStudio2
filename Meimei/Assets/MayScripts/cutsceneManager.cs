using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class cutsceneManager : MonoBehaviour
{
    private Touch t;
    public int s=1;
    public List<GameObject> imgs;
    public Tweener currentTween;
    public Tweener currentTween2;
    public Tweener currentTween3;
    public Tweener currentTween4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                switch (s)
                {
                    case 1:     //move girl1
                        //imgs[0].transform.DOMoveY(-1.17, 0.5f);
                        imgs[0].SetActive(true);
                        currentTween=imgs[0].transform.DOMoveY(-1.17f, 0.5f).OnComplete(() =>
                        {
                            s = 3;
                        });
                        s++;
                        break;
                    case 2:     
                        currentTween.Goto(0.5f);    //GO to complete time
                        s++;
                        break;
                    case 3:     //move boy1
                        imgs[1].SetActive(true);
                        currentTween = imgs[1].transform.DOMoveY(-0.86f, 0.5f).OnComplete(() =>
                        {
                            s = 5;
                        });
                        s++;
                        break;
                    case 4:
                        currentTween.Goto(0.5f);    //GO to complete time
                        s++;
                        break;
                    case 5:     //move boy girl2
                        imgs[3].SetActive(true);
                        imgs[2].SetActive(true);
                        imgs[4].SetActive(true);
                        imgs[5].SetActive(true);
                        currentTween = imgs[2].transform.DOMoveX(3.3f, 0.8f).OnComplete(() =>
                        {
                            imgs[6].SetActive(true);
                            imgs[7].SetActive(true);
                            s = 7;
                        });
                        currentTween2 = imgs[3].transform.DOMoveX(2.83f, 0.8f);
                        currentTween3 = imgs[4].transform.DOScale(0.85f, 0.6f);
                        currentTween4 = imgs[4].transform.DOMoveY(-0.88f, 0.6f);
                        s++;
                        break;
                    case 6:
                        currentTween.Goto(0.8f);    //GO to complete time
                        currentTween2.Goto(0.8f);    //GO to complete time
                        currentTween3.Goto(0.8f);    //GO to complete time
                        currentTween4.Goto(0.8f);    //GO to complete time
                        s++;
                        break;
                    case 7:
                        imgs[8].SetActive(true);
                        currentTween = imgs[8].transform.DOScale(1.12f, 0.5f).OnComplete(() =>
                        {
                            s = 9;
                        });
                        s++;
                        break;
                    case 8:
                        currentTween.Goto(0.5f);    //GO to complete time
                        s++;
                        break;
                }
            }
        }
    }
}
