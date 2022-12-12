using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerWalk : MonoBehaviour
{
    private Touch t;
    public float speed = 0;
    bool down = false;
    public static bool camTrigger = false;
    private Animator animator;
    public Animator Ganimator;
    public Tweener currentTween;
    bool boyed = false;
    public GameObject boy;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!boyed)
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
                        Ganimator.SetBool("walk", true);
                        speed = 2;

                    }
                }
                else if (t.phase == TouchPhase.Ended)
                {
                    down = true;
                    currentTween = DOTween.To(() => speed, x => speed = x, 0, 1).SetEase(Ease.InQuart).OnComplete(() =>
                      {
                          //stop animation
                          animator.SetBool("walk", false);
                          Ganimator.SetBool("walk", false);
                          Debug.Log("finished");
                          currentTween = null;
                      });
                }
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
        if (collision.name == "camTrigger")
        {
            Debug.Log("triggered");
            camTrigger = true;
        }
        if (collision.name == "boyTrigger")
        {
            Debug.Log("triggered");
            boyed = true;
            animator.SetBool("walk", false);
            Ganimator.SetBool("walk", false);
            StartCoroutine(Boys());
        }
    }

    IEnumerator Boys()
    {
        yield return new WaitForSeconds(0.1f);
        boy.transform.DOJump(new Vector3(-14.4F, -1.17F, 0), 0.5F, 1, 0.5F).OnComplete(() =>
        {
            boy.GetComponent<Animator>().SetTrigger("attack2");
            StartCoroutine(trans());

        });

    }

    IEnumerator trans()
    {
        yield return new WaitForSeconds(1.5f);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
