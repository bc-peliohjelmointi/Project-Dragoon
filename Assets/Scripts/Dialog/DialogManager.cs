using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

/// <summary>
/// N‰ytt‰‰ ja sulkee dialogin.
/// Luokka liitet‰‰n Canvakseen.
/// Luokka keskustelee GameManagerin kanssa.
/// </summary>
public class DialogManager : MonoBehaviour
{

    // UI-refrenssit
    public Text dialogText;         // dialogi teksti
    public Text nameText;           // Keskustelijan nimi
    public GameObject dialogBox;    // Dialogin rakenne
    public GameObject nameBox;      // Dialogin alla olevan nimialue (name box/Text)

    // Dialog-refrenssit
    private string[] dialogLines;       // Dialogin rivien lukum‰‰r‰
    private int currentline = 0;        // Rivi, jolla ollaan
    private bool justStarted;           // Merkkilippu, joka kertoo voidaanko keskustelua jatkaa 
    public float typingSpeed;           // Automaattikirjoituksen nopeus
    private bool isCoroutingRunning;    // Onko alirutiini k‰ynniss‰ 

    // Dialogi-instanssi
    public static DialogManager instance;

    // Use this for initialization
    void Start()
    {
        // onko DialogManager jo olemassa?
        if (instance == null)
        {
            // Ei ole, joten luodaan DialogManager-esiintym‰
            instance = this;
        }
    }

    /// <summary>
    /// Metodi k‰y dialogia l‰pi kun hiiren vasenta korvaa napautetaan
    /// </summary>
    void Update()
    {
        // Painettinko hiiren oikeaa korvaa ja tarkistetaan 
        // Ett‰ alirutiini ei ole k‰ynniss‰ (isCoroutingRunning=false)
        // Ja ett‰ keskustelua voidaan jatkaa (JustStarted=true)
        if (Input.GetButtonUp("Fire2") && !isCoroutingRunning && justStarted)
        {
            // Siirryt‰‰n suraavalle riville
            currentline++;
            // Onko dialogi jo p‰‰ttynyt?
            if (currentline >= dialogLines.Length)
            {
                // Dialogi on p‰‰ttynyt, joten suljetaan dialogi-ikkuna
                dialogBox.SetActive(false);
                // Lis‰ksi informoidaan GameManageria ett‰ dialogi
                // P‰‰ttyyi (pelihahmon voi taas liikkua)
                GameManager.instance.dialogActive = false;
            }
            else
            {
                // Dialogi ei ole viel‰ p‰‰ttynyt, joten ekaksi selvitet‰‰
                // Keskustelijan nimi jos sellainen on
                CheckIfName();
                // N‰ytet‰‰n dialogiteksti
                // dialogtext.text = dialogLines[currentLine];
                StartCoroutine(AutoType(dialogLines, currentline));    // Automaattikirjoitus
            }
        }
    }
    // T‰m‰ metodi aukaisee dialogi-ikkuna ja n‰ytt‰‰ 1. dialogin
    public void ShowDialog(string[] newLines, bool isPerson)
    {
        // Montako tekstirivi‰ dialogissa on
        dialogLines = newLines;

        // aloitetaan 1. tekstist‰ 
        currentline = 0;

        // Tarkistaan dialogiin osallistuvan nimi, jos se on hahmo 
        CheckIfName();

        // N‰ytet‰‰n dialogi-ikkuna
        dialogBox.SetActive(true);

        // N‰ytet‰‰n dialogin 1. rivi (0. rivi k‰yty, jos oli henkilˆ).
        // dialogText.text = dialogLines[currentLine];
        StartCoroutine(AutoType(dialogLines, currentline));     // Automaattikirjoitus

        // ilmoitetaan Update-funktiolle ett‰ dialogi-ikkuna on aukaistu
        justStarted = true;

        // Aktivoidaan tai deaktivoidaan nimilaatikko
        nameBox.SetActive(isPerson);

        // Informoidaan GameManageria ett‰ dialogi on k‰ynniss‰
        GameManager.instance.dialogActive = true;
    }
    // T‰m‰ metodi tarkistaa onko merkkijonossa n- ja poistaa sen
    private void CheckIfName()
    {
        if (dialogLines[currentline].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentline].Replace("n-", "");

            // Hyp‰t‰‰n suraavalle riville 
            currentline++;
        }
    }

    // sulkee dialogi-ikkunan.
    public void StopDialog()
    {
        // Suljetaan dialogi-ikkuna
        dialogBox.SetActive(false);

        // Infromoidaan GameManageria ett‰ dialogi on p‰‰ttynyt
        GameManager.instance.dialogActive = false;
    }
    // Automaattikirjoitus alirutiini. Kirjoittaa tekstin kirjain kerrallaan
    IEnumerator AutoType(string[] newLInes, int _currentLine)
    {
        // Tyhjennet‰‰n dialogi
        dialogText.text = "";

        // Kerrotaan Update-metodille, ett‰ automaattikirjoitus on k‰ynniss‰ 
        isCoroutingRunning = true;

        // Keskustelu ei voi jatkaa
        justStarted = false;

        // K‰yd‰‰n dialogin rivi l‰pi kirjain kerrallaan
        foreach (char letter in newLInes[_currentLine].ToCharArray())
        {
            // Lis‰t‰‰n suraava kirjain
            dialogText.text += letter;

            // Odotetaan pieni hetki
            yield return new WaitForSeconds(typingSpeed);
        }
        // Kerrotaan Update-metodille, ett‰ automaattikirjoitus on p‰‰ttynyt
        isCoroutingRunning = false;
        // Keskustelua voidaan jatkaa 
        justStarted = true;
    }

}

