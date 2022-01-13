using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighestScores : MonoBehaviour
{
    public Text[] highestScores = new Text[5];
    private bool updated = false;
    void Start()
    {
        highestScores = GetComponentsInChildren<Text>();
    }

    void Update() 
    {
        UpdateHighScore();
    }

    void OnDisable() {
        updated = false;
    }

    private void UpdateHighScore()
    {
        if(GameManager.instance != null && !updated)
        {
            for (int i = 0; i < GameManager.instance.highestScores.Count; i++)
            {
                if(GameManager.instance.highestScores[i] == 0)
                {
                    highestScores[i].text = "-";
                }
                else    
                {
                    highestScores[i].text = GameManager.instance.highestScores[i].ToString();
                }
            }

            updated = true;
        }
    }

}
