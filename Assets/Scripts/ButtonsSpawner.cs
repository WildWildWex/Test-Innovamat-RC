using UnityEngine;

public class ButtonsSpawner : MonoBehaviour
{
    public GameObject buttonPrefab;
    [Tooltip("This will act as a parent to all the instantiated prefabs")]
    public Transform numbersParent;
    public ButtonController[] buttonControllers;
    public CanvasGroup[] canvasGroups;
    private int rightNumberInArray;


    public void InitializeAllButtons()
    {
        // Assign values
        for(int i = 0; i < buttonControllers.Length; i++)
        {
            buttonControllers[i] = Instantiate(buttonPrefab, numbersParent).GetComponent<ButtonController>();
            canvasGroups[i] = buttonControllers[i].GetComponent<CanvasGroup>();
            canvasGroups[i].interactable = false;
        }
    }


    public void SetRightNumberInArray(int nmbr)
    {
        rightNumberInArray = nmbr;
    }

    public ButtonController GetRightButtonInArray()
    {
        return buttonControllers[rightNumberInArray];
    }


    #region Buttons Interactivity

    public void SetButtonsInactive()
    {
        foreach(CanvasGroup c in canvasGroups)
        {
            c.interactable = false;
        }
    }

    public void SetButtonsActive()
    {
        foreach (CanvasGroup c in canvasGroups)
        {
            if(c.alpha > 0.5)
                c.interactable = true;
        }
    }

    public void SetOtherButtonsActive(ButtonController exception)
    {
        for(int i = 0; i < buttonControllers.Length; i++)
        {
            if(buttonControllers[i] != exception)
            {
                buttonControllers[i].btnCanvasGroup.interactable = true;
            }
        }
    }
    #endregion
}
