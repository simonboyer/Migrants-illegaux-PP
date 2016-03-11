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

public class InterrupeurLadder : MonoBehaviour {

    public OpenLadder element;
    // public SwitchCamera actif;
    public bool actif;
    private SpriteRenderer couleur;

    // Use this for initialization
    void Start()
    {
        actif = element.active;
        couleur = GameObject.Find(gameObject.name + "/interrupteur_1").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.name == "Player")
        {
            // test = true;
            if (Input.GetKeyDown(KeyCode.F) && !actif)
            {
                actif = true;
                GetComponent<SpriteRenderer>().enabled = false;
                couleur.GetType().GetProperty("enabled").SetValue(couleur, true, null);
            }
            //if (Input.GetButtonDown("Jump") && actif) actif = false;
            element.active = actif;
        }
    }
}