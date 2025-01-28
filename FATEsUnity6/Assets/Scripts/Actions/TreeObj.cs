using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TreeObj : MonoBehaviour, IActions
{

    private int woodDrop;

    [SerializeField] private Transform dropPosition;
    [SerializeField] private GameObject woodDropPrefab;
    [SerializeField] private AudioSource audioSource;

    private GameObject woodGameObject;
    private WoodItem woodItem;
    
    private bool itemAlreadyDropped;
    private Animator animator;


    public bool ItemAlreadyDropped()
    {
        return itemAlreadyDropped;
    }
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Action()
    {
        CreateItem();
        animator.Play("treeanim");
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void Drop(int quantity)
    {
        woodDrop += quantity;
        woodItem = woodGameObject.GetComponent<WoodItem>();
        woodItem.RunWoodAnimation();
        woodItem.SetTotalAmountToDrop(woodDrop);
    }
    

    private void CreateItem()
    {
        if (!itemAlreadyDropped)
        {
            woodGameObject = Instantiate(woodDropPrefab, dropPosition.position, quaternion.identity);
            itemAlreadyDropped = true;
        }
    }

    public void ResetItem()
    {
        itemAlreadyDropped = false;
        woodDrop = 0;
    }
    
}
