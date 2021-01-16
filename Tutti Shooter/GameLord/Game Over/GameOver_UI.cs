using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver_UI : MonoBehaviour
{
    public GameOver_Transition transitioner;

    public Text finalScore;
    public Text enemiesKilled;

    public PlayerDetails playerData;
    // Start is called before the first frame update
    void Start()
    {
        playerData = DataManager.LoadData();
        finalScore.text = playerData.score.ToString("D8");
        enemiesKilled.text = playerData.killedEnemies.ToString();
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
        transitioner.QuitTheGame();
    }

    public void BackMenu()
    {
        DataManager.ResetHealth();
        transitioner.BacktoMenu();
    }

}
