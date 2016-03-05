using System;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof(PlatformerEnnemy2D))]
public class Platformer2DEnnemy : MonoBehaviour
{
    private PlatformerEnnemy2D m_Character;

    private bool m_Jump = false;
    //private NavMeshAgent nav;
    private CircleCollider2D col;
    private Animator anim;
    private GameObject player;
    private Animator playerAnim;
    private AudioSource source;
    //private bool queriesHitTriggers = false;
    //private HashIDs hash;


    public float angleDeVue = 110f;
    public bool playerVisible = false;
    private bool BaliseDroite = false;
    private bool BaliseGauche = true;
    private float h = 0;
    private bool fini = false;

    //public PlatformerCharacter2D m_Character;


    private void Awake()
    {
        m_Character = GetComponent<PlatformerEnnemy2D>();
        //nav = GetComponent<NavMeshAgent> ();
        col = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
       /// playerAnim = player.GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        //	hash = GameObject.FindGameObjectsWithTag (Tags.gameController).GetComponent<HashIDs> ();

    }

    private void OnTriggerStay2D(Collider2D other) //pour toutes les frames ou un objet est dans le collider triggered
    {
        if (other.name == "Player")
        {
            //playerVisible = false;

            Vector2 direction = other.GetComponent<SpriteRenderer>().bounds.max - GetComponent<SpriteRenderer>().bounds.max;
            float angle = Vector2.Angle(direction, transform.right);
            float avantArriere = 90f;

            if (transform.localScale.x > 0) avantArriere = 180f - angle;
            if (transform.localScale.x < 0) avantArriere = angle; ;
            if (avantArriere < angleDeVue * 0.5f)
            {

                RaycastHit2D hit = Physics2D.Raycast(GetComponent<SpriteRenderer>().bounds.max, new Vector2(direction.x, direction.y * -1)); //Créer le raycast
                Debug.DrawRay(GetComponent<SpriteRenderer>().bounds.max, new Vector2(direction.x, direction.y * -1), Color.green);                                                                                                       //RaycastHit2D hit = Physics2D.Linecast (transform.position + transform.up, player.transform.position);


                if (hit.collider.name == "Player")
                { //verifier si le raycast a frappe le joueur
                    playerVisible = true;
                }
            }
        }

        //else playerVisible = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player) playerVisible = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BaliseGauche") BaliseGauche = true;
        if (other.gameObject.tag == "BaliseDroite") BaliseDroite = true;
        if (other.gameObject.name == "Player" && !fini)
        {
            GameObject.Find("Canvas").GetComponent<GameOver>().Alarm = true;
            source.Play();
            fini = true;
        }
    }

    private void Update()
    {

        /* if (playerVisible == true)
             m_Jump = true;
         else
             m_Jump = false;

     /*    if (!m_Jump)
         {
             // Read the jump input in Update so button presses aren't missed.
             m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
         } */

    }


    private void FixedUpdate()
    {
        // Read the inputs.
        bool crouch = false;
        bool ApresPoursuite = false;
        if (playerVisible == true)
        {
            ApresPoursuite = true;
            Vector2 direction = player.transform.position - transform.position;
            if (direction.x > 0) h = 1;
            else if (direction.x < 0) h = -1;
            else h = 0;

        }
        else
        {
            if (BaliseGauche) h = 0.35f;
            if (BaliseDroite) h = -0.35f;
            if (ApresPoursuite) h = h * -0.35f;
            BaliseGauche = false;
            BaliseDroite = false;
        }
        // Pass all parameters to the character control script.
        m_Character.Move(h, crouch, m_Jump);
        m_Jump = false;
    }
}

