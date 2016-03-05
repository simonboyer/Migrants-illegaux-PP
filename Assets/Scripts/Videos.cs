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
using UnityEngine.UI;

public class Videos : MonoBehaviour {
    public MovieTexture movie;
    public bool dernier;
    float temps;
    float t;


    // Use this for initialization
    void Start () {

        GetComponent<RawImage>().texture = movie as MovieTexture;
        temps = movie.duration;
        movie.Play();

    }
	
	// Update is called once per frame
	void Update () {

        t += Time.deltaTime;
        if (t >= temps && !dernier) Application.LoadLevel(Application.loadedLevel + 1);
        if (t >= temps && dernier) Application.LoadLevel(1);


    }
}
