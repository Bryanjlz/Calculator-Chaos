using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationInputAnchor : Anchored {
	[SerializeField] Equation eq;
	[SerializeField] SpriteRenderer spriteRender;
	[SerializeField] Sprite usedSprite;
	[SerializeField] Sprite unusedSprite;
	public int number;
	public GameObject box;
	public bool isFilled = false;
	public bool isActive = true;
	public override void Anchor(GameObject draggedBox) {
		isFilled = true;
		number = draggedBox.GetComponent<Block>().number;
		box = draggedBox;
		eq.EquatePreview();
	}

	public override bool IsAnchorable(GameObject draggedBox) {
		return !isFilled && isActive;
	}

	public override void UnAnchor(GameObject draggedBox) {
		isFilled = false;
		number = 0;
		box = null;
		if (eq.outputAnchor.box != null) {
			Destroy(eq.outputAnchor.box);
		}
	}

	public void Lock () {
		Destroy(box);
		spriteRender.sprite = usedSprite;
	}
	public void Unlock()
	{
		spriteRender.sprite = unusedSprite;
		isFilled = false;
	}
}
