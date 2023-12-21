using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private float startTime;
    [SerializeField] private float repeatTime;


    void Start()
    {
        InvokeRepeating("Spawn", startTime, repeatTime);
    }

    void Update()
    {
        
    }

    private void Spawn()
    {
        Instantiate(platform, new Vector2(Random.Range(0, -10), transform.position.y), transform.rotation);
    }
}
