using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
	[SerializeField] GameObject anchorParent;
	[SerializeField] Transform restArea;
	List<TargetAnchor> targets;
	public int completeCounter;
	bool isComplete = false;
	// Start is called before the first frame update
	void Start()
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
			if (target.getIsFilled() == false)
			{
				return false;
			}
		}
		return true;
	}

	public void setCompleted(bool verdict)
	{
		isComplete = verdict;
	}

	public void celebrate()
	{
		Debug.Log("you win!");
	}

	public List<int> GetCompleted () {
		List<int> completeTargets = new List<int>();
		foreach (TargetAnchor ta in targets) {
			if (ta.getIsFilled() && ta.deadBox == null) {
				completeTargets.Add(ta.targetNumber);
			}
		}
		return completeTargets;
	}

	public void ResetTargets() {
		foreach (TargetAnchor ta in targets) {
			if (ta.deadBox == null) {
				ta.isFilled = false;
			}
		}
		completeCounter = 0;
	}
	public void LoadTargets(List<int> completeTargets, List<GameObject> targetBoxes) {
		for (int i = 0; i < completeTargets.Count; i++) {
			Transform box = targetBoxes[i].transform;
			int num = completeTargets[i];
			foreach (TargetAnchor ta in targets) {
				if (ta.targetNumber == num && !ta.isFilled) {
					box.position = ta.transform.position;
					box.GetComponent<Block>().TryAnchor(ta);
				}
			}
		}
	}
}
