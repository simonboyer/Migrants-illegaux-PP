﻿/*
(c) Copyright Simon Boyer and Antoine Brassard Lahey 2016

This file is part of Migrants-illegaux-PP.

    Migrants-illegaux-PP is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Foobar is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Migrants-illegaux-PP.  If not, see <http://www.gnu.org/licenses/>. 
    */
using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	// Use this for initialization
	void Awake () {

        DontDestroyOnLoad(transform.gameObject);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
