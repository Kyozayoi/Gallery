using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Chicken : Enemy
{
    public GameObject deathBullet;
    private Quaternion deathRotation1;

    void OnEnable()
    {
        deathRotation1 = Quaternion.Euler(0.0f, 0.0f, 180.0f);
    }

    public override void DeathRattle()
    {
        Instantiate(deathBullet, transform.position, deathRotation1);
        Destroy(gameObject);
    }

}
