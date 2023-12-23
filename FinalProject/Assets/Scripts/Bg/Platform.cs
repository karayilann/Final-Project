using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float bgSpeed;

    void Start()
    {
        
    }

    
    void Update()
    {
        //transform.Translate(Vector2.down * bgSpeed * Time.deltaTime);


        if(transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }


    }
}
