using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotate3DObjectLeft : ButtonPressAndRelease
{
    public override void OnPointerUp(PointerEventData eventData)
    {
        RotateManager.IsObjectRotatingLeft = false;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        RotateManager.IsObjectRotatingLeft = true;
    }
}
