using System.Collections;
using System.Collections.Generic;

// A volume is something that takes up space

public abstract class Volume {
	public abstract bool Intersect (Volume v);
}
