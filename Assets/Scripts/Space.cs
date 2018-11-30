using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Responsible for tracking volumes

public class Space {
	List<Volume> volumes = new List<Volume>();

	public void Add (Volume v) {
		volumes.Add (v);
	}
	public void Remove (Volume v) {
		volumes.Remove (v);
	}

	// returns true if v does not intersect any element of volumes
	public bool Intersect (Volume v) {
		foreach (Volume u in volumes) {
			if (u.Intersect (v)) {
				return true;
			}
		}
		return false;
	}
}
