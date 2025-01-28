using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Vendor : MonoBehaviour, IActions
{

    private int woodStorage;
    private int goldStorage;
    
    [SerializeField] private ColectItems colectItems;
    [SerializeField] private AudioSource audioSource;
    
    //Temporal
    [FormerlySerializedAs("shopPanel")] [SerializeField] private GameObject dialoguePanel;
    
    public int GetWoodStorage() { return woodStorage; }
    public int GetGoldStorage() { return goldStorage; }

    private void Start()
    {
        woodStorage = PlayerPrefs.HasKey("woodStorage") ? Persistance.Instance.LoadDataPrefsInteger("woodStorage") : 0;
        goldStorage = PlayerPrefs.HasKey("goldStorage") ? Persistance.Instance.LoadDataPrefsInteger("goldStorage") : 0;
    }
    

    public void Gift()
    {
        woodStorage += 500;
        goldStorage += 500;
    }

    private void CollectFromBag()
    {
        woodStorage += colectItems.GetWoodOnBag();
        goldStorage += colectItems.GetGoldOnBag();
        UpdateDataPersistance();
        PlaySoundCollect();
        colectItems.ResetBag();
    }

    public void UpdateItemsOfBagWhenBuy(int wood, int gold)
    {
        woodStorage -= wood;
        goldStorage -= gold;
        UpdateDataPersistance();
    }

    private void UpdateDataPersistance()
    {
        Persistance.Instance.SaveDataPrefsInteger("woodStorage", woodStorage);
        Persistance.Instance.SaveDataPrefsInteger("goldStorage", goldStorage);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollectFromBag();
        }
    }

    private void PlaySoundCollect()
    {
        if (colectItems.GetWoodOnBag() != 0 || colectItems.GetGoldOnBag() != 0)
        {
            audioSource.PlayOneShot(audioSource.clip);
            Debug.Log("Sonidito coger cosas");
        }
    }

    public void Action()
    {
        dialoguePanel.SetActive(true);
    }

    public void Drop(int quantity)
    {
        
    }
}
