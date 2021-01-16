using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form_Watermelon : Form
{
    private Vector3 level1Spawn;
    private Vector3 level4Spawn1;
    private Vector3 level4Spawn2;

    private Bullet_Curved thisBullet;

    private void OnEnable()
    {
        level1Spawn = new Vector3(0.0f, 1.0f, 0.0f);
        level4Spawn1 = new Vector3(-1.0f, 0.5f, 0.0f);
        level4Spawn2 = new Vector3(1.0f, 0.5f, 0.0f);

        thisBullet = mainBullet.GetComponent<Bullet_Curved>();
    }

    public override void FireBullet()
    {
        switch (PowerLevel())
        {
            case 1:
                thisBullet.adjustDirection(1);
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                break;
            case 2:
                thisBullet.adjustDirection(1);
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                thisBullet.adjustDirection(-1);
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                break;
            case 3:
                thisBullet.adjustHits(7);
                FireRate(0.025f);
                thisBullet.adjustDirection(1);
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                thisBullet.adjustDirection(-1);
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                break;
            case 4:
                thisBullet.adjustHits(10);
                FireRate(0.05f);
                thisBullet.adjustDirection(1);
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                Instantiate(mainBullet, level4Spawn1 + transform.position, Quaternion.identity);
                thisBullet.adjustDirection(-1);
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                Instantiate(mainBullet, level4Spawn2 + transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
    }


}
