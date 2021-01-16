using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ICollidable collided = other.GetComponent<ICollidable>();
        Player_Movement player = other.GetComponent<Player_Movement>();
        if (collided != null)
        {
            collided.Collide(2);
            if (player != null)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            return;
        }

        
    }
}
