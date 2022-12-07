using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EncounterController : MonoBehaviour
{
    public GameObject Enemy;
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // DataManager.SavePlayerDataToJSON(other.GetComponent<Player>());
            // DataManager.SaveEanemyDataToJSON(GetComponent<Eanemy>());
            ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

            yield return StartCoroutine(sf.FadeToBlack());

            SceneManager.LoadScene("BattleScene");

            yield return StartCoroutine(sf.FadeToClear());

        }
    }
}
