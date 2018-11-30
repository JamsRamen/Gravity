using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A volume that is a circle

public class CircleVolume : Volume {
	public Vector2 center;
	public float radius;

	public CircleVolume (Vector2 center, float radius) {
		this.center = center;
		this.radius = radius;
	}
	public CircleVolume (Vector3 center, float radius) : this (Utility.Flatten(center), radius) { }

	public override bool Intersect (Volume v) {
		if (v is CircleVolume) {
			CircleVolume circle = (CircleVolume)v;
			return radius+circle.radius >= Vector2.Distance (center, circle.center);
		}
		if (v is PointVolume) {
			PointVolume point = (PointVolume)v;
			return radius >= Vector2.Distance (center, point.center);
		}
		return false;
	}
}
