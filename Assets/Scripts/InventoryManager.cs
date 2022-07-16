using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
	[SerializeField] int carryOverCount;
	[SerializeField] GameObject anchorParent;
	[SerializeField] Button roundButton;
	[SerializeField] Transform restingArea;
	[SerializeField] Transform dragArea;
	public List<GameObject> boxes;
	public List<InventoryAnchor> anchors;
	

	private void Start() {
		boxes = new List<GameObject>();
		anchors = new List<InventoryAnchor>();
		foreach(InventoryAnchor anchor in anchorParent.GetComponentsInChildren<InventoryAnchor>()) {
			anchors.Add(anchor);
		}
	}
	
	public void CheckCarryOver() {
		if (boxes.Count <= carryOverCount && boxes.Count == restingArea.childCount + dragArea.childCount) {
			roundButton.interactable = true;
		} else {
			roundButton.interactable = false;
        }
	}
}
