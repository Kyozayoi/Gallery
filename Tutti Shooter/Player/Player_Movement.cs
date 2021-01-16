using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour, ICollidable
{
    public PlayerDetails playerDetails;
    
    public float moveSpeed;

    public GameObject[] forms;
    private Form currentForm;

    public GameObject selfExplosion;

    private Vector3 spawnPoint = new Vector3(-5.0f, 0.0f, 0.0f);
    private Vector3 leftLimit = new Vector3(-12.0f, -4.0f, 0.0f);
    private Vector3 rightLimit = new Vector3(2.0f, 10.0f, 0.0f);

    public float invulnerabilityTime;
    private float inVulnerable;

    public GameObject invulIndicator;

    public int damage;

    public Animator playerAnimator;

    private void OnEnable()
    {
        playerDetails = DataManager.LoadData();
        transform.position = spawnPoint;
    }

    private void OnDisable()
    {
        DataManager.SaveData(this);
    }

    private void Start()
    {
        forms[playerDetails.form].SetActive(true);
        currentForm = forms[playerDetails.form].GetComponent<Form>();
        playerDetails.formValue = currentForm.formName;
        inVulnerable = 0;
    }

    private void Update()
    {
        inVulnerable -= Time.deltaTime;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.up * y) * moveSpeed;
        Vector3 newPosition = transform.position + move;

        transform.position = new Vector3(Mathf.Clamp(newPosition.x, leftLimit.x, rightLimit.x), Mathf.Clamp(newPosition.y, leftLimit.y, rightLimit.y), 0.0f);

        if (Input.GetKeyDown("1") && playerDetails.form != 0)
        {
            StartCoroutine(UpdateForm(0));
            playerDetails.weaponName = "Bullet Seed";
        }
        else if (Input.GetKeyDown("2") && playerDetails.form != 1)
        {
            StartCoroutine(UpdateForm(1));
            playerDetails.weaponName = "Slippery Peel";
        }
        else if (Input.GetKeyDown("3") && playerDetails.form != 2)
        {
            StartCoroutine(UpdateForm(2));
            playerDetails.weaponName = "Curveball";
        }

    }

    IEnumerator UpdateForm(int form)
    {
        playerAnimator.SetTrigger("Swap Out");

        yield return new WaitForSeconds(0.5f);

        forms[playerDetails.form].SetActive(false);
        playerDetails.form = form;
        forms[playerDetails.form].SetActive(true);
        currentForm = forms[playerDetails.form].GetComponent<Form>();
        playerDetails.formValue = currentForm.formName;

        yield return new WaitForSeconds(0.5f);

        playerAnimator.SetTrigger("Swap In");
    }

    public void NextLevel()
    {
        Collider thisCol = this.GetComponent<Collider>();
        if(thisCol != null)
        {
            thisCol.isTrigger = false;
        }
        if (playerAnimator.gameObject.activeSelf)
        {
            playerAnimator.SetTrigger("Exit Level");
        }
    }

    public void TakeDamage()
    {
        if(inVulnerable < 0)
        {
            StartCoroutine(Blink(invulnerabilityTime));
            playerDetails.health--;
            inVulnerable = invulnerabilityTime;
            if (playerDetails.health == 0)
            {
                Instantiate(selfExplosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Blink(float waitTime)
    {
        var endTime = Time.time + waitTime;
        while (Time.time < endTime)
        {
            invulIndicator.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            invulIndicator.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void UpdateScore(int scoreValue)
    {
        playerDetails.score += scoreValue;
        playerDetails.killedEnemies++;
    }

    public void Collide(int collided)
    {
        switch (collided)
        {
            case 0:
                TakeDamage();
                break;
            case 1:
                TakeDamage();
                break;
            case 2:
                playerDetails.powerUps++;
                break;
            case 3:
                playerDetails.health++;
                if (playerDetails.health > 5)
                {
                    playerDetails.health = 5;
                }
                break;
            case 4:
                TakeDamage();
                break;
            default:
                break;
        }
    }

    IEnumerator UpdatePowerLevel()
    {
        yield return new WaitForSeconds(1);
        playerDetails.powerLevel = currentForm.PowerLevel();
    }

    public int Damage()
    {
        return damage;
    }
}
