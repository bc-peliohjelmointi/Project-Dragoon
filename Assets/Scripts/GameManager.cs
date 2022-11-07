using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Luokka liitet‰‰n saman nimisen GameObjectiin.
/// T‰m‰ luokka est‰‰ pelihahmon liikkumisen silloin, kun pelihahmo on dialogissa jonkun kanssa.
/// </summary>
public class GameManager : MonoBehaviour
{
    // Sallitaan vain yksi GameManager
    public static GameManager instance;

    // Lippu, joka kertoo onko dialogi k‰yniss‰. T‰t‰ k‰ytt‰‰ mm. DialogiManager-Luokka
    public bool dialogActive;

    // Use this for initialization
    void Start()
    {
        // Onko GameManager jo olemassa?
        if (instance == null)
        {
            // Ei ole, joten luodaan GameManager
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Onko dialogi aktiivinen? tieto tulee GameManagerilta
        if (dialogActive)
        {
            // DialogManagerin mukaan on, joten sallitaan pelihahmon liikkuminen
            PlayerController.instance.canMove = false;
        }
        else
        {
            // DialogManagerin mukaan ei, joten sallitaan pelihahmon liikkuminen
            PlayerController.instance.canMove = true;

        }
    }
}
