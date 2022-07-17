using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    [SerializeField] int maxRounds;
    [SerializeField] Text text;
    public int currentRound;

    private void Start() {
        text.text = "Round " + currentRound + "/" + maxRounds;
    }
    public void ProgressRound () {
        currentRound++;
        text.text = "Round " + currentRound + "/" + maxRounds;
    }

    public bool IsLastRound () {
        return currentRound >= maxRounds;
    }

}
