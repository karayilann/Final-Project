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
    private Event2 eventScript;
    private Camera cameraScript;
    private Movement movementScript;

    public bool isSpawn;


    void Start()
    {
        eventScript = GameObject.Find("Game Manager").GetComponent<Event2>();
        cameraScript = GameObject.Find("Main Camera").GetComponent<Camera>();
        movementScript = GameObject.Find("Character").GetComponent<Movement>();
    }

    void Update()
    {
        if (eventScript.isSpawnable == true && eventScript.whichEvent == 0)
        {
            StartCoroutine(SpawnAsteroit());

        }

    }

    IEnumerator SpawnAsteroit()
    {
        while (eventScript.isSpawnable)
        {
            isSpawn = true;
            //cameraScript.isMoving = false;
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(0.5f, 8.5f), transform.position.y, 0);  // x y ve z de nerelerde spawn olmasý gerektiðini yazdýk.
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(asteroitPrefab, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            isSpawn = false;
            //cameraScript.isMoving = true;
            //movementScript.levelUnlockSpace += 1;

        }
    }

}
