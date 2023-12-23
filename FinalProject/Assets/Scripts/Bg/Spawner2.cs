using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public GameObject platformPrefab;

    public int numberOfPlatforms = 200;
    public float minX = 0f;
    public float maxX = 10f;
    public float minY = 0.5f;
    public float maxY = 2f;


    void Start()
    {

        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(minX, maxX);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
