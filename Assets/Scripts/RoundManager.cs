using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
	[SerializeField] int maxRounds;
	[SerializeField] Text text;
	[SerializeField] EquationManager equationManager;
	[SerializeField] InventoryManager inventoryManager;
	[SerializeField] TargetManager targetManager;
	[SerializeField] Generator generator;
	[SerializeField] LevelData yep;
	public int currentRound;

	//save data
	public List<int> inventoryNumbers;
	public List<int> completeTargets;

    private void Start() {
		LoadLevelData(yep.numRounds);
		equationManager.LoadLevelData(yep.isRandomEquation, yep.numEquations, yep.operators);
		inventoryManager.LoadLevelData(yep.invSlots);
		targetManager.LoadLevelData(yep.targets);
		generator.LoadLevelData(yep.genCount, yep.generationPool);
    }

    public void ProgressRound () {
		currentRound++;
		text.text = "Round " + currentRound + "/" + maxRounds;
		equationManager.resetEquations();
		generator.Generate(generator.RandomPool());
		inventoryManager.CheckCarryOver();
		Save();
	}

	public bool IsLastRound () {
		return currentRound >= maxRounds;
	}

	private void Save () {
		inventoryNumbers = inventoryManager.GetNumbers();
		completeTargets = targetManager.GetCompleted();
	}

	private void ResetRound () {
		inventoryManager.ResetInv();
		targetManager.ResetTargets();
		equationManager.resetEquations();
	}

	private void Load () {
		List<GameObject> targetBoxes = generator.Generate(completeTargets);
		targetManager.LoadTargets(completeTargets, targetBoxes);
		generator.Generate(inventoryNumbers);
	}

	public void UndoRound() {
		ResetRound();
		Load();
	}

	public void LoadLevelData (int numRounds) {
		maxRounds = numRounds;
		text.text = "Round " + currentRound + "/" + maxRounds;
	}
}
