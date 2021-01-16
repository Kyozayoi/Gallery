using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Burger : Enemy
{
    public GameObject deathBullet;
    private Quaternion deathRotation1;

    void OnEnable()
    {
        deathRotation1 = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        
    }

    public override void DeathRattle()
    {
        deathBullet.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
        Instantiate(deathBullet, transform.position, deathRotation1);
        deathBullet.transform.localScale = new Vector3(1.0f, 1.0f, 2.0f);
        Destroy(gameObject);
    }

}
