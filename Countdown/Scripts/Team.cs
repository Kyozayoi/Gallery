using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Team : MonoBehaviour
{
    public TeamDetails TeamDetails { get; set; }

    public Text Name;
    public Text Score;
    public int TeamNumber;

    void Start()
    {
        if(TeamNumber == 1)
        {
            Name.text = PlayerPrefs.GetString("team1_name");
        }
        else
        {
            Name.text = PlayerPrefs.GetString("team2_name");
        }
    }

    void Update()
    {
        if (TeamNumber == 1)
        {
            Score.text = PlayerPrefs.GetInt("team1_score").ToString();
        }
        else
        {
            Score.text = PlayerPrefs.GetInt("team2_score").ToString();
        }
    }

}
