using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    // Config parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 5;
    [SerializeField] Text scoreText;

    // State variables
    [SerializeField] int currentScore = 0;

    // Awake occurs before Start in the process order
    private void Awake()
    {
        // Stores how many objects of "Game Status" there are. We only want one.
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            // This method says don't destroy in the future if there is already one.
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        // When we start, set our score to read as 0.
        scoreText.text = currentScore.ToString();
            
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = gameSpeed;
	}

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void RestartScore()
    {
        Destroy(gameObject);
    }

}
