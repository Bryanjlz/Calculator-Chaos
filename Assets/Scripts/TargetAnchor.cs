using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetAnchor : Anchored {
	[SerializeField] public int targetNumber;
	[SerializeField] TargetManager tManager;
	[SerializeField] InventoryManager iManager;
	[SerializeField] public Sprite deadBox;
	public bool isDead;
	public bool isFilled = false;

	public override void Anchor(GameObject draggedBox) {
		Block currentBlock = draggedBox.GetComponent<Block>();
		currentBlock.GetComponent<Block>().enabled = false;
		currentBlock.GetComponent<SpriteRenderer>().sprite = currentBlock.getTargetSprite();
		isFilled = true;

		tManager.completeCounter++;
		iManager.CheckCarryOver();

		if (tManager.checkWin()) {
			tManager.celebrate();
		}
	}

	public override void UnAnchor(GameObject draggedBox) {
		isFilled = false;
	}

	public override bool IsAnchorable(GameObject draggedBox) {
		if (draggedBox.GetComponent<Block>().number == targetNumber) {
			return !isFilled;
		} else {
			return false;
		}
	}

	public void LoadData (bool dead, int num) {
		if (dead) {
			isDead = true;
			isFilled = true;
            gameObject.transform.GetComponent<SpriteRenderer>().sprite = deadBox;
            gameObject.transform.GetChild(0).GetComponent<Text>().text = "";
        } else {
			targetNumber = num;
			gameObject.transform.GetChild(0).GetComponent<Text>().text = targetNumber.ToString();
		}
    }
}
