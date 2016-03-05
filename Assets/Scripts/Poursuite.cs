using UnityEngine;
using System.Collections;

public class Poursuite : MonoBehaviour {
    private Animator anim;
    private bool fini = false;
    private AudioSource source;
    private bool poursuite = true;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Poursuite", poursuite);
	
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.name == "Player" && !fini)
        {
            GameObject.Find("Canvas").GetComponent<GameOver>().Alarm = true;
            source.Play();
            fini = true;
        }

        if (other.gameObject.name == "Porte")
        {
            poursuite = false;
            anim.Play("Idle");
            transform.position = new Vector3(79.2f, 5.13f);
        }
    }
}
