using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerChecker : MonoBehaviour
{
    private int incorrectCounter;

    public bool IsEqual(int currentNmbr, int value)
    {
        if (value == currentNmbr)
            return true;

        if(value != currentNmbr && incorrectCounter > 0)
        {
            ResetCounter();
            return false;
        }

        // Give feedback to manager 
        // first wrong answer
        incorrectCounter++;
        return false;
        
    }

    private void ResetCounter()
    {
        incorrectCounter = 0;
    }
}
