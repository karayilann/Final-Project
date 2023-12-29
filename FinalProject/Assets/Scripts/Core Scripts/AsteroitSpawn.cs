using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroitSpawn : MonoBehaviour
{
    public GameObject asteroitPrefab;
    public float spawnWait;  // Asteroitler aras� beklemesi gereken s�re
    public int startSpawn;  // Spawnlamas� i�in oyun ba�lad�ktan sonra beklemesi gereken s�re
    public int spawnCount;  // her defada ka� tane asteroit g�nderilecek
    public int waveWait;    // Asteroit ya�muru olmadan �nce beklemesi gereken s�re

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
                Vector3 spawnPosition = new Vector3(Random.Range(-8, -1), transform.position.y, 0);  // x y ve z de nerelerde spawn olmas� gerekti�ini yazd�k.
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(asteroitPrefab, spawnPosition, spawnRotation);
                Debug.Log("Olu�turuldu");
                yield return new WaitForSeconds(spawnWait);
            }
            isSpawn = false;
            yield return new WaitForSeconds(waveWait);
            Debug.Log(waveWait + " bitti! ");
        }
        
    }

}
