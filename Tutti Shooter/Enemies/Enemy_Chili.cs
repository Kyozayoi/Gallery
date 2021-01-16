using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chili : MonoBehaviour
{
    private Player_Movement player;

    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * speed;

        GameObject findPlayer = GameObject.FindWithTag("Player");
        player = findPlayer.GetComponent<Player_Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ICollidable collided = other.GetComponent<ICollidable>();
        if (collided != null)
        {
            collided.Collide(4);
        }
        else
        {
            return;
        }
    }

}
