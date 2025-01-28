using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{

    [SerializeField]
    private int woodThatCanCut;

    private void Start()
    {
        if (PlayerPrefs.HasKey("woodCanCut"))
        {
            woodThatCanCut = Persistance.Instance.LoadDataPrefsInteger("woodCanCut");
        }
    }

    public void SetWoodThatCanCut(int woodThatCanCutParam)
    {
        this.woodThatCanCut = woodThatCanCutParam;
        Persistance.Instance.SaveDataPrefsInteger("woodCanCut", woodThatCanCut);
    }

    public int GetWoodThatCanCut()
    {
        return this.woodThatCanCut;
    }
}
