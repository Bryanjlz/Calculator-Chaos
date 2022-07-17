using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHolder : MonoBehaviour
{
	// Singleton stuff
	internal static LevelHolder self;
	void OnEnable() {
		if (self != null) {
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);
		self = this;

	}

	public List<LevelData> levelData;
	public int curLevel;
}
