using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Responsible for tracking gravitational force

public class GravityField {
	List<Mass> masses = new List<Mass>();

	public void Add (Mass m) {
		masses.Add (m);
	}
	public void Remove (Mass m) {
		masses.Remove (m);
	}

	// evaluate the field at a point
	public Vector2 Field (Vector2 point) {
		Vector2 field = new Vector2();

		foreach (Mass m in masses) {
			field += m.Field (point);
		}

		return field;
	}

	// evaluate gravitational potential energy at a point
	public float Potential (Vector2 point) {
		float potential = 0;

		foreach (Mass m in masses) {
			potential += m.Potential (point);
		}

		return potential;
	}
}
