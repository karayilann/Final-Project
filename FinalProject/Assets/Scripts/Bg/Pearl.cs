using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pearl : MonoBehaviour
{
    [SerializeField] private float pearlSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, pearlSpeed * Time.deltaTime, 0);
    }
}
