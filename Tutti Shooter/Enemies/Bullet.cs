using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private void OnTriggerEnter(Collider other)
    {
        ICollidable collided = other.GetComponent<ICollidable>();
        if (collided != null)
        {
            collided.Collide(1);
        }
        else
        {
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * speed;
    }

}
