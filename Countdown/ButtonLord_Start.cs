using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonLord_Start : MonoBehaviour
{
    public InputField team1_InputField;
    public InputField team2_InputField;

    public void LoadScene_Start()
    {

        string team1Name = team1_InputField.text;
        string team2Name = team2_InputField.text;

        PlayerPrefs.SetString("team1_name", team1Name);
        PlayerPrefs.SetString("team2_name", team2Name);
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
}
