using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private bool playerFell = false;

    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, 0.0f, this.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager player = other.gameObject.GetComponent<PlayerManager>();
            if (player != null)
            {
                Debug.Log("Player Fell");
                playerFell = true;
            }
        }
    }

    public bool playerFallen()
    {
        if (playerFell)
        {
            playerFell = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void reset()
    {
        playerFell = false;
    }



}
