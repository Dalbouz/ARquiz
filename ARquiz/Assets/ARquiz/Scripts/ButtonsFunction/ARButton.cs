using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARButton : ButtonClick
{
    public override void Click()
    {
        SceneManager.LoadScene("AR");
    }
}
