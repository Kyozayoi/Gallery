using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager player = other.gameObject.GetComponent<PlayerManager>();
            if (player != null)
            {
                Destroy(gameObject);
            }
        }
    }
}