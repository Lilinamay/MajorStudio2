using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoyBehavior : MonoBehaviour
{
    [SerializeField] GameObject box;
    public List<GameObject> heart;
    public List<float> waitTime;
    public List<float> dialogueLength;
    public float Timer = 0;
    public static GameObject currentHeart;
    public int i = -1;
    public GameObject chatObject;
    bool attack = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        chatObject.GetComponent<chatBox>().disableEmote();
        animator = GetComponent<Animator>();
        //chatBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1Update.cgTimer <= 0)
        {
            if (Timer <= 0 )
            {
                Timer = 10f;     //time until next attack
                //boy attack animation
                //heartAttack();
                //BoxAttack();
                int x = Random.Range(0, 2);
                if (x == 0)
                {
                    animator.SetTrigger("attack");
                }
                if (x == 1)
                {
                    animator.SetTrigger("attack2");
                }
                

                chatObject.SetActive(true);
                chatObject.GetComponent<chatBox>().chatInit();
                //attack = true;
                
                Debug.Log("ENABLE CHATBOX");
            }
            else
            {
                Timer -= Time.deltaTime;
            }
        }
    }
    
    void heartAttack()
    {
        if (i < heart.Count-1)
        {
            i++;
            heart[i].SetActive(true);
            currentHeart = heart[i];
            Timer = waitTime[i];
        }
    }

    void BoxAttack()
    {
        //chatBox.enabled = true;
    }
}
