using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TitleScene : MonoBehaviour
{
    private Touch t;
    public int s = 1;
    public List<Image> imgs;
    public Sprite broken;
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
                    case 1:     
                        
                        
                        
                        currentTween = imgs[0].rectTransform.DOLocalMoveY(-114, 1f).OnComplete(() =>
                        {
                            s = 3;
                        });
                        s++;
                        Debug.Log("FIRST");
                        break;
                    case 2:
                        currentTween.Goto(1f);    //GO to complete time
                        Debug.Log("UNFINISHED CLICK1");
                        //s++;
                        break;
                    case 3:     //move boy1
                        //imgs[1].SetActive(true);
                        
                        Debug.Log("CLICK BOY");
                        currentTween2 = imgs[1].DOFade(1, 0.5f).OnComplete(() =>
                        {
                            s = 5;
                        });
                        s++;
                        break;
                    case 4:
                        currentTween2.Goto(0.5f);    //GO to complete time
                        Debug.Log("UNFINISHED BOY");
                        //s++;
                        break;
                    case 5:     //move boy girl2
                        Debug.Log("3 SCENE");
                        currentTween3 = imgs[2].DOFade(1, 0.5f).OnComplete(() =>
                        {
                            s = 7;
                        });
                        s++;
                        break;
                    case 6:
                        Debug.Log("3 SCENE unfinished");
                        currentTween3.Goto(0.5f);    //GO to complete time

                        //s++;
                        break;
                    case 7:
                        imgs[0].rectTransform.DOLocalMoveY(-125, 0.5f);
                        imgs[1].rectTransform.DOLocalMoveY(-125, 0.5f);
                        imgs[2].rectTransform.DOLocalMoveY(-125, 0.5f);
                        imgs[4].rectTransform.DOLocalMoveY(91, 0.5f);
                        currentTween4 = imgs[3].DOFade(1, 0.7f).OnComplete(() =>
                        {
                            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                            if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
                            {
                                SceneManager.LoadScene(nextSceneIndex);
                            }
                            
                        });


                        break;
                    
                }
            }
        }
    }
}

