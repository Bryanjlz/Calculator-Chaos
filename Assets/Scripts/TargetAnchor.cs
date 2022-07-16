using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetAnchor : Anchored
{
    [SerializeField] int targetNumber;
    bool isFilled = false;
    public void Start()
    {
        gameObject.transform.GetChild(0).GetComponent<Text>().text = targetNumber.ToString();
    }

    // Start is called before the first frame update
    public override void Anchor(GameObject draggedBox)
    {
        Block currentBlock = draggedBox.GetComponent<Block>();
        currentBlock.GetComponent<Block>().enabled = false;
        isFilled = true;
    }
    public override void UnAnchor(GameObject draggedBox)
    {
        isFilled = false;
    }
    public override bool IsAnchorable(GameObject draggedBox)
    {
        if (draggedBox.GetComponent<Block>().number == targetNumber)
        {
            return !isFilled;
        } else
        {
            return false;
        }
    }
}
