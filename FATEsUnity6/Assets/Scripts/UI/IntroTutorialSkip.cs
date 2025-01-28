using System;
using UnityEngine;

public class IntroTutorialSkip : MonoBehaviour
{

    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject gamePanel;

    private int tutorialCount = 0;


    private void Start()
    {
        if (PlayerPrefs.HasKey("tutorialCount"))
        {
            tutorialCount = Persistance.Instance.LoadDataPrefsInteger("tutorialCount");
        }
    }

    public void ActivePanels()
    {
        if (tutorialCount == 0)
        {
            tutorialPanel.SetActive(true);
        }
        
        gamePanel.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        tutorialCount = 1;
        Persistance.Instance.SaveDataPrefsInteger("tutorialCount", tutorialCount);
    }
}
