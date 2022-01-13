using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        
        if(other.CompareTag("Bird"))
            GameManager.instance.score++;
    }
}
