using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public static class DataManager
{
    public static void SavePlayerDataToJSON(Player player)
    {
        PlayerData playerData = new PlayerData(player);
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText($"{Application.dataPath}/playerData.json", json);
    }
    public static void SaveEanemyDataToJSON(Eanemy eanemy)
    {
        EnemyData enemyData = new EnemyData(eanemy);
        string json = JsonUtility.ToJson(enemyData);
        File.WriteAllText($"{Application.dataPath}/EnemyData.json", json);
    }
    public static PlayerData LoadPlayerDataFromJSON()
    {
        string json = File.ReadAllText($"{Application.dataPath}/playerData.json");
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
        return playerData;
    }
    public static EnemyData LoadEnemyDataFromJSON()
    {
        string json = File.ReadAllText($"{Application.dataPath}/EnemyData.json");
        EnemyData enemyData = JsonUtility.FromJson<EnemyData>(json);
        return enemyData;
    }
}
