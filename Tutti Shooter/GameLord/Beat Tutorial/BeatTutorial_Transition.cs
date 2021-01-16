using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatTutorial_Transition : MonoBehaviour
{
    public Animator levelTransition;

     public void ToEndless()
    {
        StartCoroutine(Endless());
    }

    IEnumerator Endless()
    {
        levelTransition.SetTrigger("Continue");

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("Scenes/Level Endless");
    }

}
