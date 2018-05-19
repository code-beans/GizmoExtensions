
using System;
using System.Linq;
using UnityEngine;

namespace Utils {
	public static class GizmosExtensions {

		public static void DrawWireCube(Vector3 center, Vector3 size, Quaternion rotation = default(Quaternion)) {
		
			var half = size / 2;
			// draw front
			Gizmos.DrawLine(rotation * (center + new Vector3(-half.x, -half.y, half.z)), rotation * (center + new Vector3(half.x, -half.y, half.z)));
			Gizmos.DrawLine(rotation * (center + new Vector3(-half.x, -half.y, half.z)), rotation * (center + new Vector3(-half.x, half.y, half.z)));
			Gizmos.DrawLine(rotation * (center + new Vector3(half.x, half.y, half.z)), rotation * (center + new Vector3(half.x, -half.y, half.z)));
			Gizmos.DrawLine(rotation * (center + new Vector3(half.x, half.y, half.z)), rotation * (center + new Vector3(-half.x, half.y, half.z)));
			// draw back
			Gizmos.DrawLine(rotation * (center + new Vector3(-half.x, -half.y, -half.z)), rotation * (center + new Vector3(half.x, -half.y, -half.z)));
			Gizmos.DrawLine(rotation * (center + new Vector3(-half.x, -half.y, -half.z)), rotation * (center + new Vector3(-half.x, half.y, -half.z)));
			Gizmos.DrawLine(rotation * (center + new Vector3(half.x, half.y, -half.z)), rotation * (center + new Vector3(half.x, -half.y, -half.z)));
			Gizmos.DrawLine(rotation * (center + new Vector3(half.x, half.y, -half.z)), rotation * (center + new Vector3(-half.x, half.y, -half.z)));
			// draw corners
			Gizmos.DrawLine(rotation * (center + new Vector3(-half.x, -half.y, -half.z)), rotation * (center + new Vector3(-half.x, -half.y, half.z)));
			Gizmos.DrawLine(rotation * (center + new Vector3(half.x, -half.y, -half.z)), rotation * (center + new Vector3(half.x, -half.y, half.z)));
			Gizmos.DrawLine(rotation * (center + new Vector3(-half.x, half.y, -half.z)), rotation * (center + new Vector3(-half.x, half.y, half.z)));
			Gizmos.DrawLine(rotation * (center + new Vector3(half.x, half.y, -half.z)), rotation * (center + new Vector3(half.x, half.y, half.z)));
		
		}

		public static void DrawLine(Vector3 from, Vector3 to, Quaternion rotation = default(Quaternion)) {
			Gizmos.DrawLine(rotation * (from), rotation * (to));
		}

		public static void DrawArrow(Vector3 from, Vector3 to, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20.0f, Quaternion rotation = default(Quaternion)) {
			DrawLine(from,to, rotation);
			var direction = to - from;
			var right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowHeadAngle, 0) * new Vector3(0, 0, 1);
			var left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowHeadAngle, 0) * new Vector3(0, 0, 1);
			DrawLine(to,to + right * arrowHeadLength, rotation);
			DrawLine(to, to + left * arrowHeadLength, rotation);
		}


		public static void DrawMesh(Mesh mesh, Vector3 position, Vector3 scale, Quaternion rotation = default(Quaternion)) {
			if (mesh == null)
				throw new ArgumentNullException("mesh");
			var verts = mesh.vertices.Select(v => Vector3.Scale(v, scale) + position).ToList();
			var tris = mesh.triangles;
			for (var i = 0; i < tris.Length - 3; i += 3) {
				DrawLine(verts[tris[i]], verts[tris[i + 1]], rotation);
				DrawLine(verts[tris[i + 1]], verts[tris[i + 2]], rotation);
				DrawLine(verts[tris[i]], verts[tris[i + 2]], rotation);
			}
		}

		public static void DrawWireSphere(Vector3 position, float radius, float angle, Quaternion rotation = default(Quaternion)) {

			var x = new Vector3(position.x, position.y + radius * Mathf.Sin(0), position.z + radius * Mathf.Cos(0));
			var y = new Vector3(position.x + radius * Mathf.Cos(0), position.y, position.z + radius * Mathf.Sin(0));
			var z = new Vector3(position.x + radius * Mathf.Cos(0), position.y + radius * Mathf.Sin(0), position.z);

			for (var i = 1; i < 37; i++) {

				var newX = new Vector3(position.x, position.y + radius * Mathf.Sin(angle * i * Mathf.Deg2Rad), position.z + radius * Mathf.Cos(angle * i * Mathf.Deg2Rad));
				var newY = new Vector3(position.x + radius * Mathf.Cos(angle * i * Mathf.Deg2Rad), position.y, position.z + radius * Mathf.Sin(angle * i * Mathf.Deg2Rad));
				var newZ = new Vector3(position.x + radius * Mathf.Cos(angle * i * Mathf.Deg2Rad), position.y + radius * Mathf.Sin(angle * i * Mathf.Deg2Rad), position.z);

				DrawLine(x, newX, rotation);
				Gizmos.DrawLine(y, newY, rotation);
				Gizmos.DrawLine(z, newZ, rotation);

				x = newX;
				y = newY;
				z = newZ;
			}
		}
	
	}
}
