using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ButtonPressAndRelease : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    public RotateAndScale3DObject RotateManager;
    public virtual void OnPointerDown(PointerEventData eventData)
    {
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
    }
}
