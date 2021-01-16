using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public PlayerManager player;

    public TMP_Text scoreText;
    public TMP_Text goldText;
    public TMP_Text retryText;

    public TMP_Text deathText1;
    public TMP_Text deathText2;

    public GameplayManager GM;
    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.score.ToString();
        goldText.text = "$" + player.gold;

        if (GM.playerRetry){
            retryText.text = "Continue";
        }
        else
        {
            retryText.text = "Restart";
        }

        deathText1.text = scoreText.text;
        deathText2.text = player.highScore.ToString();
    }

    public void retryClick()
    {
        if (GM.playerRetry)
        {
            GM.playerContinue();
        }
        else
        {
            GM.playerRestart();
        }
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void unpauseGame()
    {
        Time.timeScale = 1;
    }


}
