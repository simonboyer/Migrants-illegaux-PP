/*
Copyright

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
