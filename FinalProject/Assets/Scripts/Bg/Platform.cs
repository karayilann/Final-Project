using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float bgSpeed;
    private BoxCollider2D platformCollider;

    void Start()
    {
        platformCollider = GetComponent<BoxCollider2D>(); 
    }

    
    void Update()
    {
        transform.Translate(Vector2.down * bgSpeed * Time.deltaTime);


        if(transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }


    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.CompareTag("Feet"))
    //    {
    //        platformCollider.enabled = true;
    //    }
             
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if(collision.gameObject.CompareTag("Feet"))
    //    {
    //        platformCollider.enabled = false;
    //    }
    //}
}
