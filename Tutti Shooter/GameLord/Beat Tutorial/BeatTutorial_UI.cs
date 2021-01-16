using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatTutorial_UI : MonoBehaviour
{
    public BeatTutorial_Transition transitioner;

    public void EndlessLevel()
    {
        transitioner.ToEndless();
    }

}
