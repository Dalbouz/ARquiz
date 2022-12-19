using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InfoButton : ButtonClick
{
    public override void Click()
    {
        SceneManager.LoadScene(StringConst.InfoScreenTxt);
    }
}
