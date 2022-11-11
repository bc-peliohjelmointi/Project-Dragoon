using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public static class DataManager
{
    // Tallentaa tilatiedot JSON tiedostoksi
    public static void SavePlayerDataToJSON(Player player)
    {
        // Luodaan playerData olio
        PlayerData playerData = new PlayerData(player);

        // Mudostetaan tilatiedoista JSON
        string json = JsonUtility.ToJson(playerData);

        // Talletetaan JSON tiedostoon
        File.WriteAllText($"{Application.dataPath} /playerData.json", json);

        // Hakee tilatiedot JSON tiedostosta
    }
    public static PlayerData LoadPlayerDataFromJSON()
    {
        // Ladataan Json tiedosto
        string json = File.ReadAllText($"{Application.dataPath}/playerData.json");
        // Sijoitetaan JSONin sisältämätlä tilatiedoston playerData olioon
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
        // Palautetaan playerData olio
        return playerData;
    }
}

