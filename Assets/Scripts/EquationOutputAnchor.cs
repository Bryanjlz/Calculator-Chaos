using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationOutputAnchor : Anchored
{
	public GameObject box;
	public Equation eq;
	public override void Anchor(GameObject draggedBox) {
		// shouldn't happen
		print("Something catastrophic has just happened.");
		return;
	}

	public override bool IsAnchorable(GameObject draggedBox) {
		return false;
	}

	public override void UnAnchor(GameObject draggedBox) {
		return;
	}

	public void PickUp() {
		box.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
		for (int i = eq.inputAnchors.Count - 1; i >= 0; i--) {
			eq.inputAnchors[i].Lock();
		}
	}
}
