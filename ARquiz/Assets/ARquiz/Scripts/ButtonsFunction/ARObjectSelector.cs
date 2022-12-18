using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARObjectSelector : ButtonClick
{
    public int Id;
    public Sprite SelectedImg;
    public Sprite DeselectedImage;
    public override void Click()
    {
        ARCursor.Instance.ObjectToPlaceID = Id;
        this.Button.image.sprite = SelectedImg;
        CurrActiveObjManager.Instance.ButtonChange(DeselectedImage, this.Button);
    }
}
