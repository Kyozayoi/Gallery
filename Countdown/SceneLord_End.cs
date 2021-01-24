using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneLord_End : MonoBehaviour
{
    public Text winner_name;
    public Text winner_score;
    private void Start()
    {
        int team1score = PlayerPrefs.GetInt("team1_score");
        int team2score = PlayerPrefs.GetInt("team2_score");

        if(team1score > team2score)
        {
            winner_name.text = PlayerPrefs.GetString("team1_name");
            winner_score.text = "Score: " + team1score;
        }
        else if(team2score > team1score)
        {
            winner_name.text = PlayerPrefs.GetString("team2_name");
            winner_score.text = "Score: " + team2score;
        }
        else
        {
            winner_name.text = "TIED. BOTH TEAMS WIN";
            winner_score.text = "Score: " + team1score;
        }
    }

    public void newGame_newTeams()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Scenes/Start Screen");
    }

    public void newGame_sameTeams()
    {
        PlayerPrefs.SetInt("team1_score", 0);
        PlayerPrefs.SetInt("team2_score", 0);
        PlayerPrefs.SetInt("round_number", 1);
        int roundChooser = Random.Range(1, 3);

        if (roundChooser == 1)
        {
            PlayerPrefs.SetString("round_type", "Numbers");
            SceneManager.LoadScene("Scenes/Numbers Round");
        }
        else
        {
            PlayerPrefs.SetString("round_type", "Letters");
            SceneManager.LoadScene("Scenes/Letters Round");
        }
    }

    public void exitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
