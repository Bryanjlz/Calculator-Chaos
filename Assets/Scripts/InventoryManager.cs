using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
	// Serialize Field makes it show up on the unity editor
	[SerializeField] GameObject anchorParent;
	public List<GameObject> boxes;
	public List<InventoryAnchor> anchors;

	private void Start() {
		boxes = new List<GameObject>();
		anchors = new List<InventoryAnchor>();
		foreach(InventoryAnchor anchor in anchorParent.GetComponentsInChildren<InventoryAnchor>()) {
			anchors.Add(anchor);
		}
	}
}
