using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour {
	[SerializeField] List<int> generationPool;
	[SerializeField] int generateCount;
	[SerializeField] GameObject boxPrefab;
	[SerializeField] InventoryManager invManager;
	[SerializeField] GameObject draggingTextCanvas;
	[SerializeField] GameObject restingTextCanvas;
	[SerializeField] Button roundButton;
	[SerializeField] Color inactive;
	[SerializeField] GameObject genBoxParent;

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
		roundButton.transform.GetChild(0).GetComponent<Text>().text = "End Turn";
		invManager.CheckCarryOver();

	}

	public void CreateBox(int number) {
		GameObject boxObject = Instantiate(boxPrefab);
		boxObject.transform.SetParent(restingTextCanvas.transform);
		Block block = boxObject.GetComponent<Block>();
		block.SetNumber(number);
		block.SetTextCanvas(restingTextCanvas, draggingTextCanvas);
		foreach (InventoryAnchor anchor in invManager.anchors) {
			if (block.TryAnchor(anchor)) {
				return;
			}
		}
	}
}
