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
	[SerializeField] TargetManager tManager;
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
		print(restingArea.childCount + " " + dragArea.childCount + " " + tManager.completeCounter);
		if (boxes.Count <= carryOverCount && boxes.Count == restingArea.childCount + dragArea.childCount - tManager.completeCounter) {
			roundButton.interactable = true;
		} else {
			roundButton.interactable = false;
        }
	}
}
