using UnityEngine;
using UnityEngine.UI;


public class ButtonController : MonoBehaviour
{
    public Text text;
    public Image btnImage;
    public int value;
    public CanvasGroup btnCanvasGroup;

    private void Start()
    {
        btnCanvasGroup = GetComponent<CanvasGroup>();
    }

    public void SetColor(Color col)
    {
        btnImage.color = col;
    }

    public void Initialize(int val)
    {
        value = val;
        text.text = value.ToString();
    }

    public void Clicked()
    {
        GameFacade.instance.CheckAnswer(value, this);
    }
}
