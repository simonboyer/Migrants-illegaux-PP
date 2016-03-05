using UnityEngine;
using System;
//using UnityStandardAssets.CrossPlatformInput;



//[RequireComponent(typeof (PlatformerCharacter2D))]
public class EchelleBool : MonoBehaviour {

	private Platformer2DUserControl thePlayer;  //Appel au script patformercharacter2d
	
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<Platformer2DUserControl>(); // Trouver tous les objets appertenants a ce script
	
	}
	
void OnTriggerEnter2D (Collider2D other)
	{
		if(other.name == "Player")
		{
			thePlayer.onLadder = true; //si le joueur entre devant l<echhel, le bool OnLadder est true
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if(other.name == "Player")
		{
			thePlayer.onLadder = false;//si le joueur sort devant l<echhel, le bool OnLadder est false
		}
	}
}
