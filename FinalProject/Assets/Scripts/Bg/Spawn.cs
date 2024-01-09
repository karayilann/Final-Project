using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public GameObject Prefab;
    [Range(0f, 100f)] public float Chance = 100f;

    [HideInInspector] public double weight;
}

public class Spawn : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;

    private double accumulatedWeights;
    private System.Random rand = new System.Random();

    public float minX = 0f;
    public float maxX = 10f;
    public float minY = 0.5f;
    public float maxY = 2f;
    public int numberOfPlatforms;
    public int platformCount;
  

    private Vector3 spawnPosition;


    private void Awake()
    {
        CalculateWeights();
    }

    private void Start()
    {
        platformCount = 0;


        spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(minX, maxX);
            SpawnRandom(new Vector2(spawnPosition.x, spawnPosition.y));
        }   
       
    }

    private void Update()
    {
        if (platformCount == numberOfPlatforms - 10)
        {
            for (int i = 0; i < numberOfPlatforms; i++)
            {
                spawnPosition.y += Random.Range(minY, maxY);
                spawnPosition.x = Random.Range(minX, maxX);
                SpawnRandom(new Vector2(spawnPosition.x, spawnPosition.y));
            }

        }
    }

    private void SpawnRandom(Vector2 position)
    {
        Enemy randomEnemy = enemies[GetRandomEnemyIndex()];

        Instantiate(randomEnemy.Prefab, position, Quaternion.identity, transform);
    }

    private int GetRandomEnemyIndex()
    {
        double r = rand.NextDouble() * accumulatedWeights;

        for (int i = 0; i < enemies.Length; i++)
            if (enemies[i].weight >= r)
                return i;

        return 0;
        
    }

    private void CalculateWeights()
    {
        accumulatedWeights = 0f;

        foreach (Enemy enemy in enemies)
        {
            accumulatedWeights += enemy.Chance;
            enemy.weight = accumulatedWeights;
        }
    }

}
