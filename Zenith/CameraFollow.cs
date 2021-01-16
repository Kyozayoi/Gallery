using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(0.0f, 10.0f, -14.0f);
    private float smoothSpeed = 120.0f;
    
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 nextLocation = new Vector3(player.transform.position.x, offset.y, player.transform.position.z + offset.z);
        Vector3 smoothNext = Vector3.Lerp(transform.position, nextLocation, smoothSpeed * Time.deltaTime);
        transform.position = smoothNext;

        //transform.LookAt(player);
    }
    

}
