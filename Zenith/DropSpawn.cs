using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawn : MonoBehaviour
{
    public GameObject gold;
    public GameObject points;

    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, 10);
        if (random == 9)
        {
            gold.SetActive(true);
        }
        else if (random > 4)
        {
            points.SetActive(true);
        }
    }
}
