using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private GameObject backGround;
    [SerializeField] private float bound;

    void Start()
    {
        
    }


    void Update()
    {
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            Instantiate(backGround, new Vector3(transform.position.x, transform.position.y + bound, transform.position.z), Quaternion.identity);
        }
    }
}
