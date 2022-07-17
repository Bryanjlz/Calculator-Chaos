using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
	[SerializeField] Text text;
	public int levelNum;
	public string levelName;
	public Text levelNameText;

	public void SetNum (int num) {
		levelNum = num;
		text.text = levelNum.ToString();
	}

	public void LoadLevel() {
		LevelHolder.self.curLevel = levelNum - 1;
		SceneManager.LoadScene("Game Scene");
	}

	private void OnMouseEnter() {
		levelNameText.text = levelName.ToUpperInvariant();
	}

	private void OnMouseExit() {
		levelNameText.text = "";
	}
}
