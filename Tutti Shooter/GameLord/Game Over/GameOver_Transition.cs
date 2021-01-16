using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver_Transition : MonoBehaviour
{
    public Animator levelTransition;

    // Start is called before the first frame update
    public void QuitTheGame()
    {
        StartCoroutine(QuitGame());
    }

    IEnumerator QuitGame()
    {
        levelTransition.SetTrigger("Continue");

        yield return new WaitForSeconds(2);

        Application.Quit();
    }

    public void BacktoMenu()
    {
        StartCoroutine(BackMenu());
    }

    IEnumerator BackMenu()
    {
        levelTransition.SetTrigger("Continue");

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("Scenes/Main Menu");
    }

}
