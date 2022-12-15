using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonClick : MonoBehaviour
{
    public Button Button;

    protected void Start()
    {
        Button btn = Button.GetComponent<Button>();
        btn.onClick.AddListener(Click);
    }

    public virtual void Click()
    {

    }
}
