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
	[SerializeField] RoundManager rManager;
	public List<GameObject> boxes;
	public List<InventoryAnchor> anchors;
	

	private void Awake() {
		boxes = new List<GameObject>();
		anchors = new List<InventoryAnchor>();
		foreach(InventoryAnchor anchor in anchorParent.GetComponentsInChildren<InventoryAnchor>()) {
			anchors.Add(anchor);
		}
	}
	
	public void CheckCarryOver() {
		if (boxes.Count <= carryOverCount && boxes.Count == restingArea.childCount + dragArea.childCount - tManager.completeCounter && !rManager.IsLastRound()) {
			roundButton.interactable = true;
		} else {
			roundButton.interactable = false;
		}
	}

	public List<int> GetNumbers () {
		List<int> numbers = new List<int>();
		foreach (GameObject bo in boxes) {
			numbers.Add(bo.GetComponent<Block>().number);
		}
		return numbers;
	}

	public void ResetInv() {
		for (int i = restingArea.childCount - 1; i >= 0; i--) {
			Destroy(restingArea.GetChild(i).gameObject);
		}
		boxes.Clear();
		foreach (InventoryAnchor ia in anchors) {
			if (ia.deadBox == null) {
				ia.isFilled = false;
			}
		}
	}

	public void LoadLevelData (int invSlots) {
		for (int i = anchors.Count - 1; i >= invSlots; i--) {
			print(i);
			anchors[i].LoadLevelData(true);
        }
    }
}
