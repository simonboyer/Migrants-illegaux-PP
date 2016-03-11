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
using System.Collections;

public class scene1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


    }

    public void nextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void dons()
    {
        Application.OpenURL("http://coalitionhumanitaire.ca/nos-campagnes/crise-des-refugies-syriens");
    }

    public void quitter()
    {
        Application.Quit();
    }

    public void credits()
    {
        Application.LoadLevel(8);
    }
}
