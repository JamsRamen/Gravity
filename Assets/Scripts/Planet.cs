using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
	CircleVolume volume;
	PointMass mass;

	void OnEnable () {
		if (volume == null) volume = new CircleVolume (transform.position, transform.lossyScale.x);
		if (mass == null) mass = new PointMass (Mathf.Pow (transform.lossyScale.x, 3), transform.position);

		Game.field.Add (mass);
		Game.space.Add (volume);
	}

	void OnDisable () {
		Game.field.Remove (mass);
		Game.space.Remove (volume);
	}
}
