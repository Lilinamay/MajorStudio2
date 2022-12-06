using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class flyingEmoteChat : MonoBehaviour
{
    public Image box;
    float value = 0f;
    float init = 5f;
    public List<Image> emoteImage;
    float speed = 5f;
    public static float perfectTime;
    public static bool heart = false;
    public List<Sprite> emotes;
    bool ok = false;
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

            if (value >= 3.4f)
            {
                if (emoteImage[0].enabled == false)
                {
                    emoteImage[0].enabled = true;
                }
                value -= Time.deltaTime * speed;
                Debug.Log(emoteImage[0].gameObject);
                emoteImage[0].gameObject.transform.position += new Vector3(1, 0, 0) * Time.deltaTime;

                //Debug.Log(emoteImage[0]);
            }
            box.rectTransform.offsetMax = new Vector2(-value, box.rectTransform.offsetMax.y);
        }




    }

    public void chatInit()
    {
        for (int i = 0; i < emoteImage.Count - 1; i++)
        {
            int x = Random.Range(0, emotes.Count);
            emoteImage[i].sprite = emotes[x];
        }
        box.rectTransform.offsetMax = new Vector2(-3.8f, box.rectTransform.offsetMax.y);
        //value = init;
        //box.rectTransform.sizeDelta = new Vector3(0, 0, 0);
        box.rectTransform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 0f);
        box.rectTransform.DOScale(new Vector3(1, 1, 1), 0.4f).OnComplete(() =>
        {
            //value = init;
            ok = true;
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
