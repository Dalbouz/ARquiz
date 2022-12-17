using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTxt : LanguageChange
{
    public override void SetText()
    {
        if (UIManager.Instance.chosenLanguage == UIManager.ChosenLanguage.CROATIAN)
        {
            _tmpText.text = Croatian + " " + QuizManager.Instance.CorrectAnswered;
        }
        else if (UIManager.Instance.chosenLanguage == UIManager.ChosenLanguage.ENGLISH)
        {
            _tmpText.text = English + " " + QuizManager.Instance.CorrectAnswered;
        }
    }
}
