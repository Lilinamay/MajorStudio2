using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeartBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 5;
    public int Damage;
    Image myH;
    Vector2 pos;
    public chatBox chat;
    void Start()
    {
        myH = GetComponent<Image>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1Update.heartMove)
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger");
        if (collision.name == "Friend")
        {

            Player1Update.heartMove = false;
            Player1Update.girlHP -= Damage;
            //gameObject.SetActive(false);
            myH.enabled = false;
            transform.position = pos;
            StartCoroutine(HitAfter());
        }
    }

    IEnumerator HitAfter()
    {
        yield return new WaitForSeconds(0.9f);
        chat.disableEmote();
    }
}
