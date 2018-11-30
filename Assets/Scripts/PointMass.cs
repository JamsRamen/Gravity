using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A mass which is a point

public class PointMass : Mass {
	public PointVolume volume;

	public PointMass (float mass, PointVolume volume) {
		this.mass = mass;
		this.volume = volume;
	}
	public PointMass (float mass, Vector2 center) : this (mass, new PointVolume(center)) { }
	public PointMass (float mass, Vector3 center) : this (mass, new PointVolume(center)) { }

	public override Vector2 Field (Vector2 point) {
		return GameSettings.G * mass / (volume.center - point).sqrMagnitude * (volume.center - point).normalized;
	}
	public override float Potential (Vector2 point) {
		return -GameSettings.G * mass / (volume.center - point).magnitude;
	}
}
