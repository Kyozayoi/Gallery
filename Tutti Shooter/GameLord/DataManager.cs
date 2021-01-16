using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{

    public static PlayerDetails LoadData()
    {
        int loadScore = PlayerPrefs.GetInt("score", 0);
        int loadHealth = PlayerPrefs.GetInt("health", 5);
        if(loadHealth == 0)
        {
            loadHealth = 5;
        }
        int loadForm = PlayerPrefs.GetInt("form", 0);
        int loadLevel = PlayerPrefs.GetInt("level", 1);
        int loadKills = PlayerPrefs.GetInt("killed_enemies", 0);
        string loadFormName = PlayerPrefs.GetString("form_name", "Angry Apple");
        int loadPowerUps = PlayerPrefs.GetInt("power_ups", 0);
        int loadPowerLevel = PlayerPrefs.GetInt("power_level", 1);
        string loadWeaponName = PlayerPrefs.GetString("weapon_name", "Bullet Seed");
        PlayerDetails playerDetails = new PlayerDetails()
        {
            score = loadScore,
            health = loadHealth,
            form = loadForm,
            level = loadLevel,
            killedEnemies = loadKills,
            formValue = loadFormName,
            powerUps = loadPowerUps,
            powerLevel = loadPowerLevel,
            weaponName = loadWeaponName
        };

        return playerDetails;
    }

    public static void SaveData(Player_Movement player)
    {
        PlayerPrefs.SetInt("score", player.playerDetails.score);
        PlayerPrefs.SetInt("health", player.playerDetails.health);
        PlayerPrefs.SetInt("form", player.playerDetails.form);
        PlayerPrefs.SetString("form_value", player.playerDetails.formValue);
        PlayerPrefs.SetInt("level", player.playerDetails.level);
        PlayerPrefs.SetInt("killed_enemies", player.playerDetails.killedEnemies);
        PlayerPrefs.SetInt("power_ups", player.playerDetails.powerUps);
        PlayerPrefs.SetInt("power_level", player.playerDetails.powerLevel);
        PlayerPrefs.SetString("weapon_name", player.playerDetails.weaponName);
    }

    public static void ResetHealth()
    {
        PlayerPrefs.SetInt("health", 5);
    }

}
