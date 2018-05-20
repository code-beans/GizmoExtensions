using System;
using UnityEngine;

namespace Utils {
	public static class GizmosExtensions {
	   
		public static void DrawWireCube(Vector3 center, Vector3 size, Quaternion rotation = default(Quaternion)) {
			var old = Gizmos.matrix;
			Gizmos.matrix = Matrix4x4.TRS(center, rotation, size);
			Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
			Gizmos.matrix = old;
		}

		public static void DrawArrow(Vector3 from, Vector3 to, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f) {
			Gizmos.DrawLine(from, to);
			var direction = to - from;
			var right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
			var left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
			Gizmos.DrawLine(to, to + right * arrowHeadLength);
			Gizmos.DrawLine(to, to + left * arrowHeadLength);
		}

		public static void DrawWireSphere(Vector3 center, float radius, Quaternion rotation = default(Quaternion)) {
			var old = Gizmos.matrix;
			Gizmos.matrix = Matrix4x4.TRS(center, rotation, Vector3.one);
			Gizmos.DrawWireSphere(Vector3.zero, radius);
			Gizmos.matrix = old;
		}

		
		/// <summary>
		/// Draws a circle with normal (up)
		/// </summary>
		/// <param name="center"></param>
		/// <param name="radius"></param>
		/// <param name="segments"></param>
		/// <param name="rotation"></param>
		public static void DrawWireCircle(Vector3 center, float radius, int segments = 20, Quaternion rotation = default(Quaternion)) {
			DrawWireArc(center,radius,360,segments,rotation);
		}

	    /// <summary>
	    /// Draws an arc
	    /// </summary>
	    /// <param name="center"></param>
	    /// <param name="radius"></param>
	    /// <param name="angle">angle in degrees</param>
	    /// <param name="segments"></param>
	    /// <param name="rotation"></param>
	    public static void DrawWireArc(Vector3 center, float radius, float angle, int segments = 20,Quaternion rotation = default(Quaternion))
		{
			var old = Gizmos.matrix;
			Gizmos.matrix = Matrix4x4.Rotate(rotation);
			Vector3 from = center + Vector3.forward * radius;
			Vector3 to = center;
			var step = Mathf.RoundToInt(angle / segments);
			for (int i = 0; i <= angle; i += step)
			{
				to.x = center.x + radius * Mathf.Sin(i * Mathf.Deg2Rad);
				to.z = center.z + radius * Mathf.Cos(i * Mathf.Deg2Rad);
				Gizmos.DrawLine(from, to);
				from = to;
			}

			Gizmos.matrix = old;
		}

		/// <summary>
		/// Draws a wire cylinder face up
		/// </summary>
		/// <param name="center"></param>
		/// <param name="radius"></param>
		/// <param name="height"></param>
		/// <param name="rotation"></param>
		public static void DrawWireCylinder(Vector3 center, float radius, float height, Quaternion rotation = default(Quaternion)) {
			var old = Gizmos.matrix;
			Gizmos.matrix = Matrix4x4.Rotate(rotation);
			var half = height / 2f;
			DrawWireCircle(center - Vector3.up * half,radius);
			DrawWireCircle(center + Vector3.up * half, radius);
			Gizmos.DrawLine(center + Vector3.right * radius - Vector3.up * half, center + Vector3.right * radius + Vector3.up * half);
			Gizmos.DrawLine(center - Vector3.right * radius - Vector3.up * half, center - Vector3.right * radius + Vector3.up * half);
			Gizmos.DrawLine(center + Vector3.forward * radius - Vector3.up * half, center + Vector3.forward * radius + Vector3.up * half);
			Gizmos.DrawLine(center - Vector3.forward * radius - Vector3.up * half, center - Vector3.forward * radius + Vector3.up * half);
			Gizmos.matrix = old;

		}

	}
}
