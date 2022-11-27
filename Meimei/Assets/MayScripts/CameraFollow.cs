using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector3 cameraOffset=new Vector3(9,-3);
    public float cameraSpeed = 0.5f;
    void Start()
    {
        //.position = player.position + cameraOffset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (PlayerWalk.camTrigger)
        {
            Vector3 finalPosition = player.position + cameraOffset;
            Vector3 lerpPosition = Vector3.Lerp(transform.position, finalPosition, cameraSpeed);
            transform.position = new Vector3(lerpPosition.x, transform.position.y, -10);
        }
    }
}
