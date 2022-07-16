using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Anchored : MonoBehaviour {
	public abstract void Anchor(GameObject draggedBox);
	public abstract bool IsAnchorable(GameObject draggedBox);
}
