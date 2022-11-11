using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    // Refrenssi animaattoriin
    private Animator anim;

    // Lippu, joka kertoo että animaatio  on suoritettu loppuun
    private bool isFading = false;

    // Start is called before the first frame update
    void Start()
    {
        // Otetaan animaattori käyttöön
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Nostaa esiripun (Valaistus-animaatio)
    /// </summary>
    /// <returns></returns>
    public IEnumerator FadeToClear()
    {
        isFading = true;
        anim.SetTrigger("FadeIn");

        // Silmukka suoritetaan niin kauan, kunnes isFagind = false
        while (isFading)
            yield return null;
    }

    /// <summary>
    /// Laskee esiripun (Pimennys-animaatio)
    /// <returns></returns>
    public IEnumerator FadeToBlack()
    {
        isFading = true;
        anim.SetTrigger("FadeOut");

        // Silmukka suoritetaan niin kauan, kunnes isFagind = false
        while (isFading)
            yield return null;

    }
    // Kertoo alirutiineille, että animaatio on suoritettu loppuun
    void AnimationComplete()
    {
        isFading = false;
    }
}

