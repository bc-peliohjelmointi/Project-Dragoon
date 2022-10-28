using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Pelihamon nopeus
    public float speed = 4f;

    // Referenssi pelihahmon fysiikkamoottoriin
    private Rigidbody2D rb;

    // Referenssi liikevektoriin
    private Vector2 mov;

    // Kartta, jossa ollaan pelin alussa
    [SerializeField] private GameObject Overworld;

    // Vain yksi (Singelton) esiintymä pelihahmosta sallitaan
    public static PlayerController instance;

    // Lippu, joka ilmoittaa voikko pelihahmo liikkua (esim. dialogin aikana ei voi)
    public bool canMove;

    // Refrenssi animaattoriin
    private Animator anim;

    private void Start()
    {
        // Onko pelihahmo jo olemassa?
        if (instance == null)
        {
            // Ei ole. kiinnitetään pelihahmo
            instance = this;

            // Pelihahmo voi liikkua pelin alussa
            canMove = true;

            // Otetaan pelihahmon fysiikkamoottori käyttöön
            rb = GetComponent<Rigidbody2D>();


            // Otetaan pelihahmon animaattori käyttöön
            anim = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movements();
        // Animations();
    }

    /*void Animations()
    {
        // Voiko pelihahmo liikkua?
        if (canMove && mov.magnitude != 0)
        {
            // Kyllä. Joten animoidaan liike
            anim.SetFloat("MoveX", mov.x);
            anim.SetFloat("MoveY", mov.y);
            anim.SetBool("Walking", true);
        }
        else
        {
            // Ei voi. Joten pysäytetään liikeanimaatio
            anim.SetBool("Walking", false);
        }
    }
    */
    void Movements()
    {
        // Otetaan pelihahmon suuntavektori talteen
        mov = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        // Voiko pelihahmo liikkua?
        if (canMove && mov.magnitude != 0)
        {
            // Liikutetaan pelihahmon Rigidbodya nopeudella speed suuntavektorin osoittamaan suuntaan
            rb.MovePosition(rb.position + mov * speed * Time.deltaTime);
        }

    }

}