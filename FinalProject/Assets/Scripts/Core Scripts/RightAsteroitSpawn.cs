using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightAsteroitSpawn : MonoBehaviour
{
    public GameObject asteroitPrefab;
    public float spawnWait;
    public int startSpawn;
    public int spawnCount;
    public int waveWait;

    public bool isSpawn;


    void Start()
    {
        StartCoroutine(SpawnAsteroit());
    }

    IEnumerator SpawnAsteroit()
    {
        yield return new WaitForSeconds(startSpawn);
        while (true)
        {
            isSpawn = true;
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(0.5f, 8.5f), transform.position.y, 0);  // x y ve z de nerelerde spawn olmasý gerektiðini yazdýk.
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(asteroitPrefab, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
            isSpawn = false;
            yield return new WaitForSeconds(waveWait);
        }

    }

}
