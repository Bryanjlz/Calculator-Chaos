using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryAnchor : Anchored {
	bool isFilled = false;
	public override void Anchor(GameObject draggedBox) {
		isFilled = true;
	}

	public override void UnAnchor (GameObject draggedBox) {
		isFilled = false;
	}

	public override bool IsAnchorable(GameObject draggedBox) {
		return !isFilled;
	}
}
