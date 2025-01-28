using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAxis : MonoBehaviour
{


    [SerializeField]
    private float xValue;
    [SerializeField]
    private float yValue;
    

    public void SetValueX(float value)
    {
        xValue = value;
    }

    public void SetValueY(float value)
    {
        yValue = value;
    }
    
    public float GetX()
    {
        return xValue;
    }

    public float GetY()
    {
        return yValue;
    }
    
}
