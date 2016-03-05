using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {
    public bool active = true;
    public float tempsSwitch = 1f;
    public AudioClip shutDown;
    public AudioSource newAudio;
    public bool bouge;

    private float prochainSwitch = 0.0f;
    private bool SonJoue = false;
    private bool tourne = true;
    private float i = 310.0f;
    


	// Use this for initialization
	void Start () {

        newAudio = gameObject.AddComponent<AudioSource>();
        newAudio.clip = shutDown;
        newAudio.loop = false;
        newAudio.playOnAwake = false;
        newAudio.volume = 1.0f;
        newAudio.enabled = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	if(Time.time > prochainSwitch && active && tourne && bouge)
        {
            
                transform.rotation = Quaternion.Euler(360.0f, 180.0f, i);
            i = i - 1.0f;
            if (i == 243.0f)
            {
                tourne = false;
                prochainSwitch = Time.time + tempsSwitch;
            }
        }
         if(Time.time > prochainSwitch && !tourne && active && bouge)
           {
            
            transform.rotation = Quaternion.Euler(360.0f, 180.0f, i);
            i += 1.0f;
            if (i == 310.0f)
            {
                prochainSwitch = Time.time + tempsSwitch;
                tourne = true;
            }
            }

        if (!active)
        {
           if(!newAudio.isPlaying && !SonJoue) newAudio.Play();
            transform.rotation = Quaternion.Euler(360.0f, 180.0f, 270.0f);
            SonJoue = true;


            
        }
	}
}
