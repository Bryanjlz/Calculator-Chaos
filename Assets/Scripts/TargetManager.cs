using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetManager : MonoBehaviour
{
	[SerializeField] GameObject anchorParent;
	[SerializeField] Transform restArea;
	[SerializeField] RoundManager roundManager;
	List<TargetAnchor> targets;
	public int completeCounter;

	// Start is called before the first frame update
	void Awake()
	{
		targets = new List<TargetAnchor>();
		foreach (TargetAnchor anchor in anchorParent.GetComponentsInChildren<TargetAnchor>())
		{
			targets.Add(anchor);
		}
	}

	public bool checkWin()
	{
		foreach (TargetAnchor target in targets)
		{
			if (!target.isFilled)
			{
				return false;
			}
		}
		return true;
	}

	public void celebrate() {
		roundManager.Pause();
		// sound!
		FindObjectOfType<AudioManager>().Play("win");
		SceneManager.LoadScene("Win",LoadSceneMode.Additive);
	}

	public List<(int,int)> GetCompleted () {
		List<(int, int) > completeTargets = new List<(int,int)>();
		for(int i = 0; i < targets.Count; i++) {
			TargetAnchor ta = targets[i];
			if (ta.isFilled && !ta.isDead) {
				completeTargets.Add((ta.targetNumber,i));
			}
		}
		return completeTargets;
	}

	public void ResetTargets() {
		foreach (TargetAnchor ta in targets) {
			if (!ta.isDead) {
				ta.isFilled = false;
			}
		}
		completeCounter = 0;
	}
	public void LoadTargets(List<(int,int)> completeTargets, List<GameObject> targetBoxes) {
		for (int i = 0; i < completeTargets.Count; i++) {
			Transform box = targetBoxes[i].transform;
			int num = completeTargets[i].Item1;
			for (int j = 0; j < targets.Count; j++) {
				TargetAnchor ta = targets[j];
				if (ta.targetNumber == num && !ta.isFilled && j == completeTargets[i].Item2) {
					box.position = ta.transform.position;
					box.GetComponent<Block>().TryAnchor(ta);
				}
			}
		}
	}

	public void LoadLevelData (List<int> targetData) {
		for (int i = 0; i < targets.Count; i++) {
			if (i < targetData.Count) {
				targets[i].LoadData(false, targetData[i]);
			} else {
				targets[i].LoadData(true, -1111);
            }
        }
    }
}
