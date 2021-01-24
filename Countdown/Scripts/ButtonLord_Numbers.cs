using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLord_Numbers : MonoBehaviour
{
    public Text targetSpace1;
    public Text targetSpace2;
    public Text targetSpace3;
    private int numNumbers;
    private int target;

    public Text numSpace1;
    public Text numSpace2;
    public Text numSpace3;
    public Text numSpace4;
    public Text numSpace5;
    public Text numSpace6;

    private int[] smallNumbers = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10 };
    private int smallNum;
    private int[] largeNumbers = { 25, 50, 75, 100 };
    private int largeNum;

    void Start()
    {
        numNumbers = 0;
        smallNum = 0;
        largeNum = 0;
        Shuffle();
    }

    private void Shuffle()
    {
        for(int i = 0; i < smallNumbers.Length; i++)
        {
            int swap = Random.Range(0, smallNumbers.Length);
            int temp = smallNumbers[swap];
            smallNumbers[swap] = smallNumbers[i];
            smallNumbers[i] = temp;
        }
        for (int i = 0; i < largeNumbers.Length; i++)
        {
            int swap = Random.Range(0, largeNumbers.Length);
            int temp = largeNumbers[swap];
            largeNumbers[swap] = largeNumbers[i];
            largeNumbers[i] = temp;
        }
    }

    public void largeNumber()
    {
        int output = largeNumbers[largeNum];
        switch (numNumbers)
        {
            case 0:
                numSpace6.text = output.ToString();
                break;
            case 1:
                numSpace5.text = output.ToString();
                break;
            case 2:
                numSpace4.text = output.ToString();
                break;
            case 3:
                numSpace3.text = output.ToString();
                break;
            case 4:
                numSpace2.text = output.ToString();
                break;
            case 5:
                numSpace1.text = output.ToString();
                break;
            default:
                break;
        }
        numNumbers++;
        largeNum++;
        if (numNumbers == 6)
        {
            GenerateTarget();
        }
    }
    
    public void smallNumber()
    {
        int output = smallNumbers[smallNum];
        switch (numNumbers)
        {
            case 0:
                numSpace6.text = output.ToString();
                break;
            case 1:
                numSpace5.text = output.ToString();
                break;
            case 2:
                numSpace4.text = output.ToString();
                break;
            case 3:
                numSpace3.text = output.ToString();
                break;
            case 4:
                numSpace2.text = output.ToString();
                break;
            case 5:
                numSpace1.text = output.ToString();
                break;
            default:
                break;
        }
        numNumbers++;
        smallNum++;
        if (numNumbers == 6)
        {
            GenerateTarget();
        }
    }

    private void GenerateTarget()
    {
        target = Random.Range(101, 1000);
        targetSpace1.text = target.ToString().Substring(0,1);
        targetSpace2.text = target.ToString().Substring(1,1);
        targetSpace3.text = target.ToString().Substring(2,1);
    }

}
