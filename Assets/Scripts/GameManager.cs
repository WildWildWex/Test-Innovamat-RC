using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScoreCounter scrCounter;
    public AnswerChecker answerChecker;
    public UIDisplayer uiDisplayer;
    public StringConverter stringConverter;
    public NumberPicker numberPicker;

    private int correctScr;
    private int incorrectScr;
    private int currentNmbr;
    private string currentString;


    private void Start()
    {
        GetNewSentence();
    }

    public void RightAnswer()
    {
        scrCounter.AddScore(correctScr, 1);
    }

    public void WrongAnswer()
    {
        scrCounter.SubstractScore(correctScr, 1);
    }

    public void CheckAnswer(int value)
    {
        answerChecker.IsEqual(currentNmbr, value);
    }

    public void GetNewSentence()
    {
        // Ya que en el test siempre habran 3 respuestas, he "hardcodeado" el valor.
        // En el caso de tener variaciones, se podria pasar dicho valor como parametro

        int[] numbers = new int[3];

        for(int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = numberPicker.PickRandomNumber();
        }

        int randomValue = Random.Range(0, 3);
        currentNmbr = numbers[randomValue];
    }
}
