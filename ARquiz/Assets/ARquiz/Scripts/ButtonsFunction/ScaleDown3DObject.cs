using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ScaleDown3DObject : ButtonPressAndRelease
{
    public override void OnPointerUp(PointerEventData eventData)
    {
        RotateManager.IsObjectScaleDown = false;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        RotateManager.IsObjectScaleDown = true;
    }
}
