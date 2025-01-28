using TMPro;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{

    [Header("Components")]
    [SerializeField] private Axe axe;
    [SerializeField] private Mine mine;
    [SerializeField] private ColectItems colectItems;
    
    [Header("UI Elements")]
    [SerializeField] private TMP_Text upgradeAxeText;
    [SerializeField] private TMP_Text upgradeMineText;
    [SerializeField] private TMP_Text upgradeBagText;

    [SerializeField] private TMP_Text axeTxt;
    [SerializeField] private TMP_Text mineTxt;
    [SerializeField] private TMP_Text passValuesTxt;
    
    private Shop shop;


    private void Start()
    {
        shop = GetComponent<Shop>();
        
        SetPassWordTxtValues();
    }

    private void Update()
    {
        SetActualTxtItemsShopValues();
        SetActualTxtItemsStatValues();
    }


    //TODO: Actualizar estos metodos y otros metodos de textos en los botones para que se actualice en ciertos momentos y no en cada frame
    private void SetActualTxtItemsStatValues()
    {
        axeTxt.text = axe.GetWoodThatCanCut() + " WOOD PER HIT";
        mineTxt.text = mine.GetGoldDrop() + " GOLD PER CHARGE";
    }

    private void SetActualTxtItemsShopValues()
    {
        upgradeAxeText.text = $"Wood : {shop.GetWoodForUpgradeAxe()}   Gold : {shop.GetGoldForUpgradeAxe()}";
        upgradeMineText.text = $"Wood : {shop.GetWoodForUpgradeMine()}   Gold : {shop.GetGoldForUpgradeMine()}";
        upgradeBagText.text = $"Wood : {shop.GetWoodForUpgradeCoc()}   Gold : {shop.GetGoldForUpgradeCoc()}";
    }

    private void SetPassWordTxtValues()
    {
        passValuesTxt.text = $"Wood : {shop.GetWoodForPass()}   Gold : {shop.GetGoldForPass()}";;
    }
    
}
