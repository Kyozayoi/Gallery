using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Boomerang : MonoBehaviour, ICollidable
{
    private Vector3 playerLocation;
    private Vector3 startLocation;
    public float counter;

    public float speed;
    public float width;
    public float height;

    public int hits;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        startLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime * speed;

        if (counter > 3.5f)
        {
            GameObject findPlayer = GameObject.FindWithTag("Player");
            Player_Movement player = findPlayer.GetComponent<Player_Movement>();
            playerLocation = player.transform.position;
            float x2 = playerLocation.x - transform.position.x;
            float y2 = playerLocation.y - transform.position.y;

            transform.position += new Vector3(x2, y2, 0.0f).normalized;

            if (transform.position.y > playerLocation.y - .5 &&
                transform.position.y < playerLocation.y + .5 &&
                transform.position.x > playerLocation.x - .5 &&
                transform.position.x < playerLocation.x + .5)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            float x1 = Mathf.Cos(counter) * width;
            float y1 = Mathf.Sin(counter) * height;
            float z1 = 0;

            transform.position = new Vector3(x1 + startLocation.x, y1 + height + startLocation.y, z1);
        }
    }

    public void adjustHeight(int input)
    {
        height = input;
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
                if(hits == 0)
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
