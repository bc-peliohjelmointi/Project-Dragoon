using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    // Talletettavat tilatiedot
    public float[] position;
    public int health;
    public int level;
    public int gemScore;

    // Tämä on muodostin(constructor). Se alustaa luokan muuttujat
    public PlayerData(Player player)
    {
        health = player.Health;
        level = player.Level;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }

}
