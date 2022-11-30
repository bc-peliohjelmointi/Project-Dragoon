using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class Eanemy : MonoBehaviour
{
    private static Eanemy instance;

    public static Eanemy Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError(message: "Player on tyhjä!");
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
            LoadEanemyDataFromJSON();
            BattleSystem.isDead = false;
        }
    }
    private void LoadEanemyDataFromJSON()
    {
        EnemyData enemyData = DataManager.LoadEnemyDataFromJSON();
        Vector2 position = new Vector2()
        {
            x = enemyData.position[0],
            y = enemyData.position[1],
        };
        transform.position = position;
    }
    public void SaveEanemyDataToJSON()
    {
        Debug.Log(message: "Toimii");
        DataManager.SaveEanemyDataToJSON(this);
    }
}
