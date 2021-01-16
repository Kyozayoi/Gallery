using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Form : MonoBehaviour
{
    public string formName;

    public GameObject mainBullet;

    private int powerUps;

    public float baseFireCooldown;
    private float trueFireCooldown;
    public float cooldownModifier;
    private float nextFire;

    private AudioSource fireSound;
    private Player_Movement player;
    // Start is called before the first frame update
    void Start()
    {
        nextFire = 0;
        powerUps = 1;
        trueFireCooldown = 0;
        fireSound = this.GetComponent<AudioSource>();
        GameObject findPlayer = GameObject.FindWithTag("Player");
        player = findPlayer.GetComponent<Player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        powerUps = player.playerDetails.powerUps;

        trueFireCooldown = baseFireCooldown - (cooldownModifier * powerUps); 

        nextFire -= Time.deltaTime;

        if (Input.GetMouseButton(0) && nextFire < 0)
        {
            FireBullet();
            fireSound.Play();
            nextFire = trueFireCooldown;
        }
    }

    public abstract void FireBullet();

    public void FireRate(float modifier)
    {
        cooldownModifier = modifier;
    }

    public int PowerLevel()
    {
        if(powerUps > 14)
        {
            return 4;
        }
        if(powerUps > 9)
        {
            return 3;
        }
        if(powerUps > 4)
        {
            return 2;
        }
        return 1;
    }
}
