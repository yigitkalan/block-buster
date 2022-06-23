using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private SceneLoader sl;

    private void Start()
    {
        sl = FindObjectOfType<SceneLoader>();
    }
    public void nextLevel()
    {
        FindObjectOfType<GameStatus>().resetLevelTimer();
        sl.LoadNextScene();

    }
}
