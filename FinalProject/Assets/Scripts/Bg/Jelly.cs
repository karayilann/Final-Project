using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    [SerializeField] private float movingDirection = 1f;
    [SerializeField] private float maxX;
    [SerializeField] private float minX;

    void Update()
    {
        transform.Translate(movingDirection * Time.deltaTime, 0, 0);

        if (transform.position.x < minX || transform.position.x > maxX)
        {
            movingDirection *= -1;
        }
    }

}
