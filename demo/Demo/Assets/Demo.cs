using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

[ExecuteInEditMode]
public class Demo : MonoBehaviour {
	public Color color = Color.magenta;
	public GizmoType Type = GizmoType.Cube;

	public float Height =2;
	public float Radius = 0.5f;
	public float Degrees =45;


	// Update is called once per frame
	void OnDrawGizmos () {
		Gizmos.color = color;
		switch (Type) {
			case GizmoType.Capsule:
				GizmosExtensions.DrawWireCapsule(transform.position,Radius, Height, transform.rotation);
				break;
			case GizmoType.Circle:
				GizmosExtensions.DrawWireCircle(transform.position,Radius,60,transform.rotation);
				break;
			case GizmoType.Arrow:
				GizmosExtensions.DrawArrow(transform.position, transform.position + transform.rotation * (Vector3.up * Height));
				break;
			case GizmoType.Arc:
				GizmosExtensions.DrawWireArc(transform.position,Radius,Degrees,20,transform.rotation);
				break;
			case GizmoType.Cube:
				GizmosExtensions.DrawWireCube(transform.position,transform.localScale,transform.rotation);
				break;
			case GizmoType.Cylinder:
				GizmosExtensions.DrawWireCylinder(transform.position,Radius,Height, transform.rotation);
				break;
			case GizmoType.Sphere:
				GizmosExtensions.DrawWireSphere(transform.position,Radius,transform.rotation);
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	public enum GizmoType {
		Capsule,Circle, Arrow, Arc, Cube, Cylinder, Sphere
	}
}
