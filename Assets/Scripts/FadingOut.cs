using UnityEngine;
using System.Collections;

public class FadingOut : MonoBehaviour {

    public float delay = 1f;
    private float t;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        t += Time.deltaTime;
        if( t >= delay) Application.LoadLevel(Application.loadedLevel + 1);

    }
}
