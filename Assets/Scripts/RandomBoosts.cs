using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBoosts : MonoBehaviour
{
    [SerializeField] private GameStatus gs;
    [SerializeField] private LauncherControl launcher;
    [SerializeField] private BallController ball;

    private bool isThereBoost = false;
    [SerializeField] private BoostManager[] places;
    [SerializeField] private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        gs = FindObjectOfType<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gs.getPassedTime() % 15 == 0)
        {
            if(gs.getPassedTime() != 0)
            {
                GenerateBoost();
            }           
        }
    }

    void GenerateBoost()
    {
        if(isThereBoost == false)
        {
            int tmpPlace = (int)Random.Range(-0.1f, 4.9f);
            int tmpBoost = (int)Random.Range(-0.1f, 5.9f);

            places[tmpPlace].gameObject.SetActive(true);
            places[tmpPlace].gameObject.GetComponent<SpriteRenderer>().sprite = sprites[tmpBoost];
            places[tmpPlace].setCurrentBoost(tmpBoost);
            isThereBoost = true;
        }
    }

    public void enlargeLauncher()
    {
        launcher.transform.localScale += new Vector3(launcher.transform.localScale.x / 2, 0, 0);
        launcher.setMinMax(5.75f);
    }

    public void smallerLauncher()
    {
        launcher.transform.localScale += new Vector3(-launcher.transform.localScale.x / 2, 0, 0);
        launcher.setMinMax(7.25f);
    }

    public void fasterBall()
    {
        ball.ballSpeedCoef(1.5f);
    }

    public void biggerBall()
    {
        ball.transform.localScale += new Vector3(0.4f, 0.4f, 0);
    }

    public void smallerBall()
    {
        ball.transform.localScale -= new Vector3(0.2f, 0.2f, 0);
    }

    public void addTime()
    {
        gs.setSecondForLevel(gs.getSecondForLevel() + 10);
    }

    public void setIsThereBoost(bool tmp)
    {
        isThereBoost = tmp;
    }
}
