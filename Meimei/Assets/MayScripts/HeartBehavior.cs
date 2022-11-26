using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(speed*Time.deltaTime, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("trigger");
        if (collision.name == "friend")
        {
            gameObject.SetActive(false);
            Player1.girlHP -= 20;
        }
    }
}
