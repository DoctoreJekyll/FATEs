using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TxtPanel : MonoBehaviour
{

    [Header("UI Components")]
    [SerializeField] private TMP_Text textComponent;
    [SerializeField] private String[] texts;
    [SerializeField] private float textSpeed;

    [FormerlySerializedAs("Animator")]
    [Header("animator Components")] 
    [SerializeField] private Animator animator;
    [SerializeField] private String animName;

    private int index;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = String.Empty;
        index = 0;
        StartCoroutine(DisplayLine());
    }
    

    private IEnumerator DisplayLine()
    {
        foreach (var c in texts[index].ToCharArray())
        {
            textComponent.text += c;
            animator.SetBool(animName, true);
            yield return new WaitForSeconds(textSpeed);
        }
        
        animator.SetBool(animName, false);
    }

    public void NextLineButton()
    {
        if (textComponent.text == texts[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = texts[index];
        }
    }
    
    private void NextLine()
    {
        if (index < texts.Length -1)
        {
            index++;
            textComponent.text = String.Empty;
            StartCoroutine(DisplayLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    
}
