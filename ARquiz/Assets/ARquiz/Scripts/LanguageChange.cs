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
        UIManager.Instance.onLanguageChange += SetText;
        SetText();
    }

    private void OnDestroy()
    {
        UIManager.Instance.onLanguageChange -= SetText;
    }
    public virtual void SetText()
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
