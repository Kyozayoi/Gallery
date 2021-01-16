using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Player_Movement player;
    public GameplayManager GM;
    public Text levelText;
    public Text levelValue;
    public Text scoreValue;
    public Text healthValue;
    public Text formValue;
    public Text enemiesValue;

    public Text PowerupsValue;
    public Text PowerLevelValue;
    public Text WeaponName;

    void Start()
    {
        enemiesValue.text = "0 / " + GM.maxEnemies;
        levelText.text = "Level " + GM.levelNumber;
        levelValue.text = GM.nameLevel;
    }

    void Update()
    {
        scoreValue.text = player.playerDetails.score.ToString("D8");
        enemiesValue.text = player.playerDetails.killedEnemies + " / " + GM.maxEnemies;
        formValue.text = player.playerDetails.formValue;
        healthValue.text = player.playerDetails.health + " / 5";
        PowerupsValue.text = player.playerDetails.powerUps.ToString();
        PowerLevelValue.text = player.playerDetails.powerLevel.ToString();
        WeaponName.text = player.playerDetails.weaponName;
    }

    public void saveQuit()
    {
        DataManager.SaveData(player);
        Application.Quit();
    }

    public void saveMenu()
    {
        DataManager.SaveData(player);
        SceneManager.LoadScene("Scenes/Main Menu");
    }

}
