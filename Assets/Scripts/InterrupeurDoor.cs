using UnityEngine;
using System.Collections;

public class InterrupeurDoor : MonoBehaviour {

    public OpenDoor element;
    // public SwitchCamera actif;
    public bool actif;
    private SpriteRenderer couleur;

    // Use this for initialization
    void Start()
    {
        actif = element.active;
        couleur = GameObject.Find(gameObject.name + "/interrupteur_1").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.name == "Player")
        {
            // test = true;
            if (Input.GetKeyDown(KeyCode.F) && !actif)
            {
                actif = true;
                GetComponent<SpriteRenderer>().enabled = false;
                couleur.GetType().GetProperty("enabled").SetValue(couleur, true, null);
            }
            //if (Input.GetButtonDown("Jump") && actif) actif = false;
            element.active = actif;
        }
    }
}