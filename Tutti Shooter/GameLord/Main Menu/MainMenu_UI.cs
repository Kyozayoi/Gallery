using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_UI : MonoBehaviour
{
    public MainMenu_Transition transitioner;

    private int playerForm;
    private string formName;
    public void startLevel(int level)
    {
        PlayerPrefs.SetInt("level", level);
        transitioner.StartTheGame("Scenes/Level " + level);
    }

    public void selectForm(int form)
    {
        PlayerPrefs.SetInt("form", form);
        playerForm = form;
        switch (form)
        {
            case 0:
                formName = "Angry Apple";
                break;
            case 1:
                formName = "Bitchy Banana";
                break;
            case 2:
                formName = "Wackass Watermelon";
                break;
            default:
                break;
        }
    }

    public void resetData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("form", playerForm);
        PlayerPrefs.SetString("form_name", formName);
    }
}
