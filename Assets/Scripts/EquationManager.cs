using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquationManager : MonoBehaviour {
	[SerializeField] int equationNum;
	[SerializeField] GameObject restCan;
	[SerializeField] GameObject dragCan;
	[SerializeField] GameObject eqPrefab;

	private void Start() {
		for (int i = 0; i < equationNum; i++) {
			List<Operator> o = new List<Operator>();
			o.Add((Operator)Random.Range(0, 3));
			CreateEquation(o, new Vector2(0f, 7f - (i * 2.66f)));
		}
	}

	private void CreateEquation (List<Operator> op, Vector2 pos) {
		GameObject eqObj = Instantiate(eqPrefab);
		Equation eq = eqObj.GetComponent<Equation>();
		eq.op = op;
		eq.restCan = restCan;
		eq.dragCan = dragCan;
		eqObj.transform.SetParent(gameObject.transform);
		eqObj.transform.position = pos;

    }
}
