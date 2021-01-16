using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form_Banana : Form
{
    private Vector3 level1Spawn;

    private Bullet_Boomerang thisBullet;


    private void OnEnable()
    {
        level1Spawn = new Vector3(0.5f, 1.0f, 0.0f);

        thisBullet = mainBullet.GetComponent<Bullet_Boomerang>();
    }

    public override void FireBullet()
    {
        switch (PowerLevel())
        {
            case 1:
                thisBullet.adjustHeight(8);
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                break;
            case 2:
                thisBullet.adjustHeight(10);
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                thisBullet.adjustHeight(8);
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                break;
            case 3:
                thisBullet.adjustHits(6);
                thisBullet.adjustHeight(10);
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                thisBullet.adjustHeight(8);
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                break;
            case 4:
                thisBullet.adjustHits(12);
                FireRate(0.05f);
                thisBullet.adjustHeight(10);
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                thisBullet.adjustHeight(8);
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                thisBullet.adjustHeight(6);
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
    }
}
