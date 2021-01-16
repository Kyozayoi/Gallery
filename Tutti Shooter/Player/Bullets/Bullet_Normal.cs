using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Normal : MonoBehaviour, ICollidable
{
    public float speed;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * speed;
    }
    public void Collide(int collided)
    {
        switch (collided)
        {
            case 0:
                Destroy(gameObject);
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }

    public int Damage()
    {
        return damage;
    }
}
