using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public PlayerManager thePlayer;
    public FollowPlayer playerStatus;

    public Platform[] platforms;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    public bool playerRetry = true;

    public Animator screenAnimator;
    public AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector3(0.0f, 0.0f, 100.0f);
        spawnRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        StartCoroutine(loadLevels());
    }

    IEnumerator loadLevels()
    {
        for (int i = 0; i < 2; i++)
        {
            Platform nextPlatform = Instantiate(platforms[Random.Range(1, platforms.Length)], spawnPosition, spawnRotation);

            spawnPosition = nextPlatform.endPoint.transform.position;
            spawnRotation = nextPlatform.endPoint.transform.rotation;

            this.transform.position = nextPlatform.startPoint.transform.position;
            this.transform.rotation = nextPlatform.startPoint.transform.rotation;
        }
        //animate 3, 2, 1 countdown
        yield return new WaitForSeconds(5.0f);
        thePlayer.run();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Platform nextPlatform = Instantiate(platforms[Random.Range(1, platforms.Length)], spawnPosition, spawnRotation);

            spawnPosition = nextPlatform.endPoint.transform.position;
            spawnRotation = nextPlatform.endPoint.transform.rotation;

            this.transform.position = nextPlatform.startPoint.transform.position;
            this.transform.rotation = nextPlatform.startPoint.transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStatus.playerFallen())
        {
            StartCoroutine(playerFell());
        }
    }

    IEnumerator playerFell()
    {
        thePlayer.fell();
        yield return new WaitForSeconds(0.5f);
        bgm.Stop();

        screenAnimator.SetBool("Death", true);
    }

    public void playerContinue()
    {
        //animate 3, 2, 1 countdown
        StartCoroutine(PlayerContinues());
    }

    IEnumerator PlayerContinues()
    {
        Debug.Log("Player Continues");
        playerStatus.reset();
        screenAnimator.SetBool("Death", false);
        playerRetry = false;
        //animate 3, 2, 1 countdown
        thePlayer.continueGame();
        yield return new WaitForSeconds(2.5f);
        bgm.Play();
    }

    public void playerRestart()
    {
        StartCoroutine(PlayerRestarts());
    }

    IEnumerator PlayerRestarts()
    {
        Debug.Log("Player Restarts");

        foreach(Platform p in Object.FindObjectsOfType<Platform>())
        {
            Destroy(p.gameObject);
        }
        foreach (GoldDrop gd in Object.FindObjectsOfType<GoldDrop>())
        {
            Destroy(gd.gameObject);
        }
        foreach (PointDrop pd in Object.FindObjectsOfType<PointDrop>())
        {
            Destroy(pd.gameObject);
        }

        playerStatus.reset();
        screenAnimator.SetBool("Death", false);
        playerRetry = true;
        spawnPosition = new Vector3(0.0f, 0.0f, 0.0f);
        spawnRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        Platform nextPlatform = Instantiate(platforms[0], spawnPosition, spawnRotation);
        spawnPosition = nextPlatform.endPoint.transform.position;
        spawnRotation = nextPlatform.endPoint.transform.rotation;

        yield return new WaitForSeconds(1.0f);

        StartCoroutine(loadLevels());
        thePlayer.restartGame();
        bgm.Play();
    }
}
