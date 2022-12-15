using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseSettings : ButtonClick
{
    public GameObject SettingsPanel;

    public override void Click()
    {
        if (SettingsPanel.activeSelf == false)
            SettingsPanel.SetActive(true);
        else
            SettingsPanel.SetActive(false);
    }
}
