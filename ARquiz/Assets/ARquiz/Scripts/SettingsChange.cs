using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsChange : ButtonClick
{
   
    public override void Click()
    {
        UIManager.Instance.LanguageTriggerChange();
    }

}
