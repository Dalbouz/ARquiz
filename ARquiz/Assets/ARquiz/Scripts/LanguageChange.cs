using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class LanguageChange : MonoBehaviour
{

    public string Croatian;
    public string English;
    protected TextMeshProUGUI _tmpText;
    private void Awake()
    {
        _tmpText = GetComponent<TextMeshProUGUI>();
    
    }
    private void Start()
    {
        UIManager.Instance.onLanguageChange += OnLanguageChange;
        OnLanguageChange();
    }

    private void OnDestroy()
    {
        UIManager.Instance.onLanguageChange -= OnLanguageChange;
    }
    public virtual void OnLanguageChange()
    {
        if(UIManager.Instance.chosenLanguage == UIManager.ChosenLanguage.CROATIAN)
        {
            _tmpText.text = Croatian;
        }
        else if(UIManager.Instance.chosenLanguage == UIManager.ChosenLanguage.ENGLISH)
        {
            _tmpText.text = English;
        }
    }
}
