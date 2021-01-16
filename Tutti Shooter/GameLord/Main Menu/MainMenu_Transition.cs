using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Transition : MonoBehaviour
{
    public Animator startTransition;

    // Start is called before the first frame update
    public void StartTheGame(string nextLevel)
    {
        StartCoroutine(StartGame(nextLevel));
    }

    IEnumerator StartGame(string nextLevel)
    {
        startTransition.SetTrigger("Start Game");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(nextLevel);
    }

}
