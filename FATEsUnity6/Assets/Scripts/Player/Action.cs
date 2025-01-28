using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField]
    private IActions actions;
    
    private Axe axe;

    private bool isOnTree;
    private bool isOnMine;
    
    private Animator animations;
    
    private void Start()
    {
        axe = GetComponentInParent<Axe>();
        animations = GetComponentInParent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        actions = other.gameObject.GetComponent<IActions>();

        if (other.gameObject.CompareTag("Tree"))
        {
            isOnTree = true;
            isOnMine = false;
        }

        if (other.gameObject.CompareTag("Mine"))
        {
            isOnMine = true;
            isOnTree = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        actions = null;
        
        isOnMine = false;
        isOnTree = false;
    }

    public void DoAnimation()
    {
        if (isOnTree)
        {
            animations.SetTrigger("Axe");
        }
        else if (isOnMine)
        {
            animations.SetTrigger("Mine");    
        }
        else if (!isOnMine && !isOnTree && actions != null)
        {
            actions.Action();
        }
    }

    public void PushAction()
    {
        actions.Action();
        actions.Drop(axe.GetWoodThatCanCut());
    }
}
