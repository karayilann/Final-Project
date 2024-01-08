using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AsteroitCollision : MonoBehaviour
{
    public GameObject losePanel;
    public bool isTrigged = false;
    void Start()
    {
        losePanel.SetActive(false);
    }

    private void Update()
    {
        Debug.Log(isTrigged);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(" Karaktere temas var");
            isTrigged = true;
            losePanel.SetActive(!isTrigged);
            
        }
    
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("Platforma temas var");
        }
    
    }
}
