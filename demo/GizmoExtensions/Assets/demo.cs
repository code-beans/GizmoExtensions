using UnityEngine;
using Utils;

[ExecuteInEditMode]
public class demo : MonoBehaviour {

    private float timePassed = 0;
    private bool toMax = true;
    public float degreesPerSecond = 20;
	// Update is called once per frame
	void OnDrawGizmos () {

	    if (toMax) {
	        timePassed += Time.deltaTime;
	        if (timePassed >= 1)
	            toMax = !toMax;
	    }
	    else {
	        timePassed -= Time.deltaTime;
	        if (timePassed <= 0)
	            toMax = true;
	    }

	    var rot = Quaternion.AngleAxis((Time.time * degreesPerSecond) % 360, Vector3.up);
        Gizmos.color = Color.Lerp(Color.red, Color.green, timePassed);
		GizmosExtensions.DrawWireCube(Vector3.zero, Vector3.one, rot);
	    GizmosExtensions.DrawWireSphere(Vector3.forward * 2,0.5f,rot);
        GizmosExtensions.DrawArrow(Vector3.forward, Vector3.forward + Vector3.up * 2);
    }
}
