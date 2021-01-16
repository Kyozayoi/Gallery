using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form_Apple : Form
{
    private Vector3 level1Spawn;
    private Vector3 level2Spawn1;
    private Vector3 level2Spawn2;
    private Vector3 level3Spawn1;
    private Vector3 level3Spawn2;
    private Vector3 level4Spawn1;
    private Vector3 level4Spawn2;

    private void OnEnable()
    {
        level1Spawn = new Vector3(0.0f, 1.0f, 0.0f);
        level2Spawn1 = new Vector3(-.45f, .75f, 0.0f);
        level2Spawn2 = new Vector3(.45f, .75f, 0.0f);
        level3Spawn1 = new Vector3(-.75f, .5f, 0.0f);
        level3Spawn2 = new Vector3(.75f, .5f, 0.0f);
        level4Spawn1 = new Vector3(-1.0f, 0.0f, 0.0f);
        level4Spawn2 = new Vector3(1.0f, 0.0f, 0.0f);
    }

    public override void FireBullet()
    {
        switch (PowerLevel())
        {
            case 1:
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(mainBullet, level2Spawn1 + transform.position, Quaternion.identity);
                Instantiate(mainBullet, level2Spawn2 + transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                Instantiate(mainBullet, level3Spawn1 + transform.position, Quaternion.identity);
                Instantiate(mainBullet, level3Spawn2 + transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(mainBullet, level1Spawn + transform.position, Quaternion.identity);
                Instantiate(mainBullet, level3Spawn1 + transform.position, Quaternion.identity);
                Instantiate(mainBullet, level3Spawn2 + transform.position, Quaternion.identity);
                Instantiate(mainBullet, level4Spawn1 + transform.position, Quaternion.identity);
                Instantiate(mainBullet, level4Spawn2 + transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
    }

    


}



