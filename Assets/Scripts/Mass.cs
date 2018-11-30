using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A mass is something that exerts gravitational force

public abstract class Mass {
	public float mass;

	public abstract Vector2 Field (Vector2 point);
	public abstract float Potential (Vector2 point);
}
