using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLord_Letters : MonoBehaviour
{

    private char[] vowels = { 'A', 'A','A','A','A','A','A','A','A','A','A','A','A','A','A','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','E','I','I','I','I','I','I','I','I','I','I','I','I','I','O','O','O','O','O','O','O','O','O','O','O','O','O','U','U','U','U','U'};
    private int vowel;
    private char[] consonants = { 'B','B','C','C','C','D','D','D','D','D','D','F','F','G','G','G','H','H','J','K','L','L','L','L','L','M','M','M','M','N','N','N','N','N','N','N','N','P','P','P','P','Q','R','R','R','R','R','R','R','R','R','S','S','S','S','S','S','S','S','S','T','T','T','T','T','T','T','T','T','V','W','X','Y','Z' };
    private int consonant;
    private int numLetters;

    public Text letterSpace1;
    public Text letterSpace2;
    public Text letterSpace3;
    public Text letterSpace4;
    public Text letterSpace5;
    public Text letterSpace6;
    public Text letterSpace7;
    public Text letterSpace8;
    public Text letterSpace9;

    // Start is called before the first frame update
    void Start()
    {
        vowel = 0;
        consonant = 0;
        numLetters = 0;
        Shuffle();
    }

    private void Shuffle()
    {
        for (int i = 0; i < vowels.Length; i++)
        {
            int swap = Random.Range(0, vowels.Length);
            char temp = vowels[swap];
            vowels[swap] = vowels[i];
            vowels[i] = temp;
        }
        for (int i = 0; i < consonants.Length; i++)
        {
            int swap = Random.Range(0, consonants.Length);
            char temp = consonants[swap];
            consonants[swap] = consonants[i];
            consonants[i] = temp;
        }
    }

    public void genVowel()
    {
        char output = vowels[vowel];
        switch (numLetters)
        {
            case 0:
                letterSpace1.text = output.ToString();
                break;
            case 1:
                letterSpace2.text = output.ToString();
                break;
            case 2:
                letterSpace3.text = output.ToString();
                break;
            case 3:
                letterSpace4.text = output.ToString();
                break;
            case 4:
                letterSpace5.text = output.ToString();
                break;
            case 5:
                letterSpace6.text = output.ToString();
                break;
            case 6:
                letterSpace7.text = output.ToString();
                break;
            case 7:
                letterSpace8.text = output.ToString();
                break;
            case 8:
                letterSpace9.text = output.ToString();
                break;
            default:
                break;
        }
        numLetters++;
        vowel++;
    }
    

    public void genConsonant()
    {
        char output = consonants[consonant];
        switch (numLetters)
        {
            case 0:
                letterSpace1.text = output.ToString();
                break;
            case 1:
                letterSpace2.text = output.ToString();
                break;
            case 2:
                letterSpace3.text = output.ToString();
                break;
            case 3:
                letterSpace4.text = output.ToString();
                break;
            case 4:
                letterSpace5.text = output.ToString();
                break;
            case 5:
                letterSpace6.text = output.ToString();
                break;
            case 6:
                letterSpace7.text = output.ToString();
                break;
            case 7:
                letterSpace8.text = output.ToString();
                break;
            case 8:
                letterSpace9.text = output.ToString();
                break;
            default:
                break;
        }
        numLetters++;
        consonant++;
    }

}
