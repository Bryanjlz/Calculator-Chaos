using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAnchor : Anchored {
	public override void Anchor(GameObject draggedBox) {
		return;
	}

	public override bool IsAnchorable(GameObject draggedBox) {
		return true;
	}
}
