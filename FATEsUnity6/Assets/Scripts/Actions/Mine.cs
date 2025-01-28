using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Mine : MonoBehaviour, IActions
{
    [SerializeField]
    private int goldDrop;

    [SerializeField] private Transform dropPosition;
    [SerializeField] private GameObject goldDropPrefab;
    [SerializeField] private AudioSource audioSource;
    
    private Animator animator;
    private bool isMining;

    private void Start()
    {
        animator = GetComponent<Animator>();

        if (PlayerPrefs.HasKey("goldDrop"))
        {
            goldDrop = Persistance.Instance.LoadDataPrefsInteger("goldDrop");
        }
    }

    public int GetGoldDrop()
    {
        return goldDrop;
    }

    public void SetGoldDrop(int amount)
    {
        goldDrop = amount;
        Persistance.Instance.SaveDataPrefsInteger("goldDrop", goldDrop);
    }
    
    public void Action()
    {
        if (!isMining)
        {
            StartCoroutine(ActivateMine());
        }
    }

    private IEnumerator ActivateMine()
    {
        isMining = true;
        audioSource.PlayOneShot(audioSource.clip);
        animator.Play("mineOn");
        yield return new WaitForSeconds(2f);
        animator.Play("mineOff");
        CreateItem();
        isMining = false;
        
    }

    public void Drop(int quantity)
    {
        
    }

    private Vector3 SpawnPosition()
    {
        Vector3 position = dropPosition.position;
        float offset = .25f;
        float xR = dropPosition.position.x + offset;
        float xL = dropPosition.position.x - offset;
        float yT = dropPosition.position.y + (offset - .1f);
        float yB = dropPosition.position.y - offset;
        
        Vector3 newPosition = new Vector3(Random.Range(xR, xL), Random.Range(yT, yB), position.z);
        return newPosition;
    }

    private void CreateItem()
    {
        GameObject goldGameObject = Instantiate(goldDropPrefab, SpawnPosition(), quaternion.identity);
        GoldItem goldItem = goldGameObject.GetComponent<GoldItem>();
        goldItem.SetTotalAmount(goldDrop);
    }
}
