using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Spawner spawnerScript;
    private Spawner2 spawner2Script;
    private bool isTouched;

    void Start()
    {
        spawnerScript = GameObject.Find("Game Manager").GetComponent<Spawner>();
        spawner2Script = GameObject.Find("Game Manager").GetComponent<Spawner2>();
        isTouched = false;
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && isTouched == false)
        {
            spawnerScript.platformCount += 1;
            isTouched = true;
        }
        else if(collision.gameObject.CompareTag("Player2") && isTouched == false)
        {
            spawner2Script.platformCount2 += 1;
            isTouched = true;
        }
    }
}
