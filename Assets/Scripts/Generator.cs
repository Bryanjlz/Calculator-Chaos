using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour {
	[SerializeField] Color inactive;
	[SerializeField] GameObject genBoxParent;
	[SerializeField] List<int> generationPool;
	[SerializeField] int generateCount;
	[SerializeField] GameObject boxPrefab;
	[SerializeField] Transform boxParent;
	[SerializeField] InventoryManager invManager;

	private void Start() {
		for (int i = 0; i < 6; i++) {
			GameObject box = genBoxParent.transform.GetChild(i).gameObject;
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
			generatedPool.Add(generationPool[Random.Range(0, generationPool.Count)]);
			CreateBox(generatedPool[i]);
		}
	}

	public void CreateBox(int number) {
		GameObject boxObject = Instantiate(boxPrefab);
		boxObject.transform.SetParent(boxParent);
		Block block = boxObject.GetComponent<Block>();
		block.SetNumber(number);
		foreach (InventoryAnchor anchor in invManager.anchors) {
			if (block.TryAnchor(anchor)) {
				return;
			}
		}
	}
}
