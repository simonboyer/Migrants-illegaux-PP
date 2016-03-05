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
using System;

namespace UnityStandardAssets._2D
{
	
	public class Camera2DFollow : MonoBehaviour {
		
		public Transform Player;
		public Vector2
			Margin,
			Smoothing;
		
		public BoxCollider2D Bounds;
		
		private Vector3
			_min,
			_max;
		
		public bool IsFollowing { get; set; }
		
		// Use this for initialization
		public void Start () {
			
			_min = Bounds.bounds.min;
			_max = Bounds.bounds.max;
			IsFollowing = true;
				
		}
		
		// Update is called once per frame
		public void Update () {
			
			var x = transform.position.x;
			var y = transform.position.y;
			
			if (IsFollowing)
			{
				if(Mathf.Abs (x - Player.position.x) > Margin.x)
					x = Mathf.Lerp (x, Player.position.x, Smoothing.x * Time.deltaTime);
				
				if(Mathf.Abs (y - Player.position.y + 5) > Margin.y)
					y = Mathf.Lerp (y, Player.position.y + 5, Smoothing.y * Time.deltaTime);
			}
			
			var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);
			
			x = Mathf.Clamp (x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
			y = Mathf.Clamp (y, _min.y + GetComponent<Camera>().orthographicSize, _max.y - GetComponent<Camera>().orthographicSize);
			
			transform.position = new Vector3 (x, y, transform.position.z);
			
		}
	}
}
