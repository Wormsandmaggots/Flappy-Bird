using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerAndDestroyer : MonoBehaviour
{
    public float spawnDelay;
    private float lastSpawn = 0;
    public float range;
    
    public GameObject pipePrefab;
    public List<Pipe> pipes = new List<Pipe>();

    void Update()
    {
        CreatePipe();
        DestroyBombedPipes();
    }

    private void CreatePipe()
    {
        if(Time.time - lastSpawn > spawnDelay)
        {
            GameObject pipe = Instantiate(pipePrefab, gameObject.transform);
            pipe.transform.position += new Vector3(0, Random.Range(-range, range), 0);
            lastSpawn = Time.time;
        }
    }

    private void DestroyBombedPipes()
    {
        if(GameManager.instance.bombUsed)
        {
            for (int i = 0; i < pipes.Count; i++)
            {
                if(pipes[i].isVisible)
                {
                    pipes[i].RemovePipe();

                    i--;
                }
            }

            GameManager.instance.bombsAmount--;
            GameManager.instance.bombUsed = false;
        }
    }

}
