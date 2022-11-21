using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    // Teht‰v‰numero 
    public int questNumber;

    // Alotus- ja lopetustekstit
    public string[] lines;

    // Refrenssi QuestManager-luokkaan
    public QuestManager questManager;

    // Lippu, joka kertoo onko kyseess‰ ker‰tyteht‰v‰
    public bool isItemQuest;

    // Ker‰tt‰v‰n esineen nimi
    public string targetItem;
    // Ker‰tt‰vien esineiden lukum‰‰r‰
    public int itemCollect;
    // Laskuri, joka laskee ker‰tyt esineet
    public int itemCollectCount;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        // Ker‰ysteht‰v‰?
        if (isItemQuest)
        {
            // Kyll‰ on, joten tarkistetaan QuestManagerilta onko se tietoinen ker‰yksen kohteesta 
            if (questManager.itemCollected == targetItem)
            {
                // Kyll‰ on, joten kasvatetaan esinelaskuria
                questManager.itemCollected = null;
                // Kasvatetaan laskuri
                itemCollectCount++;
            }
            // Onko esineit‰ ker‰tty tarpeeksi?
            if (itemCollectCount >= itemCollect)
            {
                // Kyll‰ on, joten teht‰v‰ p‰‰ttyy
                EndQuest();
            }
        }

    }
    /// <summary>
    ///Teht‰v‰ aloitustekstit
    /// </summary>
    public void StartQuest()
    {
        // Pyydet‰‰n QuestManageria n‰ytt‰m‰‰n aloitusteksti
        questManager.ShowQuestText(lines[0]);
    }

    /// <summary>
    /// Teht‰v‰n lopetustekstit, jonka j‰lkeen QuestManager merkkaa teht‰v‰n suoritetuksi 
    /// </summary>
    public void EndQuest()
    {
        // Pyydet‰‰n QuestManageria n‰ytt‰m‰‰n lopputeksti
        questManager.ShowQuestText(lines[1]);
        // Pyydet‰‰n QuestManageria merkkaamaan teht‰v‰ suoritetuksi
        questManager.questCompleted[questNumber] = true;
        // Deaktivoidaan teht‰v‰ kun se on tehty
        gameObject.SetActive(false);
    }
}