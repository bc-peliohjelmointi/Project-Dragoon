using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class Player : MonoBehaviour
{
    private static Player instance;

    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError(message: "Player on tyhj�!");
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (BattleSystem.isDead)
        {
            LoadPlayerDataFromJSON();
        }
    }
    public void LoadPlayerDataFromJSON()
    {
        PlayerData playerData = DataManager.LoadPlayerDataFromJSON();
        Vector2 position = new Vector2()
        {
            x = playerData.position[0],
            y = playerData.position[1],
        };
        transform.position = position;
    }
    public void SavePlayerDataToJSON()
    {
        Debug.Log(message: "Toimii");
        DataManager.SavePlayerDataToJSON(this);
    }
}
