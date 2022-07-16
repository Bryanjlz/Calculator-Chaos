using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryAnchor : Anchored {
	[SerializeField] InventoryManager invManager;
	bool isFilled = false;
	public override void Anchor(GameObject draggedBox) {
		invManager.boxes.Add(gameObject);
		invManager.CheckCarryOver();
		isFilled = true;
	}

	public override void UnAnchor (GameObject draggedBox) {
		invManager.boxes.Remove(gameObject);
		invManager.CheckCarryOver();
		isFilled = false;
	}

	public override bool IsAnchorable(GameObject draggedBox) {
		return !isFilled;
	}
}
