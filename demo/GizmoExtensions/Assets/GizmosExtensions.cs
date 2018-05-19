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
	
	}
}
