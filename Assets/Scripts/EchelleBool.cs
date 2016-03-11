/*
(c) Copyright Simon Boyer and Antoine Brassard Lahey 2016

This file is part of Migrants-illegaux-PP.

    Migrants-illegaux-PP is free software: you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Migrants-illegaux-PP is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with Migrants-illegaux-PP.  If not, see <http://www.gnu.org/licenses/>. 
    */
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
