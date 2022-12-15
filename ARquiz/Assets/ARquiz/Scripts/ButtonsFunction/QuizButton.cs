using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuizButton : ButtonClick
{
    public override void Click()
    {
        SceneManager.LoadScene("Kviz");
    }
}
