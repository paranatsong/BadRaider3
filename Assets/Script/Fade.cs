using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image DialogueBox;
    public Text  text;
    void Start()
    {
        DialogueBox.canvasRenderer.SetAlpha(1.0f);
        text.canvasRenderer.SetAlpha(1.0f);
        fadeout();
    }

    void fadeout()
    {
        DialogueBox.CrossFadeAlpha(0, 5, false);  
        text.CrossFadeAlpha(0, 5, false);
    }
}
