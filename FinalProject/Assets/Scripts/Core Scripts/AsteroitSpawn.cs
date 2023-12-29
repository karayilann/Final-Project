using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroitSpawn : MonoBehaviour
{
    public GameObject asteroitPrefab;
    public float spawnWait;  // Asteroitler arasý beklemesi gereken süre
    public int startSpawn;  // Spawnlamasý için oyun baþladýktan sonra beklemesi gereken süre
    public int spawnCount;  // her defada kaç tane asteroit gönderilecek
    public int waveWait;    // Asteroit yaðmuru olmadan önce beklemesi gereken süre

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
                Vector3 spawnPosition = new Vector3(Random.Range(-8, -1), transform.position.y, 0);  // x y ve z de nerelerde spawn olmasý gerektiðini yazdýk.
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(asteroitPrefab, spawnPosition, spawnRotation);
                Debug.Log("Oluþturuldu");
                yield return new WaitForSeconds(spawnWait);
            }
            isSpawn = false;
            yield return new WaitForSeconds(waveWait);
            Debug.Log(waveWait + " bitti! ");
        }
        
    }

}
