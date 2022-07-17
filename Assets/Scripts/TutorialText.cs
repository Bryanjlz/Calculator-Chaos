using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    [SerializeField] Text textAa;
    public void SetText(string text, int pos) {
        textAa.text = text;
        transform.position = new Vector2(0f, 7f - (pos * 2.66f));
    }
}
