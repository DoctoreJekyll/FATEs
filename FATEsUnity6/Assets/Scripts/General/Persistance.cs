using System;
using UnityEngine;

public class Persistance : MonoBehaviour
{
    
    public static Persistance Instance {get; private set;}

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.M))
        {
            DeleteAllPrefs();
        }
        #endif
    }

    public void SaveDataPrefsInteger(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }

    public int LoadDataPrefsInteger(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

    public void ResetDataPrefsInteger(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }

    private void DeleteAllPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("DELETE ALL!");
    }
}
