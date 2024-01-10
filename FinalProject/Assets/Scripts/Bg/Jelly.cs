using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    [SerializeField] private float movingDirection = 1f;
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    [SerializeField] private GameObject pearlPrefab;
    private EventSea eventScript;
    [SerializeField] private int pearCount;
    [SerializeField] private float pearlWait;

    private void Start()
    {
        eventScript = GameObject.Find("Game Manager").GetComponent<EventSea>();

    }

    void Update()
    {
        transform.Translate(movingDirection * Time.deltaTime, 0, 0);

        if (transform.position.x < minX || transform.position.x > maxX)
        {
            movingDirection *= -1;
        }

        //if(eventScript.isSpawnable == true)
        //{
        //    for (int i = 0; i < pearCount; i++)
        //    {
        //        StartCoroutine(PearlSpawn());
        //    }
            
        //}


    }

    //IEnumerator PearlSpawn()
    //{
    //    yield return new WaitForSeconds(pearlWait);
    //    Instantiate(pearlPrefab, transform.position, Quaternion.identity);
        
    //}

}
