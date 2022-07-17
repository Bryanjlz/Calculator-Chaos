using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetAnchor : Anchored
{
    [SerializeField] public int targetNumber;
    [SerializeField] TargetManager tManager;
    [SerializeField] InventoryManager iManager;
    [SerializeField] public Sprite deadBox;
    bool isFilled = false;
    public bool getIsFilled()
    {
        return isFilled;
    }
    public void Start()
    {
        
        if (deadBox != null)
        {
            gameObject.transform.GetComponent<SpriteRenderer>().sprite = deadBox;
            gameObject.transform.GetChild(0).GetComponent<Text>().text = "";

            // prevent interaction
            isFilled = true;
        } else
        {
            gameObject.transform.GetChild(0).GetComponent<Text>().text = targetNumber.ToString();
        }
    }

    // Start is called before the first frame update
    public override void Anchor(GameObject draggedBox)
    {
        Block currentBlock = draggedBox.GetComponent<Block>();
        currentBlock.GetComponent<Block>().enabled = false;
        currentBlock.GetComponent<SpriteRenderer>().sprite = currentBlock.getTargetSprite();
        isFilled = true;

        tManager.completeCounter++;
        iManager.CheckCarryOver();

        if (tManager.checkWin())
        {
            tManager.celebrate();
            tManager.setCompleted(true);
        }
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
