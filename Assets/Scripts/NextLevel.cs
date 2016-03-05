using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player" && (GameObject.Find("Player").GetComponent<Platformer2DUserControl>().onLadder || GameObject.Find("Player").GetComponent<PlatformerCharacter2D>().m_Grounded)) Application.LoadLevel(Application.loadedLevel + 1);
        else if (other.name == "Player") GameObject.Find("Canvas").GetComponent<GameOver>().Alarm = true;
    }
}
