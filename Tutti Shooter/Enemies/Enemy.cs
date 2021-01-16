using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private Player_Movement player;

    public float rotation;
    public float speed;
    public int addScore;

    public int health;

    public GameObject explosion;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * rotation;
        GetComponent<Rigidbody>().velocity = transform.up * speed;

        GameObject findPlayer = GameObject.FindWithTag("Player");
        player = findPlayer.GetComponent<Player_Movement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ICollidable collided = other.GetComponent<ICollidable>();
        if (collided != null)
        {
            health -= collided.Damage();
            collided.Collide(0);
            if(health <= 0)
            {
                player.UpdateScore(addScore);
                Instantiate(explosion, transform.position, transform.rotation);
                DeathRattle();
            }
        }
        else
        {
            return;
        }
    }

    public abstract void DeathRattle();

    public Player_Movement thisPlayer()
    {
        return player;
    }


}
