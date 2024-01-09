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
    private Event eventScript;
    private Camera cameraScript;
    private Movement movementScript;
    [SerializeField] private GameObject platform;

    public bool isSpawn;

    private void Start()
    {
        eventScript = GameObject.Find("Game Manager").GetComponent<Event>();
        cameraScript = GameObject.Find("Main Camera").GetComponent<Camera>();
        movementScript = GameObject.Find("Character").GetComponent<Movement>();
        platform.SetActive(false);
    }

    void Update()
    {
        if(eventScript.isSpawnable == true && eventScript.whichEvent == 0)
        {
            StartCoroutine(SpawnAsteroit());
            
        }
        
    }

    IEnumerator SpawnAsteroit()
    {
        while (eventScript.isSpawnable)
        {
            isSpawn = true;
            platform.SetActive(true);
            cameraScript.isMoving = false;
            for (int i = 0; i < spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-8, -1), transform.position.y, 0);  // x y ve z de nerelerde spawn olmas� gerekti�ini yazd�k.
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(asteroitPrefab, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            isSpawn = false;
            platform.SetActive(false);
            cameraScript.isMoving = true;
            movementScript.levelUnlockSpace += 1;
            //eventScript.isSpawnable = false;

        }
        
    }

}
