using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public List<Text> Text;
    public LanguageUI languageUI;
    public event Action onLanguageChange;
    public enum ChosenLanguage { CROATIAN, ENGLISH}
    public ChosenLanguage chosenLanguage = ChosenLanguage.CROATIAN;

    private void Awake()
    {
        if (_instance != null)
            _instance = this;
        else Destroy(gameObject);
    }

    public void LanguageTriggerChange()
    {
        if (onLanguageChange != null)
            onLanguageChange();
    }
}
