using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour
{
    private Text scoreAmount;
    
    void Start() {
        scoreAmount = GetComponent<Text>();
    }

    void Update()
    {
        scoreAmount.text = GameManager.instance.score.ToString();
    }
}
