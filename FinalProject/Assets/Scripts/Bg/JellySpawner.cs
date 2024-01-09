using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellySpawner : MonoBehaviour
{
    public GameObject jellyPrefab;
    public float spawnWait;  // Asteroitler aras� beklemesi gereken s�re
    public int startSpawn;  // Spawnlamas� i�in oyun ba�lad�ktan sonra beklemesi gereken s�re
    public int spawnCount;  // her defada ka� tane asteroit g�nderilecek
    public int waveWait;    // Asteroit ya�muru olmadan �nce beklemesi gereken s�re
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
