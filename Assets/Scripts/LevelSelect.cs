using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {
	[SerializeField] GameObject levelPrefab;
	[SerializeField] Transform levelGrid;
	[SerializeField] Text levelNameText;
	private List<LevelData> levels;
	void Start() {
		levels = LevelHolder.self.levelData;
		for (int i = 0; i < levels.Count; i++) {
			GameObject level = Instantiate(levelPrefab);
			level.transform.SetParent(levelGrid);

			LevelSelectButton button = level.GetComponent<LevelSelectButton>();
			button.SetNum(i + 1);
			button.levelName = levels[i].name;
			button.levelNameText = levelNameText;
		}
	}
}
