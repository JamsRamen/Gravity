using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTracer : MonoBehaviour {
	TrailRenderer trailRenderer;

	void Start () {
		trailRenderer = GetComponent<TrailRenderer> ();
	}

	public void Enable () {
		trailRenderer.enabled = true;
	}
	public void Disable () {
		trailRenderer.Clear ();
		trailRenderer.enabled = false;
	}

}
