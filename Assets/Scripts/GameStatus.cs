using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private Text scoreText;


    [SerializeField] private float initialTime = 90;
    private float secondForLevel;
    [SerializeField] private int currentScore = 0;
    private SceneLoader sl;

    [Range(0.1f, 10)] [SerializeField] private float gameSpeed = 1f;
    private string lastRotation = ""; //for the score text effect


    //AWAKE RUNS BEFORE START METHOD
    private void Awake()
    {
        //THIS CODE INSIDE AWAKE IS CALLED SINGLETON PATTERN
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {     //if there is already a gamestatus
            gameObject.SetActive(false);    //we better do this to prevent existing of 2 objects even for a small time
            Destroy(gameObject);        //Destroy yourself before start
        }
        else
        {
            DontDestroyOnLoad(gameObject); //else if there isn't already then 
                                           //dont destroy urself on the next load
        }

    }


    //ABOVE PART IS IMPORTANT!!!! IF YOU WANT TO KEEP SOME GAMEOBJECT
    //LIKE GAMESTATUS(TO KEEP THE SCORE GO�NG) WE COULD WRITE THIS

    private void Start()
    {
        secondForLevel = initialTime + 1; //61 cuz we want to see 1:00
        timerText.text = secondForLevel.ToString("0");// that zero cuts the not whole part of number
        scoreText.text = currentScore.ToString();
        sl = FindObjectOfType<SceneLoader>();
    }
    // Update is called once per frame
    void Update()
    {
        secondForLevel -= 1 * Time.deltaTime;

        if (secondForLevel > 0) //if there is still time
        {
            int minute = (int)secondForLevel / 60; //Calculating minute and seconds
            int second = (int)secondForLevel % 60;
            if (second / 10 < 1)   // if seconds are single digit we put a zero in front of 'em
                timerText.text = minute + ":0" + second;
            else
                timerText.text = minute + ":" + second;
        }
        else
        {
            sl.LoadEndScene();
        }
        Time.timeScale = gameSpeed;
    }

    public void addScore()
    {
        currentScore += (int)secondForLevel;
        scoreText.text = currentScore.ToString();


        if (lastRotation.Equals(""))
        {
            scoreText.transform.Rotate(0, 0, 25);
            lastRotation = "r";             //TURNING SCORE LEFT AND RIGHT
        }
        else if (lastRotation.Equals("l"))
        {
            scoreText.transform.Rotate(0, 0, 50);
            lastRotation = "r";
        }
        else
        {
            scoreText.transform.Rotate(0, 0, -50);
            lastRotation = "l";
        }
    }

    public void resetGame()
    {
        Destroy(gameObject);
    }

    public void resetLevelTimer()
    {
        secondForLevel = initialTime + 1;
    }
    public int finalScore()
    {
        int tmp = currentScore;
        Destroy(gameObject);  //get rid of game status and return the final score
        return tmp;
    }

    public int getPassedTime()
    {
        return (int)(initialTime - secondForLevel);
    }

    public void setSecondForLevel(float time)
    {
        secondForLevel = time;
    }

    public float getSecondForLevel()
    {
        return secondForLevel;
    }
}
