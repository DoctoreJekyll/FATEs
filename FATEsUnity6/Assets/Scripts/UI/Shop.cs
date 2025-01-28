using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Shop : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Axe axe;
    [SerializeField] private Mine mine;
    [SerializeField] private ColectItems colectItems;
    [FormerlySerializedAs("colectItems")] [SerializeField] private Vendor itemsOnStorage;


    [Header("Upgrade Axe Values")]
    [SerializeField] private int woodForUpgradeAxe;
    [SerializeField] private int goldForUpgradeAxe;

    private void Start()
    {
        LoadValuesForUpgradeAxe();
        LoadValuesForUpgradeMine();
        LoadValuesForUpgradeBag();
    }

    private void LoadValuesForUpgradeAxe()
    {
        if (!PlayerPrefs.HasKey("woodForUpgradeAxe") || !PlayerPrefs.HasKey("goldForUpgradeAxe")) return;
        
        woodForUpgradeAxe = Persistance.Instance.LoadDataPrefsInteger("woodForUpgradeAxe");
        goldForUpgradeAxe = Persistance.Instance.LoadDataPrefsInteger("goldForUpgradeAxe");
    }

    public int GetWoodForUpgradeAxe()
    {
        return woodForUpgradeAxe;
        
    }
    public int GetGoldForUpgradeAxe()
    {
        return goldForUpgradeAxe;
    }
    
    [Header("Upgrade Mine Values")]
    [SerializeField] private int woodForUpgradeMine;
    [SerializeField] private int goldForUpgradeMine;
    
    private void LoadValuesForUpgradeMine()
    {
        if (!PlayerPrefs.HasKey("woodForUpgradeMine") || !PlayerPrefs.HasKey("goldForUpgradeMine")) return;
        
        woodForUpgradeMine = Persistance.Instance.LoadDataPrefsInteger("woodForUpgradeMine");
        goldForUpgradeMine = Persistance.Instance.LoadDataPrefsInteger("goldForUpgradeMine");
    }

    public int GetWoodForUpgradeMine()
    {
        return woodForUpgradeMine;
    }
    public int GetGoldForUpgradeMine()
    {
        return goldForUpgradeMine;
    }
    
    [Header("Upgrade Bag Values")]
    [SerializeField] private int woodForUpgradeCoc;
    [SerializeField] private int goldForUpgradeCoc;
    
    private void LoadValuesForUpgradeBag()
    {
        if (!PlayerPrefs.HasKey("woodForUpgradeCoc") || !PlayerPrefs.HasKey("goldForUpgradeCoc")) return;
        
        woodForUpgradeCoc = Persistance.Instance.LoadDataPrefsInteger("woodForUpgradeCoc");
        goldForUpgradeCoc = Persistance.Instance.LoadDataPrefsInteger("goldForUpgradeCoc");
    }

    public int GetWoodForUpgradeCoc()
    {
        return woodForUpgradeCoc;
    }
    public int GetGoldForUpgradeCoc()
    {
        return goldForUpgradeCoc;
    }

    public void PurchaseUpgradeAxe()
    {
        Debug.Log("Purchasing Axe");
        if (woodForUpgradeAxe <= itemsOnStorage.GetWoodStorage() && goldForUpgradeAxe <= itemsOnStorage.GetGoldStorage())
        {
            itemsOnStorage.UpdateItemsOfBagWhenBuy(woodForUpgradeAxe, goldForUpgradeAxe);
            UpgradeAxe();
        }
    }

    public void PurchaseUpgradeMine()
    {
        Debug.Log("Purchasing Mine");
        if (woodForUpgradeMine <= itemsOnStorage.GetWoodStorage() && goldForUpgradeMine <= itemsOnStorage.GetGoldStorage())
        {
            itemsOnStorage.UpdateItemsOfBagWhenBuy(woodForUpgradeMine, goldForUpgradeMine);
            UpgradeMine();
        }
    }

    public void PurchaseUpgradeCoc()
    {
        Debug.Log("Purchasing Coc");
        if (woodForUpgradeCoc <= itemsOnStorage.GetWoodStorage() && goldForUpgradeCoc <= itemsOnStorage.GetGoldStorage())
        {
            itemsOnStorage.UpdateItemsOfBagWhenBuy(woodForUpgradeCoc, goldForUpgradeCoc);
            UpgradeColectItems();
        }
    }

    [Header("Password values")]
    [SerializeField] private int woodForPassword;
    [SerializeField] private int goldForPassword;
    [SerializeField] private GameObject passPanel;

    public int GetWoodForPass()
    {
        return woodForPassword;
    }

    public int GetGoldForPass()
    {
        return goldForPassword;
    }
    
    public void PurchasePassword()
    {
        if (woodForPassword <= itemsOnStorage.GetWoodStorage() && goldForPassword <= itemsOnStorage.GetGoldStorage())
        {
            passPanel.SetActive(true);
        }
    }
    
    private void UpgradeAxe()
    {
        // Aumenta la capacidad de corte de manera exponencial (ajusta el multiplicador según necesites)
        float upgradeFactor = 1.2f; // Incremento del 20% cada vez
        axe.SetWoodThatCanCut(Mathf.RoundToInt(axe.GetWoodThatCanCut() * upgradeFactor));
    
        // Incrementa los costos exponencialmente
        woodForUpgradeAxe = Mathf.RoundToInt(woodForUpgradeAxe * 1.25f); // Aumento del 50% por cada mejora
        goldForUpgradeAxe = Mathf.RoundToInt(goldForUpgradeAxe * 1.25f);
        
        Persistance.Instance.SaveDataPrefsInteger("woodForUpgradeAxe", woodForUpgradeAxe);
        Persistance.Instance.SaveDataPrefsInteger("goldForUpgradeAxe", goldForUpgradeAxe);
    }

    private void UpgradeMine()
    {
        float upgradeFactor = 1.5f;
        mine.SetGoldDrop(Mathf.RoundToInt(mine.GetGoldDrop() * upgradeFactor));
        
        woodForUpgradeMine = Mathf.RoundToInt(woodForUpgradeMine * 1.5f);
        goldForUpgradeMine = Mathf.RoundToInt(goldForUpgradeMine * 1.5f);
        
        Persistance.Instance.SaveDataPrefsInteger("woodForUpgradeMine", woodForUpgradeMine);
        Persistance.Instance.SaveDataPrefsInteger("goldForUpgradeMine", goldForUpgradeMine);
    }

    private void UpgradeColectItems()
    {
        colectItems.SetMaxItemsOnBag(colectItems.GetMaxWoodOnBag() + 100,colectItems.GetMaxGoldOnBag() + 100);
        woodForUpgradeCoc += 500;
        goldForUpgradeCoc += 500;
        
        Persistance.Instance.SaveDataPrefsInteger("woodForUpgradeCoc", woodForUpgradeCoc);
        Persistance.Instance.SaveDataPrefsInteger("goldForUpgradeCoc", goldForUpgradeCoc);
    }
    
}
