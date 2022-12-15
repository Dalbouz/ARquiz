using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageChange : MonoBehaviour
{

    public string Croatian;
    public string English;
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }
    private void OnEnable()
    {
        UIManager.Instance.onLanguageChange += OnLanguageChange;
    }

    private void OnLanguageChange()
    {
        if(UIManager.Instance.chosenLanguage == UIManager.ChosenLanguage.CROATIAN)
        {
            text.text = Croatian;
        }
        else if(UIManager.Instance.chosenLanguage == UIManager.ChosenLanguage.ENGLISH)
        {
            text.text = English;
        }
    }
}
