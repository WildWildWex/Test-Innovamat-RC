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

        if (value != currentNmbr && incorrectCounter > 1)
        {
            incorrectCounter--;
            return Answer.FirstWrong;
        }

        ResetCounter();
        return Answer.SecondWrong;
    }

    public void ResetCounter()
    {
        incorrectCounter = GameFacade.instance.GetAmountOfAnswers() -1;
    }

}

