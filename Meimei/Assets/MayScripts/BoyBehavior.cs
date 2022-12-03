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
    // Start is called before the first frame update
    void Start()
    {
        chatObject.GetComponent<chatBox>().disableEmote();
        //chatBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1Update.cgTimer <= 0)
        {
            if (Timer <= 0 )
            {
                //boy attack animation
                //heartAttack();
                //BoxAttack();
                chatObject.SetActive(true);
                chatObject.GetComponent<chatBox>().chatInit();
                //attack = true;
                Timer = 10;
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
