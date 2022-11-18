using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Slider hpSlider;

    public void SetHUD(Enemy enemy)
    {
        nameText.text = enemy.unitName;
        hpSlider.maxValue = enemy.MaxHP;
        hpSlider.value = enemy.CurrentHP;
    }
    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }
}
