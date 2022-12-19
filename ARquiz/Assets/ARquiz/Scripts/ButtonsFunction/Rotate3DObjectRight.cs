using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotate3DObjectRight : ButtonPressAndRelease
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        RotateManager.IsObjectRotatingRight = true;
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        RotateManager.IsObjectRotatingRight = false;
    }
}
