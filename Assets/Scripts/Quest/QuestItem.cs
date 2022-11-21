using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Luokka liitetään kerättävän esineenseen
/// </summary>
public class QuestItem : MonoBehaviour
{
    // Tehtävänumero
    public int questNumber;

    // Refrenssi QuestManageriin
    private QuestManager questManager;

    // esineen nimi
    public string itemName;

    // Start is called before the first frame update
    void Start()
    {
        // Luodaan yhteys QuestManageriin, jotta voidaan käyttää sen metodeja
        questManager = FindObjectOfType<QuestManager>();

    }
    /// <summary>
    /// Metodi pyytää QuestManageria merkkaan keräystehtävän suoritetuksi.
    /// Metodi suoritetaan kun pelihahmo osuu esineeseen.
    /// Metodiin voidaan koodata muita esineeseen liittyviä toimintoja, kuten ansaitut EXP-pisteet
    /// </summary>
    /// <param name="collision""></param>

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Osuiko pelihahmo esineeseen?
        if (collision.CompareTag("Player"))
        {
            // Kyllä, joten tarkistetaan ettei tehtävää ole vielä tehty?
            if (!questManager.questCompleted[questNumber] &&
                questManager.quests[questNumber].gameObject.activeSelf)
            {
                // Ei ole, joten kerrotaan QuestManagerille esineen nimi
                questManager.itemCollected = itemName;

                // Deaktivoidaan esine
                gameObject.SetActive(false);

                // Ansaitut kullat tai EXP-pisteet koodataan tähän

                // Tehdäänkö esineelle jotain? ehkä siirto inventoriin, tai otetaan se käyttöön, vai mitä??

                // Myös ääniefekti koodataan tähän
            }
        }
    }
}
