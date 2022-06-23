using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    private int finalScore;
    [SerializeField] private Text finalScoreText;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name.Equals("Finish"))
        {
            finalScore = FindObjectOfType<GameStatus>().finalScore();
            Debug.Log("GİRDİK Mİ :" + finalScore);
            finalScoreText.text = "Final Score --> " + finalScore;
        }
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings - 2) //if this is the last playable level
        {
            LoadEndScene();
        }
        
        else
            SceneManager.LoadScene(currentSceneIndex + 1);       
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene("Finish");
    }
}
