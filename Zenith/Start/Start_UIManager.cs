using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Start_UIManager : MonoBehaviour
{

    public Animator screenAnimator;
    public Start_Player player;
    public TMP_Text playerGold;

    public void StartGame()
    {
        StartCoroutine(StartingGame());
        playerGold.text = "Cash: $" + player.gold;
    }

    IEnumerator StartingGame()
    {
        screenAnimator.SetTrigger("Start Game");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Scenes/Gameplay Scene");
    }

    public void ShowTutorial()
    {
        screenAnimator.SetTrigger("Tutorial");
    }

    public void RemoveTutorial()
    {
        screenAnimator.SetTrigger("Tutorial Exit");
    }

    public void ShowLeaderboard()
    {
        screenAnimator.SetTrigger("Leaderboard");
    }

    public void RemoveLeaderboard()
    {
        screenAnimator.SetTrigger("Leaderboard Exit");
    }
}
