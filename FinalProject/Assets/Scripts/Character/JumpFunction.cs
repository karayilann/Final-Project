using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFunction : MonoBehaviour
{
    public float movementSpeed;
    public float jumpPower;
    public float jumpGravity;

    public Rigidbody2D rb2d;

    bool isGround = false;

    void Update()
    {
        CharactersJump();
    }

    /// <summary>
    /// Karakterin zýplama fonksiyonunu içerir.
    /// </summary>
    void CharactersJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround) 
        {
            rb2d.gravityScale = jumpGravity;
            rb2d.velocity = Vector3.up * jumpPower;
        }
        else if(rb2d.velocity.y > 0)
        {
            rb2d.gravityScale = 10f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }
}
