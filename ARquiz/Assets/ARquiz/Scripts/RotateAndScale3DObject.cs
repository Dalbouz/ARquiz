using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndScale3DObject : MonoBehaviour
{
    public float SpeedRotationInDeg=50f;
    public float ScaleSpeed = 1f;
    public bool IsObjectRotatingLeft;
    public bool IsObjectRotatingRight;
    public bool IsObjectScaleUp;
    public bool IsObjectScaleDown;
    public Vector3 MaxScaleValue;
    public Vector3 MinScaleValue;
    

    void Update()
    {
        if (IsObjectRotatingLeft)
        {
            ARCursor.Instance.CurrentSpawn.transform.Rotate(0, Time.deltaTime * SpeedRotationInDeg, 0);
        }
        if (IsObjectRotatingRight)
        {
            ARCursor.Instance.CurrentSpawn.transform.Rotate(0, Time.deltaTime * -SpeedRotationInDeg, 0);
        }
        if (IsObjectScaleUp)
        {
            ARCursor.Instance.CurrentSpawn.transform.localScale = Vector3.Lerp(ARCursor.Instance.CurrentSpawn.transform.localScale, MaxScaleValue, ScaleSpeed * Time.deltaTime);
        }
        if (IsObjectScaleDown)
        {
            ARCursor.Instance.CurrentSpawn.transform.localScale = Vector3.Lerp(ARCursor.Instance.CurrentSpawn.transform.localScale, MinScaleValue, ScaleSpeed * Time.deltaTime);
        }
    }
}
