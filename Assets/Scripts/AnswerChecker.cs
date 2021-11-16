using UnityEngine;

public enum Answer { Right, FirstWrong, SecondWrong }

public class AnswerChecker : MonoBehaviour
{
    private int incorrectCounter;

    public Answer IsEqual(int currentNmbr, int value)
    {
        if (value == currentNmbr)
        {
            ResetCounter();
            return Answer.Right;
        }

        if (value != currentNmbr && incorrectCounter > 0)
        {
            ResetCounter();
            return Answer.SecondWrong;
        }

        incorrectCounter++;
        return Answer.FirstWrong;
        
    }

    private void ResetCounter()
    {
        incorrectCounter = 0;
    }
}

