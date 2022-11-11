using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Player : MonoBehaviour
{
    // SIngelton
    private static Player instance;

    // Pelihahmon tilatiedot
    [SerializeField] private int health;
    [SerializeField] private int level;
    // Jalokivistä saadut psteet
    private int gemit;

    // Ominaisuudet (properties), vain get
    public int Health { get => health; }
    public int Level { get => level; }
    public static Player Instance
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
    // Ominaisuudet (properties), set ja get
    public int Gemit { get => gemit; set => gemit = value; }

    // Referenssi pelihahmon inventoriin
    [SerializeField] private TMP_Text playerNickname;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        LoadPlayerDataFromJSON();
    }

    private void LoadPlayerDataFromJSON()
    {
        PlayerData playerData = DataManager.LoadPlayerDataFromJSON();

        // Päivitetään playerData oliota saadut pelihahmon tilatiedot
        health = playerData.health;
        level = playerData.level;

        Vector3 position = new Vector3()
        {
            x = playerData.position[0],
            y = playerData.position[1],
            z = playerData.position[2]
        };
        // Sijoittaa pelihahmon JSON tiedostossa olevien x,y,z arvojen kertomaan paikkaan
        transform.position = position;

        // Jalokivien määrä
        gemit = playerData.gemScore;

    }

    // Tallennetaan pelihahmon tilatiedot ja JSON tiedostoksi
    public void SavePlayerDataToJSON()
    {
        print("Tallennus käynnissä...");
        DataManager.SavePlayerDataToJSON(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Törmättiinkö inventoriin siirrettävään esineeseen?
       /* if (other.CompareTag("Pickup"))
        {
            PickUp item = other.GetComponent<PickUp>();
            inventoryManager.Add(item);
            Destroy(other.gameObject);
        }*/
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) SavePlayerDataToJSON();
    }
}
