using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodItem : MonoBehaviour
{
    private static readonly int Axing = Animator.StringToHash("Axing");

    [SerializeField]
    private int totalDrop;

    private Animator animator;

    private bool patchAnimDropped;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(PatchAnimation());
    }

    IEnumerator PatchAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        patchAnimDropped = true;
    }

    public void RunWoodAnimation()
    {
        if (patchAnimDropped)
        {
            animator.SetTrigger(Axing);
        }
        
    }

    public void SetTotalAmountToDrop(int i)
    {
        totalDrop = i;
    }

    public int GetTotalDrop()
    {
        return totalDrop;
    }
}
