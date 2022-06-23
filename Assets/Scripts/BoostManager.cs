using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    private int currentBoost;
    [SerializeField] private RandomBoosts boosts;


    private void Start()
    {
        boosts = FindObjectOfType<RandomBoosts>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(currentBoost)
        {
            case 0:
                boosts.enlargeLauncher();
                break;
            case 1:
                boosts.smallerLauncher();
                break;
            case 2:
                boosts.fasterBall();
                break;
            case 3:
                boosts.biggerBall();
                break;
            case 4:
                boosts.smallerBall();
                break;
            case 5:
                boosts.addTime();
                break;
            default:
                break;
        }

        GetComponent<SpriteRenderer>().sprite = null;
        this.gameObject.SetActive(false);
        boosts.setIsThereBoost(false);
    }

    public void setCurrentBoost(int boostType)
    {
        currentBoost = boostType;
    }

    /*
     * 0.ENLARGE LAUNCHER
     * 1.MAKE LAUNCHER SMALLER
     * 2.MAKE BALL FASTER
     * 3.MAKE BALL BIGGER
     * 4.MAKE BALL SMALLER
     * 5.ADD 10 SECOND     
     */
}
