using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenCloseSettings : ButtonClick
{
    public GameObject SettingsPanel;
    public List<Button> ButtonsToDisable;

    public override void Click()
    {
        if (SettingsPanel.activeSelf == false)
        {
            foreach (Button button in ButtonsToDisable)
            {
                button.interactable = false;
            }
            SettingsPanel.SetActive(true);
        }
        else
        {
            foreach (Button button in ButtonsToDisable)
            {
                button.interactable = true;
            }
            SettingsPanel.SetActive(false);
        }
    }
}
