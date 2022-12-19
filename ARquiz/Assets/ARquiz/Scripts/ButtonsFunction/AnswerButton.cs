using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : ButtonClick
{
    public int id;
    public int PositionInParent = 0;
    public override void Click()
    {
        if (QuizManager.Instance.CurrentActiveTemp.CorrectAnser == id)
        {
            QuizManager.Instance.CorrectAnswered++;
            Debug.Log(QuizManager.Instance.CorrectAnswered);
        }
        QuizManager.Instance.NextQuestion();
    }
}
