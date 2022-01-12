using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnDelay;
    private float lastSpawn = 0;
    
    void Update()
    {
        CreatePipe();
    }

    private void CreatePipe()
    {
        if(Time.time - lastSpawn > spawnDelay)
        {
            Instantiate(pipePrefab, gameObject.transform);
            lastSpawn = Time.time;
        }
    }
}
