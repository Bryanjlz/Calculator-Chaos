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
    public int currentRound;

    //save data
    public List<int> inventoryNumbers;
    public List<int> completeTargets;

    private void Start() {
        text.text = "Round " + currentRound + "/" + maxRounds;
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

    public void ResetRound() {
        print(2);
        inventoryManager.ResetInv();
        targetManager.ResetTargets();
    }
}
