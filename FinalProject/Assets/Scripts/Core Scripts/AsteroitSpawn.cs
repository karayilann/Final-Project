using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroitSpawn : MonoBehaviour
{
    public GameObject asteroitPrefab;
    public float spawnWait;
    public int startSpawn;
    public int spawnCount;
    public int waveWait;



    void Start()
    {
        StartCoroutine(SpawnAsteroit());
    }


    void Update()
    {
        
    }

    IEnumerator SpawnAsteroit()
    {
        yield return new WaitForSeconds(startSpawn);
        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-8, -1), 8, 0);  // x y ve z de nerelerde spawn olmasý gerektiðini yazdýk.
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(asteroitPrefab, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

}
