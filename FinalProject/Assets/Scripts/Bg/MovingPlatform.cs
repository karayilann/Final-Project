using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float movingDirection = 1f;
    private Spawner spawnerScript;
    private Spawner2 spawner2Script;
    private bool isTouched;
    [SerializeField] private float maxX;
    [SerializeField] private float minX;

    void Start()
    {
        spawnerScript = GameObject.Find("Game Manager").GetComponent<Spawner>();
        spawner2Script = GameObject.Find("Game Manager").GetComponent<Spawner2>();
        isTouched = false;
    }


    void Update()
    {
        transform.Translate(movingDirection * Time.deltaTime, 0, 0);

        if(transform.position.x > minX || transform.position.x < maxX)
        {
            movingDirection *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && isTouched == false)
        {
            spawnerScript.platformCount += 1;
            isTouched = true;
        }
        else if (collision.gameObject.CompareTag("Player2") && isTouched == false)
        {
            spawner2Script.platformCount2 += 1;
            isTouched = true;
        }
    }
}
