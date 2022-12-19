using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : ButtonClick
{
    public override void Click()
    {
        SceneManager.LoadScene(StringConst.MainMenuTxt);
        Button.interactable = false;
    }
}
