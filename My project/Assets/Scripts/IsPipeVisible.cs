using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPipeVisible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Pipe"))
        {
            other.gameObject.GetComponentInParent<Pipe>().isVisible = true;
        }
    }

}
