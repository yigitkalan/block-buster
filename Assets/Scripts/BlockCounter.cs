using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCounter : MonoBehaviour
{
    private static int currentBreakableBlocks;
    [SerializeField] private GameObject completeCanvas;
    [SerializeField] private GameObject ball;

    private void Awake()
    {
        currentBreakableBlocks = 0;
    }
    public void addBlock()
    {
        currentBreakableBlocks++;
    }

    public void removeBlocks()
    {
        currentBreakableBlocks--;
        Debug.Log("Remanining Blocks = " + currentBreakableBlocks);
        if (currentBreakableBlocks == 0)
        {
            ball.SetActive(false);
            completeCanvas.SetActive(true);
        }
    }

   
}
