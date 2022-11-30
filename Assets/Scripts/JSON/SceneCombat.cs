using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCombat : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        LoadEanemyDataFromJSON();
    }

    // Update is called once per frame
    void Update()
    {

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
}
