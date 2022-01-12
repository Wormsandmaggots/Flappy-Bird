using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoint : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other) {
        GameManager.instance.score++;
    }
}
