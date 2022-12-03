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
    // Start is called before the first frame update
    void Start()
    {
        foreach(Image i in emoteImage)
        {
            i.enabled = false;
            Debug.Log(i);
        }
        chatInit();
    }

    // Update is called once per frame
    void Update()
    {
        
        //box.rectTransform.right += new Vector3 (0,Time.deltaTime,0);
        //Resize(1, new Vector3(0.01f, 0, 0));
        if (value >= 0.09f)
        {
            value -= Time.deltaTime;
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
            }
            box.rectTransform.offsetMax = new Vector2(-value, box.rectTransform.offsetMax.y);
        }
        


    }

    public void chatInit()
    {
        box.rectTransform.offsetMax = new Vector2(-init, box.rectTransform.offsetMax.y);
        //value = init;
        //box.rectTransform.sizeDelta = new Vector3(0, 0, 0);
        box.rectTransform.DOScale(new Vector3(0.2f, 0.2f, 0.2f), 0f);
        box.rectTransform.DOScale(new Vector3(1, 1, 1), 0.7f).OnComplete(() =>
        {
            value = init;
        });
    }

    void valuechange()
    {
        
    }


}
