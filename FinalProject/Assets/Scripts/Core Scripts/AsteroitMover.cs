using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroitMover : MonoBehaviour
{

    Rigidbody2D physic;
    [SerializeField] float speed;

    void Start()
    {

        physic = GetComponent<Rigidbody2D>();
        physic.velocity = (transform.forward) * speed;
    }

}
