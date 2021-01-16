using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneUpdater : MonoBehaviour
{
    public Text RoundTitle;
    public Text timer;
    private float Timer;
    private bool countingDown;
    public InputField scoreHere;

    void Start()
    {
        RoundTitle.text = PlayerPrefs.GetInt("round_number") + " - " + PlayerPrefs.GetString("round_type");
        Timer = 30;
    }

    void Update()
    {
        timer.text = Timer.ToString();
        if (countingDown)
        {
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                Timer = 0;
                countingDown = false;
            }
        }
    }

    public void addScore(int teamNumber)
    {
        int score = int.Parse(scoreHere.text);
        if (teamNumber == 1)
        {
            int team1score = PlayerPrefs.GetInt("team1_score");
            PlayerPrefs.SetInt("team1_score", team1score + score);
        }
        else
        {
            int team2score = PlayerPrefs.GetInt("team2_score");
            PlayerPrefs.SetInt("team2_score", team2score + score);
        }

        int roundNumber = PlayerPrefs.GetInt("round_number");
        string roundType = PlayerPrefs.GetString("round_type");
        if (roundNumber == 5)
        {
            PlayerPrefs.SetString("round_type", "Conundrum");
            SceneManager.LoadScene("Scenes/Conundrum Round");
        }
        else
        {
            PlayerPrefs.SetInt("round_number", roundNumber + 1);
            if (roundType.Equals("Numbers")){
                PlayerPrefs.SetString("round_type", "Letters");
                SceneManager.LoadScene("Scenes/Letters Round");
            }
            else
            {
                PlayerPrefs.SetString("round_type", "Numbers");
                SceneManager.LoadScene("Scenes/Numbers Round");
            }
        }
    }

    public void startTimer()
    {
        countingDown = true;
    }

}
