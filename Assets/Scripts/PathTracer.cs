using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTracer : MonoBehaviour {
	TrailRenderer trailRenderer;

	void Start () {
		trailRenderer = GetComponent<TrailRenderer> ();
	}
}
