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
    private Event eventScript;
    private Camera cameraScript;
    private Movement movementScript;

    public bool isSpawn;

    private void Start()
    {
        eventScript = GameObject.Find("Game Manager").GetComponent<Event>();
        cameraScript = GameObject.Find("Main Camera").GetComponent<Camera>();
        movementScript = GameObject.Find("Character").GetComponent<Movement>();
        jellyPrefab.SetActive(false);
    }

    void Update()
    {
        if (eventScript.isSpawnable == true && eventScript.whichEvent == 0)
        {
            StartCoroutine(Jelly());

        }

    }

    IEnumerator Jelly()
    {
        
            
           
            cameraScript.isMoving = false;
            
            jellyPrefab.SetActive(true);
            yield return new WaitForSeconds(spawnWait);
           
            jellyPrefab.SetActive(false);
            cameraScript.isMoving = true;
            movementScript.levelUnlockSpace += 1;
      

        

    }

}
