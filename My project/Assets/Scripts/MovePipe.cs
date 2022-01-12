using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    public float speed;
    public float destroyDelay;
    
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        Destroy(gameObject, destroyDelay);
    }


}
