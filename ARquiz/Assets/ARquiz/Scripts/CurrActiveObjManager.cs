using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrActiveObjManager : MonoBehaviour
{
    private static CurrActiveObjManager _instance;
    public static CurrActiveObjManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private Sprite _lastSelectedImage;
    private Button _currentActiveButton;
    public ARObjectSelector FirstSelecterdObject;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }
    private void Start()
    {
        FirstSelecterdObject.Button.image.sprite = FirstSelecterdObject.SelectedImg;
        _lastSelectedImage = FirstSelecterdObject.DeselectedImage;
        _currentActiveButton = FirstSelecterdObject.Button;
    }

    public void ButtonChange(Sprite newSelecedImage, Button newButton)
    {
        _currentActiveButton.image.sprite = _lastSelectedImage;
        _lastSelectedImage = newSelecedImage;
        _currentActiveButton = newButton;
    }
}
