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

public class OpenDoor : MonoBehaviour {

    public bool active = false;
    public float monter;

    private bool fait = false;
    private Vector3 i;
    private float initial;
    private AudioSource source;
    private bool played = false;

    // Use this for initialization
    void Start () {
        i.x = 0.0f;
        i.y = 0.0f;
        i.z = 0.0f;
        initial = transform.position.y;
        source = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (active && !fait)
        {
           if(!played) source.Play();
            played = true;
            transform.position = transform.position + i;
            i.y += 0.001f;
            if (transform.position.y - initial >= monter) fait = true;
        }


    }
}
