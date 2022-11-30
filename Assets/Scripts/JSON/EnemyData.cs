using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public float[] position;

    public EnemyData(Eanemy eanmeny)
    {
        position = new float[2];
        position[0] = eanmeny.transform.position.x;
        position[1] = eanmeny.transform.position.y;
    }
}
