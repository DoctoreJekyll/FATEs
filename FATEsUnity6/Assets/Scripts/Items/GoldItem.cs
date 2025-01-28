using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldItem : MonoBehaviour
{

    [SerializeField]
    private int goldItemValue;
    
    public void SetTotalAmount(int i)
    {
        goldItemValue = i;
    }

    public int GetGoldValue()
    {
        return goldItemValue;
    }
}
