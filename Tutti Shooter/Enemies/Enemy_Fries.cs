using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fries : Enemy
{
    public GameObject deathBullet;
    private Quaternion deathRotation1;
    private Quaternion deathRotation2;
    private Quaternion deathRotation3;

    void OnEnable()
    {
        deathRotation1 = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        deathRotation2 = Quaternion.Euler(0.0f, 0.0f, 225.0f);
        deathRotation3 = Quaternion.Euler(0.0f, 0.0f, 135.0f);
    }

    public override void DeathRattle()
    {
        Instantiate(deathBullet, transform.position, deathRotation1);
        Instantiate(deathBullet, transform.position, deathRotation2);
        Instantiate(deathBullet, transform.position, deathRotation3);
        Destroy(gameObject);
    }

}
