using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public Animator levelTransition;

    // Start is called before the first frame update
    public void LoadNextLevel(string nextLevel)
    {
        StartCoroutine(LoadLevel(nextLevel));
    }

    IEnumerator LoadLevel(string nextLevel)
    {
        levelTransition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(nextLevel);
    }

    public void LoadGameOver()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        levelTransition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Scenes/Game Over");
    }

}
