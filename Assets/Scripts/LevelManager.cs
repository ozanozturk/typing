using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text scoreDisplay;
    private Runner runner;
    private Vector3 lastCheckPoint;
    private int score;

    private void Start()
    {
        runner = FindObjectOfType<Runner>();
    }

    public void IncreaseScore(int scoreValue)
    {
        score += scoreValue;
        scoreDisplay.text = "Score: " + score;
    }

    public void RestartLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void CheckpointReached(Vector3 checkPointPosition)
    {
        lastCheckPoint = checkPointPosition;
    }

    public void RestartFromCheckpoint()
    {
        IncreaseScore(-score);

        if (lastCheckPoint == Vector3.zero)
        {
            RestartLevel();
        }
        else
        {
            runner.transform.position = lastCheckPoint;
        }
    }

    public void SwitchLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(sceneIndex + 1, LoadSceneMode.Single);
        }
    }
}
