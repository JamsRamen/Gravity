using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launchable : MonoBehaviour {

	Rigidbody2D rigid;
	Mover mover;
	PathTracer path;

	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		mover = GetComponent<Mover> ();
		path = GetComponent<PathTracer> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			mover.enabled = false;
			//path.Disable();
		}
		if (Input.GetMouseButton (0)) {
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			pos.z = 0;

			transform.SetPositionAndRotation(pos, transform.rotation);
		}
		if (Input.GetMouseButtonUp(0)) {
			mover.enabled = true;
			mover.SetVelocity (10*rigid.velocity);
			path.Enable ();
		}
	}
}
