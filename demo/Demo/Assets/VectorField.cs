using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

[ExecuteInEditMode]
public class VectorField : MonoBehaviour {

	
	public float mass = 1;



	public int rows = 10, cols = 10;
	

	void OnDrawGizmos() {
		Gizmos.color = Color.black;

		
			var target = transform.position;
			target.y = 0;


		for (int x = 0; x < rows; x++) {
			for (int y = 0; y < cols; y++) {
				var from = new Vector3(x,0,y);
				var direction = target - from;
				var to = from + direction.normalized * Mathf.Min(0.5f,mass/direction.sqrMagnitude);
				
				GizmosExtensions.DrawArrow(from,to);
			}
		}
		
	}
}
