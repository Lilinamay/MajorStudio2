using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyBehavior : MonoBehaviour
{
    [SerializeField] GameObject box;
    public List<GameObject> heart;
    public List<float> waitTime;
    public List<float> dialogueLength;
    public float Timer = 0;
    public static GameObject currentHeart;
    public int i = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer <= 0)
        {
            //boy attack animation
            heartAttack();
        }
        else
        {
            Timer -= Time.deltaTime;
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
}
