using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
	public Vector2 velocity;
	float energy;

	void Start () {
		energy = velocity.sqrMagnitude / 2 + Game.field.Potential(Utility.Flatten(transform.position));
	}

	public void SetVelocity (Vector2 v) {
		velocity = v;
		energy = velocity.sqrMagnitude / 2 + Game.field.Potential(Utility.Flatten(transform.position));

		Debug.Log (energy);
	}

	void FixedUpdate () {
		float deltat = Time.fixedDeltaTime / 50;
		float dist = 0;
		int n = 1000;

		while (dist < 0.15 && n > 0) {
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
				this.enabled = false;
				return;
			}

			dist += (newPos - transform.position).magnitude;
			transform.position = newPos;
			n--;
		}
	}
}
