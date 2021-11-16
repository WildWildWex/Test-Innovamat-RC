using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    // References
    public static GameFacade instance;
    public ScoreCounter scrCounter;
    public AnswerChecker answerChecker;
    public UIDisplayer uiDisplayer;
    public StringConverter stringConverter;
    public NumberPicker numberPicker;
    public ButtonsSpawner buttonsSpawner;
    // Score
    private int correctScr;
    private int incorrectScr;

    // Current Sentence
    private int currentNmbr;
    private string currentString;

    #region Unity Methods
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        buttonsSpawner.InitializeAllButtons();
        GetNewSentence();
    }
    #endregion

    public void GetNewSentence()
    {
        int[] numbers = new int[buttonsSpawner.buttonControllers.Length];

        // Ask for X random numbers
        for(int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = numberPicker.PickRandomNumber();
            // Initialize buttons with given value
            buttonsSpawner.buttonControllers[i].Initialize(numbers[i]);
        }

        // Pick right answer
        int randomValue = Random.Range(0, numbers.Length);
        currentNmbr = numbers[randomValue];
        buttonsSpawner.SetRightNumberInArray(randomValue);

        // Convert number to string
        currentString = stringConverter.ToText(currentNmbr.ToString());

        // Update and display sentence 
        uiDisplayer.UpdateSentence(currentString);

        uiDisplayer.ResetButonsColor(buttonsSpawner.buttonControllers);
    }

    public void CheckAnswer(int value, ButtonController btnController )
    {
        // While checking, all buttons must remain inactive
        buttonsSpawner.SetButtonsInactive();

        // Check 
        Answer answer = answerChecker.IsEqual(currentNmbr, value);

        switch (answer)
        {
            case Answer.Right:

                uiDisplayer.SetColorToRight(btnController);
                StartCoroutine(RightAnswer());
                break;

            case Answer.FirstWrong:

                uiDisplayer.SetColorToWrong(btnController);
                uiDisplayer.FadeOut(btnController);
                buttonsSpawner.SetOtherButtonsActive(btnController);
                break;

            case Answer.SecondWrong:

                uiDisplayer.SetColorToWrong(btnController);
                uiDisplayer.SetColorToRight(buttonsSpawner.GetRightButtonInArray());
                StartCoroutine(SecondWrongAnswer());
                break;
        }
    }

    private IEnumerator RightAnswer()
    {
        // Update score
        correctScr = scrCounter.AddScore(correctScr, 1);
        uiDisplayer.UpdateCorrectScr(correctScr);
        yield return new WaitForSeconds(1);
        
        // Play fade out animation
        uiDisplayer.HideAllButtons(buttonsSpawner.canvasGroups);
        yield return new WaitForSeconds(1);

        // Start new Sentence
        GetNewSentence();
        buttonsSpawner.SetButtonsActive();
        yield break;
    }

    private IEnumerator SecondWrongAnswer()
    {
        incorrectScr = scrCounter.AddScore(incorrectScr, 1);
        uiDisplayer.UpdateIncorrectScr(incorrectScr);
        yield return new WaitForSeconds(1);

        uiDisplayer.HideAllButtons(buttonsSpawner.canvasGroups);
        yield return new WaitForSeconds(1);

        GetNewSentence();
        buttonsSpawner.SetButtonsActive();
        yield break;
    }
}
