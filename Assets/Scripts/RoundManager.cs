using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
	[SerializeField] int maxRounds;
	[SerializeField] Text text;
	[SerializeField] List<Button> buttons;
	[SerializeField] EquationManager equationManager;
	[SerializeField] InventoryManager inventoryManager;
	[SerializeField] TargetManager targetManager;
	[SerializeField] Generator generator;
	[SerializeField] LevelData level;
	public int currentRound;
	public bool pause;

	//save data
	public List<int> inventoryNumbers;
	public List<int> completeTargets;

	private void Start() {
		// Get Level
		if (LevelHolder.self != null) {
			level = LevelHolder.self.curLevel;
		}

		// Load Level
		LoadLevelData(level.numRounds);
		equationManager.LoadLevelData(level.isRandomEquation, level.numEquations, level.operators);
		inventoryManager.LoadLevelData(level.invSlots, level.genCount);
		targetManager.LoadLevelData(level.targets);
		generator.LoadLevelData(level.genCount, level.generationPool);
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

	public void UndoRound () {
		ResetRound();
		Load();
	}

	public void PauseScene() {
		SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
		Pause();
    }

	public void Pause () {
		pause = true;
    }

	public void UnPause() {
		pause = false;
	}

	public void LoadLevelData (int numRounds) {
		maxRounds = numRounds;
		text.text = "Round " + currentRound + "/" + maxRounds;
	}
}
