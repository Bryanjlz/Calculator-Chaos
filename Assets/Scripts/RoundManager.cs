using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    [SerializeField] int maxRounds;
    [SerializeField] Text text;
    [SerializeField] EquationManager equationManager;
    public int currentRound;

    private void Start() {
        text.text = "Round " + currentRound + "/" + maxRounds;
    }
    public void ProgressRound () {
        currentRound++;
        text.text = "Round " + currentRound + "/" + maxRounds;
        equationManager.resetEquations();
    }

    public bool IsLastRound () {
        return currentRound >= maxRounds;
    }

}
