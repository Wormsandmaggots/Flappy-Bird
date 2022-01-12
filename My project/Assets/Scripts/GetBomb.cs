using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetBomb : MonoBehaviour
{
    private Text bombsAmount;
    private bool added = false;

    void Start()
    {
        bombsAmount = GetComponentInChildren<Text>();
    }
    
    void Update()
    {
        SetAmount();
        IncreaseAmount();
    }

    private void IncreaseAmount()
    {
        
        if(GameManager.instance.score % 10 == 0 && GameManager.instance.bombsAmount < 3 && GameManager.instance.score != 0 && added == false)
        {
            GameManager.instance.bombsAmount++;
            added = true;
        }

        if(GameManager.instance.score % 10 != 0)
        {
            added = false;
        }
    }

    private void SetAmount()
    {
        bombsAmount.text = GameManager.instance.bombsAmount.ToString();
    }
}
