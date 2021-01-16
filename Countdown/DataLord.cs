using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLord : MonoBehaviour
{

    public string team1_Name;
    public string team2_Name;
    public int team1_Score;
    public int team2_Score;
    public int roundNumber;
    public string roundType;

    void Start()
    {
        roundNumber = PlayerPrefs.GetInt("round_number", 0);
        team1_Score = PlayerPrefs.GetInt("team1_score", 0);
        team2_Score = PlayerPrefs.GetInt("team2_score", 0);
        team1_Name = PlayerPrefs.GetString("team1_name", "Team Kappa");
        team2_Name = PlayerPrefs.GetString("team2_name", "Team Pepe");
        roundType = PlayerPrefs.GetString("round_type", "Letters");
    }
    
}
