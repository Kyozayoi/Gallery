using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public Player_Movement player;

    public GameObject[] enemies;
    public int maxEnemies;
    public int levelNumber;
    public string nameLevel;

    private float xMin = -13.0f;
    private float xMax = 2.0f;
    private float ySet = 26.0f;
    private float zSet = 0.0f;

    private int powerUp;
    private int healthUp;
    private int obstacles;

    public float startDelay;
    public float waveDelay;
    public int spawnEnemies;

    private bool spawnWaves;
    public bool endless;

    public TransitionManager transition;

    void Awake()
    {
        PlayerPrefs.SetInt("max_enemies", maxEnemies);
        PlayerPrefs.SetInt("level", levelNumber);
        PlayerPrefs.SetString("level_name", nameLevel);
    }

    void Start()
    {
        spawnWaves = true;
        powerUp = enemies.Length - 1;
        healthUp = enemies.Length - 2;
        obstacles = enemies.Length - 3;
        StartCoroutine(SpawnWaves());
        StartCoroutine(SpawnObstacles());
        StartCoroutine(SpawnPowerUps());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startDelay);

        while (spawnWaves)
        {
            for (int i = 0; i < spawnEnemies; i++)
            {
                Vector3 enemyPosition = new Vector3(Random.Range(xMin, xMax), ySet, zSet);
                Quaternion enemyRotation = Quaternion.identity;
                int randomEnemy = Random.Range(0, enemies.Length - 3);
                Instantiate(enemies[randomEnemy], enemyPosition, enemyRotation);
            }
            
            yield return new WaitForSeconds(waveDelay);
        }
    }

    IEnumerator SpawnObstacles()
    {
        yield return new WaitForSeconds(startDelay);

        while (spawnWaves)
        {
            for(int i = 0; i < 3; i++)
            {
                bool spawn = (Random.value >= 0.8);
                if (spawn)
                {
                    Vector3 spawnObstacle = new Vector3(0.0f + (-5.5f * i) ,ySet, zSet);
                    Instantiate(enemies[obstacles], spawnObstacle, Quaternion.identity);
                }
            }
            yield return new WaitForSeconds(waveDelay * 5);
        }
    }

    IEnumerator SpawnPowerUps()
    {
        yield return new WaitForSeconds(startDelay);

        while (spawnWaves)
        {
            bool spawnPU = (Random.value >= 0.5f);
            bool spawnHR = (Random.value >= 0.5f);
            if (spawnPU)
            {
                Vector3 spawnHere = new Vector3(Random.Range(xMin, xMax), ySet, zSet);
                Instantiate(enemies[powerUp], spawnHere, Quaternion.identity);
            }
            if (spawnHR)
            {
                Vector3 spawnHere = new Vector3(Random.Range(xMin, xMax), ySet, zSet);
                Instantiate(enemies[healthUp], spawnHere, Quaternion.identity);
            }

            yield return new WaitForSeconds(Random.Range(15.0f, 30.0f));
        }
    }

    private void Update()
    {
        if (player.playerDetails.killedEnemies >= maxEnemies && !endless)
        {
            spawnWaves = false;
            player.NextLevel();
            if(levelNumber == 3)
            {
                StartCoroutine(LoadNextLevel("Scenes/Beat Tutorial"));
            }
            else
            {
                StartCoroutine(LoadNextLevel("Scenes/Level " + (levelNumber + 1)));
            }
        }

        if(player.playerDetails.health <= 0)
        {
            spawnWaves = false;
            StartCoroutine(GameOver());
        }

    }

    IEnumerator LoadNextLevel(string levelText)
    {
        yield return new WaitForSeconds(5.0f);
        transition.LoadNextLevel(levelText);
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3.0f);

        transition.LoadGameOver();
    }
}
