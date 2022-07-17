using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryAnchor : Anchored {
	[SerializeField] InventoryManager invManager;
	[SerializeField] Sprite deadBox;

    public void Start()
    {
        if (deadBox != null)
        {
			gameObject.transform.GetComponent<SpriteRenderer>().sprite = deadBox;

			// prevent interaction
			isFilled = true;
        }
    }
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
