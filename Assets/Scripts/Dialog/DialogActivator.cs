using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Fungus;

public class DialogActivator : MonoBehaviour
{
    // Dialogin tekstit tallennetaan taulukkoon 
    public string[] lines;

    // Lippu, joka kertoo onko pelihahmo NPC-hamon alueella
    private bool canActivate; // true = on alueella

    // Lippu, joka kertoo onko NPC-hahmolla nimi eli onko kyseess‰ hahmo vai esim. kyltti 
    public bool isPerson = false; // false = NPC-hahmolla on nimi

    // Lippu joka kertoo onko dialogi aloitettu
    private bool dialogActivate;

    // Lippu, joka kertoo onko kyseess‰ QuestTrigger
    public bool isQuest;
    // Refrenssi QuestManageriin
    private QuestManager questManager;
    // Teht‰v‰numero
    public int questNumber;

    // Fungus-dialogi
    public Flowchart flowchart;

    private void Start()
    {
        // Luodaan yhteys QuestManageriin
        questManager = FindObjectOfType<QuestManager>();
    }

    // Update-metodi aukaisee dialogin tarvittaessa 
    void Update()
    {
        // Tutkitaan onko flowChart-objekti olemassa
        if (flowchart == null)
        {
            // ei ole
            return;
        }

        // Tutkitaan onko fungus-dialogi jo p‰‰ttynyt
        if (flowchart.GetBooleanVariable("DialogStop"))
        {
            // Kyll‰ on, joten vapautetaan pelihahmo
            GameManager.instance.dialogActive = false; // pit‰‰ olla false, jotta pelihahmo voi taas liikkua
            // Deaktivoidaan dialogi
            flowchart.gameObject.SetActive(false);
            canActivate = false;
        }

        // Onko pelihahmo dialogi alueella (canActive=true) ja
        // Onko hiiren vasenta korvaa napautettu ja dialogia ei ole viel‰ aloitettu?
        // if (canActivate && Input.GetButtonDown("Fire1") &&
        //     !DialogManager.instance.dialogBox.activeInHierarchy)
        if (canActivate)    // Dialogi n‰ytet‰‰n automaattisesti

        {
            // Kyll‰ on, pyydet‰‰n DialogManageria n‰ytt‰m‰‰n dialogi-ikkuna
            // DialogManager.instance.ShowDialog(lines, isPerson);

            // Informoidaan  GameManageria ett‰ dialogi on k‰ynniss‰ --> pelihahmo ei liiku
            GameManager.instance.dialogActive = true;
            // Aktivoidaan dialogi --> dialogi k‰ynnistyy automaattisesti 
            flowchart.gameObject.SetActive(true);

            // Nostetaan lippu merkiksi, ett‰ dialogi k‰ynnistetty (isTriggerExit-metodi)
            dialogActivate = true;
        }
    }
    // Metodi suoritetaan kun pelihahmo tulee tarpeeksi l‰helle NPC-kohdetta (esim. susi)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Onko pelihahmo alueella?
        if (collision.CompareTag("Player"))
        {
            // On, joten nostetaan merkkilippu.
            canActivate = true; // Update-funktiota varten 
        }
    }
    ///<summary>
    /// Metodi suoritetaan kun pelihahmo tulee alueelta pois.
    ///</summary>
    ///<param name="collision"</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Tuliko pelihahmo alueelta ulos?
        if (collision.CompareTag("Player"))
        {
            // Kyll‰ tuli, joten lasketaan merkkilippu.
            canActivate = false; // Update-funktiota varten

            // Olisiko kyseess‰ teht‰v‰?
            if (isQuest)
            {
                // Aloittaa teht‰v‰n ja n‰ytt‰‰ aloitustekstit
                StartQuest();
            }

            // Onko dialogi varmasti aloitettu?
            if (dialogActivate)
            {
                // On aloitettu, joten kohde katoaa
                gameObject.SetActive(false);
            }
        }
    }
    ///<summary>
    /// Pyyt‰‰ QuestManageria aktivoimaan teht‰v‰n aloitustekstit ja aktivoimaan teht‰v‰n
    /// </summary>
    void StartQuest()
    {
        // Pyyt‰‰ QuestManageria aktivoimaan teht‰v‰n ja n‰ytt‰m‰‰n aloitustekstit
        questManager.quests[questNumber].gameObject.SetActive(true);
        questManager.quests[questNumber].StartQuest();

        GameObject.FindGameObjectsWithTag("item");

        // Poistaa DialogActivatorin
        gameObject.SetActive(false);
    }

}