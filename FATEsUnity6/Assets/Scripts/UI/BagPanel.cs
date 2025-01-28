using TMPro;
using UnityEngine;

public class BagPanel : MonoBehaviour
{
    
    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text goldText;
    
    [SerializeField] private ColectItems colectItems;

    private void Update()
    {
        SetTxtGold();
        SetTxtWood();
    }
    
    private void SetTxtWood()
    {
        woodText.text = colectItems.GetWoodOnBag() + "/" + colectItems.GetMaxWoodOnBag();
    }

    private void SetTxtGold()
    {
        goldText.text = colectItems.GetGoldOnBag() + "/" + colectItems.GetMaxGoldOnBag();
    }
    
}
