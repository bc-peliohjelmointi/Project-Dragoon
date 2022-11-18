using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string unitName;
    public int damage;
    public int MaxHP;
    public int CurrentHP;


    public bool TakeDamage(int dmg)
    {
        CurrentHP -= dmg;
        if (CurrentHP <= 0)
        {
            return true;
        }
        else
            return false;
    }

    public void Heal(int amount)
    {
        CurrentHP += amount;
        if (CurrentHP > MaxHP)
            CurrentHP = MaxHP;
    }
}

