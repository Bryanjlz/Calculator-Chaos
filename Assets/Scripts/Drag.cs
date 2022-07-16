using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour {
    bool isDragging = false;

    private void Update() {
        if (isDragging) {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonUp (0)) {
                isDragging = false;
            } 
        }
    }
    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            isDragging = true;
        }
    }
}
