using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {
	Vector2 currentAnchor;
	bool isDragging = false;

	// Starting Anchor
	private void Start() {
		currentAnchor = transform.position;
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
			if (Vector2.Distance(transform.position, anchor.transform.position) <= 1.02f) {
				Anchored anchorScript = anchor.GetComponent<Anchored>();
				// Check if anchorable
				if (anchorScript.IsAnchorable(gameObject)) {
					// Set anchor
					currentAnchor = anchor.transform.position;
					transform.position = (Vector2)anchor.transform.position;
					// Run anchored script
					anchorScript.Anchor(gameObject);
					return;
				}
			}
		}

		// If none, go back to prev
		transform.position = currentAnchor;
	}
}
