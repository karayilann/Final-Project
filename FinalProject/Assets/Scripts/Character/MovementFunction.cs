using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFunction : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb2d;

    void Update()
    {
        CharactersMovement();
    }

    private void CharactersMovement()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            rb2d.velocity = Vector2.left * movementSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rb2d.velocity = Vector2.right * movementSpeed;
        }
    }

}
