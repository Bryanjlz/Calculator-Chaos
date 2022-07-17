using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equation : MonoBehaviour
{
	[SerializeField] public List<Operator> op;
	[SerializeField] List<Text> opText;
	[SerializeField] public List<EquationInputAnchor> inputAnchors;
	[SerializeField] public EquationOutputAnchor outputAnchor;
	[SerializeField] GameObject boxPrefab;
	public GameObject restCan;
	public GameObject dragCan;

	private void Start() {
		SetOperator(op[0], 0);
	}

	public void SetOperator (Operator o, int index) {
		op[index] = o;
		switch (op[index]) {
			case Operator.ADD:
				opText[index].text = "+";
				break;
			case Operator.SUB:
				opText[index].text = "-";
				break;
			case Operator.MUL:
				opText[index].text = "x";
				break;
		}
	}

	public void EquatePreview() {
		// No preview if not all filled
		foreach (EquationInputAnchor anchor in inputAnchors) {
			if (!anchor.isFilled) {
				return;
			}
		}

		// do the math
		int result = math (inputAnchors[0].number, inputAnchors[1].number, op[0]);
		if (op.Count > 1) {
			result = math (result, inputAnchors[2].number, op[1]);
		}

		// Create preview
		CreateOutputBox(result);
	}

	private int math (int in1, int in2, Operator o) {
		switch (o) {
			case Operator.ADD:
				return in1 + in2;
			case Operator.SUB:
				return in1 - in2;
			case Operator.MUL:
				return in1 * in2;
		}
		return 0;
	}

	private void CreateOutputBox (int number) {
		GameObject boxObject = Instantiate(boxPrefab);
		boxObject.transform.SetParent(restCan.transform);
		Block block = boxObject.GetComponent<Block>();
		block.SetNumber(number);
		block.transform.position = (Vector2)outputAnchor.gameObject.transform.position;
		block.currentAnchor = outputAnchor;
		block.SetTextCanvas(restCan, dragCan);
		outputAnchor.box = boxObject;
		// Set transparent
		boxObject.GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 0.4f);
	}

	public void resetInputs()
    {
		foreach (EquationInputAnchor anchor in inputAnchors)
		{
			anchor.Unlock();
		}
	}
}
