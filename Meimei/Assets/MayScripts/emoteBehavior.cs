using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class emoteBehavior : MonoBehaviour
{
    float speed = 7;
    public int Damage;
    Image myH;
    Vector2 pos;
    public bool isheart = false;
    public int hit = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        myH = GetComponent<Image>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (myH.enabled)
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0);
        }
        else
        {
            transform.position = pos;
            isheart = false;
        }
        if (isheart)
        {
            Damage = 15;
            
        }
        else
        {
            Damage = 10;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if (collision.name == "Friend")
        {
            hit = 0;
            Player1Update.heartMove = false;
            Player1Update.girlHP -= Damage;
            Audiomanager.Instance.PlaySound(Audiomanager.Instance.girlHurt, Audiomanager.Instance.girlHurtVolume);
            //gameObject.SetActive(false);
            myH.enabled = false;
            transform.position = pos;
            //StartCoroutine(HitAfter());
        }
    }
}
