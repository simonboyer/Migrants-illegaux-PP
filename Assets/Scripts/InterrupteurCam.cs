using UnityEngine;
using System.Collections;

public class InterrupteurCam : MonoBehaviour {

    public SwitchCamera element;
   // public SwitchCamera actif;
    public bool actif;
    private SpriteRenderer couleur;

    // Use this for initialization
    void Start () {
        actif = element.active;
        couleur = GameObject.Find(gameObject.name + "/interrupteur_0").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.name == "Player")
        {
            // test = true;
            // if (Input.GetButtonDown("Jump") && !actif) actif = true;
            if (Input.GetKey(KeyCode.F) && actif)
            {
                actif = false;
                GetComponent<SpriteRenderer>().enabled = false;
                couleur.GetType().GetProperty("enabled").SetValue(couleur, true, null);
            }
                element.active = actif;
        }
    }
}
