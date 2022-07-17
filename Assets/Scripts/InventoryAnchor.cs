using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryAnchor : Anchored {
	[SerializeField] InventoryManager invManager;
	[SerializeField] public Sprite deadBox;

    public void Start()
    {
        if (deadBox != null)
        {
			gameObject.transform.GetComponent<SpriteRenderer>().sprite = deadBox;

			// prevent interaction
			isFilled = true;
        }
    }
    public bool isFilled = false;
	public override void Anchor(GameObject draggedBox) {
		invManager.boxes.Add(draggedBox);
		invManager.CheckCarryOver();
		isFilled = true;
	}

	public override void UnAnchor (GameObject draggedBox) {
		invManager.boxes.Remove(draggedBox);
		invManager.CheckCarryOver();
		isFilled = false;
	}

	public override bool IsAnchorable(GameObject draggedBox) {
		return !isFilled;
	}
}
