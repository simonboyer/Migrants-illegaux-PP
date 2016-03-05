using UnityEngine;
using System.Collections;

public class Limites : MonoBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "Player") GameObject.Find("Canvas").GetComponent<GameOver>().Alarm = true;
    }
}
