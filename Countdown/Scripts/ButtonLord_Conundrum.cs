using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLord_Conundrum : MonoBehaviour
{

    public Text scrambled;
    public Text not_scrambled;

    private string[] nineLetters = {"ACCORDING", "AGREEMENT", "AUSTRALIA", "AVAILABLE", "CHRISTMAS", "COMMITTEE", "COMMUNITY","COMPANIES","COMPUTERS","CONDITION","COPYRIGHT","CORPORATE","COUNTRIES","CURRENTLY","CUSTOMERS","DIFFERENT","DIRECTORY","DOWNLOADS","EDUCATION","EFFECTIVE","EQUIPMENT","EXECUTIVE","FINANCIAL","FOLLOWING","FURNITURE","IMPORTANT","INCLUDING","INSTITUTE","INSURANCE","MARKETING","MATERIALS","MICROSOFT","NECESSARY","POLITICAL","PRESIDENT","PUBLISHED","QUESTIONS","REFERENCE","RESOURCES","SELECTION","SEPTEMBER","SOLUTIONS","SOMETHING","SPONSORED","STANDARDS","STATEMENT","SUBSCRIBE","TECHNICAL","TREATMENT","WEDNESDAY","ABHORRENT","ABILITIES","ABRASIONS","ACQUITTED","ADULTHOOD","BASEBOARD","BLEACHERS","DRIZZLING","EMBEZZLES","EXPERTISE","HIJACKERS","LIFEHACKS","NEWLYWEDS","ORTHODOXY","PARALYZED","RECOGNIZE","REFLEXIVE","TECHNIQUE","TEXTBOOKS","UNPLUGGED","WHICHEVER","YELLOWISH"};

    void Start()
    {
        string chosen = nineLetters[Random.Range(0, nineLetters.Length)];
        not_scrambled.text = chosen;
        char[] scrambler = chosen.ToCharArray();

        for (int i = 0; i < scrambler.Length; i++)
        {
            int swap = Random.Range(0, scrambler.Length);
            char temp = scrambler[swap];
            scrambler[swap] = scrambler[i];
            scrambler[i] = temp;
        }

        string transfer = new string(scrambler);
        scrambled.text = transfer;

    }

}
