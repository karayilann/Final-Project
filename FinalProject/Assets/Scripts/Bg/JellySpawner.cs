using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellySpawner : MonoBehaviour
{
    public GameObject jellyPrefab;
    public float spawnWait;  // Asteroitler arasý beklemesi gereken süre
    public int startSpawn;  // Spawnlamasý için oyun baþladýktan sonra beklemesi gereken süre
    public int spawnCount;  // her defada kaç tane asteroit gönderilecek
    public int waveWait;    // Asteroit yaðmuru olmadan önce beklemesi gereken süre
    private EventSea eventScript;
    private Camera cameraScript;
    private Movement movementScript;
    private bool jellyCheck;

    public bool isSpawn;

    private void Start()
    {
        eventScript = GameObject.Find("Game Manager").GetComponent<EventSea>();
        cameraScript = GameObject.Find("Main Camera").GetComponent<Camera>();
        movementScript = GameObject.Find("Blue").GetComponent<Movement>();
        //jellyPrefab.SetActive(false);
        jellyCheck = false;
    }

    void Update()
    {
        if (eventScript.isSpawnable == true && eventScript.whichEvent == 0)
        {
            StartCoroutine(Jelly());
            jellyCheck = true;
        }

    }

    IEnumerator Jelly()
    {


        if (eventScript.isSpawnable == true)
        {
            //cameraScript.isMoving = false;
            //jellyPrefab.SetActive(true);
            yield return new WaitForSeconds(spawnWait);
            if(jellyCheck == true)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-8, 8), transform.position.y, 0);  // x y ve z de nerelerde spawn olmasý gerektiðini yazdýk.
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(jellyPrefab, spawnPosition, spawnRotation);

            }
            jellyCheck = false;

            //jellyPrefab.SetActive(false);
            //cameraScript.isMoving = true;
            eventScript.isSpawnable = false;
            movementScript.levelUnlockSpace += 1;

        }




    }

    IEnumerator SpawnAsteroit()
    {
        while (eventScript.isSpawnable)
        {
            isSpawn = true;
            //platform.SetActive(true);
            cameraScript.isMoving = false;
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-8, 8), transform.position.y, 0);  // x y ve z de nerelerde spawn olmasý gerektiðini yazdýk.
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(jellyPrefab, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            isSpawn = false;
            //platform.SetActive(false);
            cameraScript.isMoving = true;
            movementScript.levelUnlockSpace += 1;
            //eventScript.isSpawnable = false;

        }

    }

}
