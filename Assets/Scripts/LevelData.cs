using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelData : ScriptableObject {
	public int numRounds;

	[Space(15)]
	public int invSlots;

	[Space(15)]
	public int genCount;
	public List<int> generationPool;

	[Space(15)]
	public List<int> targets;

	[Space(15)]
	public bool isRandomEquation;
	[Tooltip("Only used if random")]
	public int numEquations;

	[Space(10)]
	[Tooltip("Only used if not random")]
	public List<Operator> operators;

	[Space(10)]
	public List<string> text;
	public List<Vector2> pos;
}
