using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplayer : MonoBehaviour
{
    public Text sentence;
    public Text correctScoreTxt;
    public Text IncorrectScoreTxt;

    [Header("Buttons")]
    public Color defaultColor;
    public Color wrongColor;
    public Color rightColor;

    #region Sentence
    public void UpdateSentence(string str)
    {
        StartCoroutine(FadeInAndOut(sentence, 2f));
        sentence.text = str;
    }

    /// <summary>
    /// Fades in, wait for the specified amount of time and fades out
    /// </summary>
    /// <param name="col"></param>
    /// <param name="timer"></param>
    /// <returns></returns>
    public IEnumerator FadeInAndOut(Text txt, float timer)
    {
        for (float i = 0; i <= 2; i += Time.deltaTime)
        {
            txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, i/2);
            yield return null;
        }

        yield return new WaitForSeconds(timer);

        for (float i = 2; i >= 0; i -= Time.deltaTime)
        {
            txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, i/2);
            yield return null;
        }

        ShowAllButtons(GameFacade.instance.buttonsSpawner.canvasGroups);
    }

    /// <summary>
    /// Animation from transparent to opaque
    /// </summary>
    /// <param name="fadeAway"></param>
    /// <param name="canvas"></param>
    /// <returns></returns>
    private IEnumerator FadeIn(CanvasGroup canvas)
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            canvas.alpha =  i;
            yield return null;
        }
        canvas.interactable = true;
    }

    /// <summary>
    /// Animation from opaque to transparent
    /// </summary>
    /// <param name="canvas"></param>
    /// <returns></returns>
    private IEnumerator FadeOut(CanvasGroup canvas)
    {
        canvas.interactable = false;

        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            canvas.alpha =  i;

            yield return null;
        }
    }
    #endregion

    #region Score
    public void UpdateCorrectScr(int value)
    {
        correctScoreTxt.text = "Correctas: " + value;
    }

    public void UpdateIncorrectScr(int value)
    {
        IncorrectScoreTxt.text = "Incorrectas: " + value;
    }
    #endregion

    #region Buttons

    public void SetColorToRight(ButtonController button)
    {
        button.SetColor(rightColor);
    }

    public void SetColorToWrong(ButtonController button)
    {
        button.SetColor(wrongColor);
    }

    public void ShowAllButtons(CanvasGroup[] groups)
    {
        foreach(CanvasGroup c in groups)
        {
            if(c.alpha < 1)
                StartCoroutine(FadeIn(c));
        }
    }

    public void HideAllButtons(CanvasGroup[] groups)
    {
        foreach (CanvasGroup c in groups)
        {
            if(c.alpha > 0.1)
                StartCoroutine(FadeOut(c));
        }
    }

    public void ResetButonsColor(ButtonController[] buttons)
    {
        foreach(ButtonController btn in buttons)
        {
            btn.SetColor(defaultColor);
        }
    }

    public void FadeIn(ButtonController button)
    {
        StartCoroutine(FadeIn(button.btnCanvasGroup));
    }
    public void FadeOut(ButtonController button)
    {
        StartCoroutine(FadeOut(button.btnCanvasGroup));
    }
    #endregion
}
