using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataManager
{
    public static void SavePlayer(PlayerManager player)
    {
        int playerHS = player.playerData.highScore;
        int playerGold = player.playerData.gold;

        SaveObject newSave = new SaveObject
        {
            highScore = playerHS,
            gold = playerGold
        };
        string jsonString = JsonUtility.ToJson(newSave);

        Debug.Log("Saving: " + newSave.highScore + " | " + newSave.gold);

        File.WriteAllText(Application.dataPath + "/save.txt", jsonString);
    }

    public static PlayerDetails LoadPlayer()
    {
        if(File.Exists(Application.dataPath + "/save.txt"))
        {
            string loadString = File.ReadAllText(Application.dataPath + "/save.txt");

            SaveObject theSave = JsonUtility.FromJson<SaveObject>(loadString);

            int playerHS = theSave.highScore;
            int playerGold = theSave.gold;

            PlayerDetails playerSave = new PlayerDetails()
            {
                highScore = playerHS,
                gold = playerGold
            };

            Debug.Log("Loading: " + playerSave.highScore + " | " + playerSave.gold);

            return playerSave;
        }
        else
        {
            Debug.Log("Could not find a save file");
            return null;
        }
    }

    public static void UpdateGold(int newGold)
    {
        if (File.Exists(Application.dataPath + "/save.txt"))
        {
            string loadString = File.ReadAllText(Application.dataPath + "/save.txt");

            SaveObject theSave = JsonUtility.FromJson<SaveObject>(loadString);

            theSave.gold = newGold;

            string jsonString = JsonUtility.ToJson(theSave);

            Debug.Log("Saving: " + theSave.highScore + " | " + theSave.gold);

            File.WriteAllText(Application.dataPath + "/save.txt", jsonString);
        }
        else
        {
            Debug.Log("Could not find a save file");
        }
    }

    private class SaveObject
    {
        public int highScore;
        public int gold;
    }
}
