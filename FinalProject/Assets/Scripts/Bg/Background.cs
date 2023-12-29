using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float bgSpeed;

    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        transform.Translate(Vector2.down * bgSpeed * Time.deltaTime);

        if(transform.position.y <= -25f)
        {
            transform.position = startPos;
        }

    }
}
