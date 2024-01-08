using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameobject : MonoBehaviour
{
    public GameObject losePanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Asteroit")
        {
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.tag == "Player")
        {
            losePanel.SetActive(true);
            Debug.Log("Oyunu Kaybettin");
        }

    }
}
