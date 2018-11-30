using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
	public Vector2 velocity;
	float energy;

	void Start () {
		energy = velocity.sqrMagnitude / 2 + Game.field.Potential(Utility.Flatten(transform.position));
		Debug.Log (energy);
	}

	void FixedUpdate () {
		float deltat = Time.fixedDeltaTime / 50;

		for (int i = 0; i < 50; i++) {
			Vector2 accel = Game.field.Field (Utility.Flatten(transform.position));

			Vector3 newPos = new Vector3 (
				Utility.EulerStep(transform.position.x, velocity.x, accel.x, deltat),
				Utility.EulerStep(transform.position.y, velocity.y, accel.y, deltat), 0
			);
			velocity = new Vector2 (
				velocity.x + accel.x * deltat,
				velocity.y + accel.y * deltat
			);
			velocity = velocity / velocity.magnitude * Mathf.Sqrt (2 * (energy - Game.field.Potential (Utility.Flatten (transform.position))));

			if (Game.space.Intersect(new PointVolume(transform.position))) {
				Destroy (this);
				return;
			}

			transform.position = newPos;
		}
	}
}
