using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
	[SerializeField] GameObject anchorParent;
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
}
