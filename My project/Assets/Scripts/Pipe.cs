using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed;
    public float destroyDelay;
    private float spawnTime;
    public bool isVisible;

    private PipeSpawnerAndDestroyer spawner;

    void Start() 
    {
        spawner = GetComponentInParent<PipeSpawnerAndDestroyer>();
        spawner.pipes.Add(this);
        spawnTime = Time.time;
    }

    void Update() 
    {
        if(spawnTime + destroyDelay < Time.time)
        {
            RemovePipe();
        }
    }

    void FixedUpdate()
    {
        MovePipe();
    }

    private void MovePipe()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void RemovePipe()
    {
        spawner.pipes.Remove(this);
        Destroy(gameObject);
    }
}
