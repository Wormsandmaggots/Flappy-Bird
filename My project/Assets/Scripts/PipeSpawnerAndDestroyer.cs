using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerAndDestroyer : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnDelay;
    private float lastSpawn = 0;
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
            Instantiate(pipePrefab, gameObject.transform);
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
