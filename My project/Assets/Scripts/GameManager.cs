using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour, IComparer<int>
{
    public bool bombUsed = false;
    public int highestAmount = 5;
    public int score = 0;
    public int bombsAmount = 0;
    public List<int> highestScores = new List<int>();

    public static GameManager instance;

    public GameObject startScreen;
    public GameObject gameOverScreen;
    public GameObject newHighScoreScreen;

    void Awake() {

        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        startScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        newHighScoreScreen.SetActive(false);

        SetTimeScale(0);
    }

    void Update() {

        if(Input.GetKeyDown(KeyCode.B))
            SetTimeScale(0);
            
        UseBomb();
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        UpdateHighestScores();
        SetTimeScale(0);
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        score = 0;
        bombsAmount = 0;
    }

    private void UpdateHighestScores()
    {
        if(score == 0)
        {
            return;
        }

        int amount = highestScores.Count;

        highestScores.Add(score);

        int temp = highestScores[highestScores.Count - 1];

        highestScores.Sort(Compare);
        if(highestScores.Count == highestAmount + 1)
        {
            highestScores.RemoveAt(highestAmount);
        }
        
        if(temp != highestScores[highestScores.Count - 1] || amount < highestScores.Count)
        {
            newHighScoreScreen.SetActive(true);
        }
    }

    private void UseBomb()
    {
        if(((Input.touchCount > 0 && Input.GetTouch(0).tapCount == 2) || Input.GetKeyDown(KeyCode.A)) && bombsAmount > 0)
        {
            bombUsed = true;
        }
    }

    public int Compare(int a, int b)
    {
        return b.CompareTo(a);
    }

    public void SetTimeScale(int scale)
    {
        Time.timeScale = scale;
    }
}
