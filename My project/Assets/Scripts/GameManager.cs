using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour, IComparer<int>
{
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

            startScreen.SetActive(true);
            gameOverScreen.SetActive(false);
        newHighScoreScreen.SetActive(false);

        instance = this;

        SetTimeScale(0);
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

        int[] temp = new int[highestScores.Count];
        highestScores.CopyTo(temp);

        highestScores.Add(score);
        highestScores.Sort(Compare);
        if(highestScores.Count == highestAmount + 1)
        {
            highestScores.RemoveAt(highestAmount);
        }

        Array.Sort(temp, Compare);
        if(Change(temp, highestScores))
        {
            Debug.Log("NEW");
            newHighScoreScreen.SetActive(true);
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

    private bool Change(int[] tab, List<int> list)
    {
        for (int i = 0; i < tab.Length; i++)
        {
            if(list[i] != tab[i])
                return false;
        }

        return true;
    }
}
