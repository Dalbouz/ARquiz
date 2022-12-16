using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : ButtonClick
{
    public int id;
    public override void Click()
    {
        Button.interactable = false;
        if (QuizManager.Instance.CurrentActiveTemp.CorrectAnser == id)
        {
            QuizManager.Instance.CorrectAnswered++;
            Debug.Log(QuizManager.Instance.CorrectAnswered);
        }
        QuizManager.Instance.NextQuestion();
    }
}
