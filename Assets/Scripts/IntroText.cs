using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroText : MonoBehaviour
{
    public Text textgame;
    private const string textfrase = "Play on the keyboard!";

    private IEnumerator PrintText()
    {
        foreach (char caracter in textfrase)
        {
			textgame.text += caracter;
            yield return new WaitForSeconds(0.07f);
        }
    }
}