using UnityEngine;
using System.Collections;

public class InfosScript : MonoBehaviour {

    Animator anim;
    private float t;
    public float animTime = 1f;

	// Use this for initialization
	void Start () {
        anim = GameObject.Find("Canvas").GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            t += Time.deltaTime;
            anim.SetBool("Info", true);
            if (t >= animTime) Time.timeScale = 0f;
        }
    }

    public void fini()
    {
        Time.timeScale = 1f;
        anim.SetBool("Info", false);
    }
}
