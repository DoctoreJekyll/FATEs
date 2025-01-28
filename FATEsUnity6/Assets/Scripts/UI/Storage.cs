using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Storage : MonoBehaviour
{

    [SerializeField] private TMP_Text goldStorageTxt;
    [SerializeField] private TMP_Text woodStorageTxt;
    [SerializeField] private Vendor vendor;


    private void Update()
    {
        goldStorageTxt.text = vendor.GetGoldStorage().ToString();
        woodStorageTxt.text = vendor.GetWoodStorage().ToString();
    }
}
