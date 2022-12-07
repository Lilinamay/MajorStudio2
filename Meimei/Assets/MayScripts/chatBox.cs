using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class chatBox : MonoBehaviour
{
    public Image box;
    float value = 0f;
    float init = 5f;
    public List<Image> emoteImage;
    float speed = 5f;
    float chatMoveSpeed = 4f;
    public static float perfectTime;
    public static bool  heart= false;
    public List<Sprite> emotes;
    [System.Serializable]
    public class serializableClass
    {
        public List<bool> ifheart;
    }
    public List<serializableClass> attacks = new List<serializableClass>();
    public int hello = 0;
    bool ok = false;
    int i = -1;
    float spawnTimer = 0;
    public float spawnTimerEnter = 1f;
    [SerializeField] Sprite heartSprite;
    int currentAttack = -1;
    // Start is called before the first frame update
    void Start()
    {

        //disableEmote();
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        /*if (value >= 0.09f)
        {
            value -= Time.deltaTime*speed;
            if (value <= 4.5f && emoteImage[0].enabled == false)
            {
                emoteImage[0].enabled = true;
                Debug.Log(emoteImage[0]);
            }
            if (value <= 3.4f && emoteImage[1].enabled == false)
            {
                emoteImage[1].enabled = true;
            }
            if (value <= 2.3f && emoteImage[2].enabled == false)
            {
                emoteImage[2].enabled = true;
            }
            if (value <= 1.2f && emoteImage[3].enabled == false)
            {
                emoteImage[3].enabled = true;
            }
            if (value <= 0.1f && emoteImage[4].enabled == false)
            {
                emoteImage[4].enabled = true;
                heart = true;
            }
            box.rectTransform.offsetMax = new Vector2(-value, box.rectTransform.offsetMax.y);
        }
        calculateScore();
        */
        //if (value >= 3.4f)
        {
            
            if (ok&& currentAttack<attacks.Count)
            {
                if (spawnTimer > 0)
                {
                    spawnTimer -= Time.deltaTime;
                    
                }
                if (spawnTimer <= 0)
                {
                    i++;
                    {
                        if (attacks[currentAttack].ifheart[i])      //ifis heart
                        {
                            emoteImage[i].sprite = heartSprite;
                            emoteImage[i].GetComponent<emoteBehavior>().isheart = true;
                            emoteImage[i].GetComponent<emoteBehavior>().hit = 2;
                        }
                        else
                        {
                            emoteImage[i].GetComponent<emoteBehavior>().hit = 1;
                        }
                        emoteImage[i].enabled = true;
                        if (i + 1 < attacks[currentAttack].ifheart.Count)
                        {
                            spawnTimer = spawnTimerEnter;
                        }
                        else
                        {
                            ok = false;
                        }
                    }
                    
                }
                //if(emoteImage[0].enabled == false)
                //{
                 //   emoteImage[0].enabled = true;
//}
                //value -= Time.deltaTime * speed;
                //Debug.Log(emoteImage[0].gameObject);
                //emoteImage[0].gameObject.transform.position += new Vector3(1, 0, 0)*Time.deltaTime* chatMoveSpeed;
                //Debug.Log(emoteImage[0]);
            }
            //box.rectTransform.offsetMax = new Vector2(-value, box.rectTransform.offsetMax.y);
        }




    }

    public void chatInit()
    {
        for(int i =0; i<emoteImage.Count;i++)
        {
            int x = Random.Range(0, emotes.Count);
            emoteImage[i].sprite=emotes[x];
        }
        //box.rectTransform.offsetMax = new Vector2(-3.8f, box.rectTransform.offsetMax.y);
        //value = init;
        //box.rectTransform.sizeDelta = new Vector3(0, 0, 0);
        box.rectTransform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 0f);
        box.rectTransform.DOScale(new Vector3(1, 1, 1), 0.4f).OnComplete(() =>
        {
            ok = true;
            i = -1;
            spawnTimer = 0;
            currentAttack++;
        });

    }

    public void disableEmote()
    {
        foreach (Image i in emoteImage)
        {
            i.enabled = false;
        }
        gameObject.SetActive(false);
    }

    public void calculateScore()
    {
        if (heart)
        {
            perfectTime += Time.deltaTime;//bug hit heart continue stopo hit
        }
        else
        {
            if (perfectTime != 0)
            {
                perfectTime = 0;
            }
        }
    }


}
