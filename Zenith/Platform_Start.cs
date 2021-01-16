using UnityEngine;

public class Platform_Start : MonoBehaviour
{
    public int scoreModifier;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager player = other.gameObject.GetComponent<PlayerManager>();
            if (player != null)
            {
                player.newPlatform(scoreModifier, this.transform.position + new Vector3(0.0f, 0.0f, 1.0f));
            }
        }
    }
}
