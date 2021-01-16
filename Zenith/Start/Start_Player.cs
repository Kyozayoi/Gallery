using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Player : MonoBehaviour
{

    public PlayerDetails playerData;
    public int gold;

    private void OnEnable()
    {
        playerData = DataManager.LoadPlayer();
        gold = playerData.gold;
    }
    private void OnDisable()
    {
        DataManager.UpdateGold(gold);
    }
}
