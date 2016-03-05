using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Videos : MonoBehaviour {
    public MovieTexture movie;
    public bool dernier;
    float temps;
    float t;


    // Use this for initialization
    void Start () {

        GetComponent<RawImage>().texture = movie as MovieTexture;
        temps = movie.duration;
        movie.Play();

    }
	
	// Update is called once per frame
	void Update () {

        t += Time.deltaTime;
        if (t >= temps && !dernier) Application.LoadLevel(Application.loadedLevel + 1);
        if (t >= temps && dernier) Application.LoadLevel(1);


    }
}
