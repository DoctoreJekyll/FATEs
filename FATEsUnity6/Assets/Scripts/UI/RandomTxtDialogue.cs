using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomTxtDialogue : MonoBehaviour
{
    
    [Header("UI Components")]
    [SerializeField] private TMP_Text textComponent;
    [SerializeField] private String[] texts;
    [SerializeField] private float textSpeed;
    
    [Header("animator Components")] 
    [SerializeField] private Animator animator;
    [SerializeField] private String animName;

    private int index;
    
    private void OnEnable()
    {
        textComponent.text = String.Empty;
        index = Random.Range(0, texts.Length);
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
}
