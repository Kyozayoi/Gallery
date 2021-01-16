using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Curved : MonoBehaviour, ICollidable
{
    public float moveSpeed;
    public float frequency;
    public float magnitude;
    Vector3 pos;

    public int right_left;

    public int hits;

    public int damage;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        pos += transform.up * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.right * Mathf.Sin(Time.time * frequency) * magnitude * right_left;
    }

    public void adjustDirection(int input)
    {
        right_left = input;
    }

    public void adjustHits(int input)
    {
        hits = input;
    }

    public void Collide(int collided)
    {
        switch (collided)
        {
            case 0:
                hits--;
                if (hits == 0)
                {
                    Destroy(gameObject);
                }
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
