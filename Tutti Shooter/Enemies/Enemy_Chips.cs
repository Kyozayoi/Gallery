using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chips : Enemy
{
    public GameObject deathBullet;

    private Quaternion deathRotation1;
    private Quaternion deathRotation2;
    private Quaternion deathRotation3;
    private Quaternion deathRotation4;
    private Quaternion deathRotation5;
    private Quaternion deathRotation6;
    private Quaternion deathRotation7;
    private Quaternion deathRotation8;

    void OnEnable()
    {
        deathRotation1 = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        deathRotation2 = Quaternion.Euler(0.0f, 0.0f, 45.0f);
        deathRotation3 = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        deathRotation4 = Quaternion.Euler(0.0f, 0.0f, 135.0f);
        deathRotation5 = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        deathRotation6 = Quaternion.Euler(0.0f, 0.0f, 225.0f);
        deathRotation7 = Quaternion.Euler(0.0f, 0.0f, 270.0f);
        deathRotation8 = Quaternion.Euler(0.0f, 0.0f, 315.0f);
    }

    public override void DeathRattle()
    {
        Instantiate(deathBullet, transform.position, deathRotation1);
        Instantiate(deathBullet, transform.position, deathRotation2);
        Instantiate(deathBullet, transform.position, deathRotation3);
        Instantiate(deathBullet, transform.position, deathRotation4);
        Instantiate(deathBullet, transform.position, deathRotation5);
        Instantiate(deathBullet, transform.position, deathRotation6);
        Instantiate(deathBullet, transform.position, deathRotation7);
        Instantiate(deathBullet, transform.position, deathRotation8);
        Destroy(gameObject);
    }

   
}
