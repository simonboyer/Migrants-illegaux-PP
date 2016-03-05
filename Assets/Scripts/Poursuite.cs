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

public class Poursuite : MonoBehaviour {
    private Animator anim;
    private bool fini = false;
    private AudioSource source;
    private bool poursuite = true;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Poursuite", poursuite);
	
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.name == "Player" && !fini)
        {
            GameObject.Find("Canvas").GetComponent<GameOver>().Alarm = true;
            source.Play();
            fini = true;
        }

        if (other.gameObject.name == "Porte")
        {
            poursuite = false;
            anim.Play("Idle");
            transform.position = new Vector3(79.2f, 5.13f);
        }
    }
}
