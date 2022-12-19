using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ScaleUp3DObject : ButtonPressAndRelease
{
    public override void OnPointerUp(PointerEventData eventData)
    {
        RotateManager.IsObjectScaleUp = false;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        RotateManager.IsObjectScaleUp = true;
    }
}
