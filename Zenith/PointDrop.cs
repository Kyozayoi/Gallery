using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDrop : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(new Vector3(0.0f, 0.0f, 10.0f * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager player = other.gameObject.GetComponent<PlayerManager>();
            if (player != null)
            {
                player.collect(true, 10);
                Destroy(transform.parent.gameObject);
            }
        }
    }

}
