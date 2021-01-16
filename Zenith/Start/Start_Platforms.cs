using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Platforms : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(0.0f, 0.0f, 5.0f) * Time.deltaTime;

        if(this.transform.position.z < -5.0f)
        {
            this.transform.position = new Vector3(-10.0f, 0.0f, 145.0f);
        }
    }
}
