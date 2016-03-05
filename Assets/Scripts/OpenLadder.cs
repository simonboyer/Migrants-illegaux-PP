using UnityEngine;
using System.Collections;

public class OpenLadder : MonoBehaviour {

    public bool active = false;
    public float monter;

    private bool fait = false;
    private Vector3 i;
    private float initial;
    private AudioSource source;
    private bool played = false;

    // Use this for initialization
    void Start () {
        i.x = 0.0f;
        i.y = 0.0f;
        i.z = 0.0f;
        initial = transform.position.y;
        source = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (active && !fait)
        {
           if(!played) source.Play();
            played = true;
            transform.position = transform.position - i;
            i.y += 0.001f;
            if (transform.position.y - initial <= monter) fait = true;
        }


    }
}
