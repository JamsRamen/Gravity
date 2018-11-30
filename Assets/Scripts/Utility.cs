using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// contains general methods used throughout the project

public static class Utility {

	// converts vector v to 2 dimensions
	public static Vector2 Flatten (Vector3 v) {
		return new Vector2(v.x, v.y);
	}

	public static float EulerStep (float x, float v, float a, float deltat) {
		return x + v*deltat + a/2 * Mathf.Pow(deltat, 2);
	}
}

