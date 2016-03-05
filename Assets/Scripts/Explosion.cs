using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.name == "Player")
        {
            GameObject.Find("Canvas").GetComponent<GameOver>().Alarm = true;
            source.Play();
        }
    }
}
