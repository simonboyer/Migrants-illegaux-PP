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
