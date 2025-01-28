using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ColectItems : MonoBehaviour
{

    [SerializeField]
    private int woodOnBag;
    [SerializeField]
    private int goldOnBag;

    
    private int maxWoodOnBag;
    private int maxGoldOnBag;

    private readonly int valueMaxItems = 100;

    [SerializeField] private AudioClip audioClip;
    private AudioSource audioSource;

    public int GetWoodOnBag()
    {
        return woodOnBag;
    }

    public int GetGoldOnBag()
    {
        return goldOnBag;
    }

    public int GetMaxWoodOnBag()
    {
        return maxWoodOnBag;
    }

    public int GetMaxGoldOnBag()
    {
        return maxGoldOnBag;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        LoadMaxItemsOnBag();
        LoadItemsOnBag();
    }

    private void LoadMaxItemsOnBag()
    {
        if (PlayerPrefs.HasKey("maxWoodOnBag") && PlayerPrefs.HasKey("maxGoldOnBag"))
        {
            SetMaxItemsOnBag(Persistance.Instance.LoadDataPrefsInteger("maxWoodOnBag"), Persistance.Instance.LoadDataPrefsInteger("maxGoldOnBag"));
        }
        else
        {
            SetMaxItemsOnBag(valueMaxItems, valueMaxItems);
        }
    }

    private void LoadItemsOnBag()
    {
        if (PlayerPrefs.HasKey("woodOnBag"))
        {
            woodOnBag = Persistance.Instance.LoadDataPrefsInteger("woodOnBag");
        }

        if (PlayerPrefs.HasKey("goldOnBag"))
        {
            goldOnBag = Persistance.Instance.LoadDataPrefsInteger("goldOnBag");
        }
    }
    
    public void SetMaxItemsOnBag(int maxWood, int maxGold)
    {
        maxWoodOnBag = maxWood;
        maxGoldOnBag = maxGold;
        
        Persistance.Instance.SaveDataPrefsInteger("maxWoodOnBag", maxWoodOnBag);
        Persistance.Instance.SaveDataPrefsInteger("maxGoldOnBag", maxGoldOnBag);
    }

    public void UpdateItemsOfBag(int woodOnBagParam, int goldOnBagParam)
    {
        woodOnBag -= woodOnBagParam;
        goldOnBag -= goldOnBagParam;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wood"))
        {
            CollectWood(other);
            audioSource.PlayOneShot(audioClip);
        }

        if (other.gameObject.CompareTag("Gold"))
        {
            audioSource.PlayOneShot(audioClip);
            CollectGold(other);
        }
    }

    private void CheckMaximunWoodOnBag()
    {
        if (woodOnBag > maxWoodOnBag)
        {
            woodOnBag = maxWoodOnBag;
        }
    }

    private void CheckMaximunGoldOnBag()
    {
        if (goldOnBag > maxGoldOnBag)
        {
            goldOnBag = maxGoldOnBag;
        }
    }

    private void CollectGold(Collider2D other)
    {
        goldOnBag += other.gameObject.GetComponent<GoldItem>().GetGoldValue();
        CheckMaximunGoldOnBag();
        
        Persistance.Instance.SaveDataPrefsInteger("goldOnBag", goldOnBag);
        
        Destroy(other.gameObject);
    }

    private void CollectWood(Collider2D other)
    {
        woodOnBag += other.gameObject.GetComponent<WoodItem>().GetTotalDrop();
        CheckMaximunWoodOnBag();
        
        Persistance.Instance.SaveDataPrefsInteger("woodOnBag", woodOnBag);
        
        TreeObj treeObj = FindObjectOfType<TreeObj>();
        treeObj.ResetItem();
        Destroy(other.gameObject);
    }

    public void ResetBag()
    {
        woodOnBag = 0;
        goldOnBag = 0;
    }
}
