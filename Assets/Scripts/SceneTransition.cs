using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

            yield return StartCoroutine(sf.FadeToBlack());

            SceneManager.LoadScene("BattleScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
