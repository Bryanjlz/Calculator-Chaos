using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour {
	[SerializeField] Color inactive;
	[SerializeField] GameObject boxes;
	[SerializeField] List<int> generationPool;
	[SerializeField] int generateCount;

    private void Start() {
		for (int i = 0; i < 6; i++) {
			GameObject box = boxes.transform.GetChild(i).gameObject;
			if (i < generationPool.Count) {
				box.transform.GetChild(0).GetComponent<Text>().text = generationPool[i].ToString();
			} else {
				box.GetComponent<SpriteRenderer>().color = inactive;
            }
		}
	}

    public void Generate() {
		List<int> generatedPool = new List<int>();
		for (int i = 0; i < generateCount; i++) {
			generatedPool.Add(generationPool[Random.Range(0, generationPool.Count - 1)]);
			print(generatedPool[i]);
		}
	}
}
