using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            Time.timeScale = 0;
        }

        if(collision.gameObject.CompareTag("Platform"))
        {
            Destroy(collision.gameObject);
        }
    }
}
