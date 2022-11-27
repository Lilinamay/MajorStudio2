using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 3;
    public int Damage;
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
        Debug.Log("trigger");
        if (collision.name == "Friend")
        {
            Player1.girlHP -= Damage;
            gameObject.SetActive(false);
            
        }
    }
}
