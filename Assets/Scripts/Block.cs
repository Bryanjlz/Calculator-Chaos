using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour {
	public int number;
	public Anchored currentAnchor;
	bool isDragging = false;

	public void SetNumber (int n) {
		number = n;
		gameObject.transform.GetChild(0).GetComponent<Text>().text = n.ToString();
	}

	private void Update() {
		// Drag
		if (isDragging) {
			transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Input.GetMouseButtonUp(0)) {
				Release();
			} 
		}
	}
	
	// Drag
	private void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			isDragging = true;
		}
	}

	private void Release() {
		isDragging = false;
		// Look for close anchor to go to
		foreach (GameObject anchor in GameObject.FindGameObjectsWithTag("Anchor")) {
			if (Vector2.Distance(transform.position, anchor.transform.position) <= 1f) {
				Anchored anchorScript = anchor.GetComponent<Anchored>();
				if (TryAnchor (anchorScript)) {
					return;
				}
			}
		}
		// If none, go back to prev
		transform.position = (Vector2)currentAnchor.transform.position;
	}

	public bool TryAnchor (Anchored anchor) {
		// Check if anchorable
		if (anchor != null && anchor.IsAnchorable(gameObject)) {
			// Unanchor
			if (currentAnchor != null) {
				currentAnchor.UnAnchor(gameObject);
			}
			// Set anchor
			currentAnchor = anchor;
			transform.position = (Vector2)anchor.transform.position;
			// Run anchored script
			anchor.Anchor(gameObject);
			return true;
		}
		return false;
	}
}
