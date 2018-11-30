using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A volume that occupies a single point

public class PointVolume : Volume {
	public Vector2 center;

	public PointVolume (Vector2 center) {
		this.center = center;
	}
	public PointVolume (Vector3 center) : this (Utility.Flatten(center)) { }

	public override bool Intersect (Volume v) {
		if (v is CircleVolume) {
			CircleVolume u = (CircleVolume)v;
			return u.Intersect (this);
		}
		if (v is PointVolume) {
			PointVolume u = (PointVolume)v;
			return center == u.center;
		}
		return false;
	}
}
