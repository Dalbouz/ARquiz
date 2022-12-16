using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : ButtonClick
{
    public int id;
    public override void Click()
    {
        if (QuizManager.Instance.CurrentActiveTemp.CorrectAnser == id)
        {
            QuizManager.Instance.CorrectAnswered++;
        }
        QuizManager.Instance.NextQuestion();
    }
}
