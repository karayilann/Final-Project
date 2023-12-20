using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float jumpPower;
    public float jumpGravity;
    public float movementSpeed;

    public Rigidbody2D rb2d;

    bool isGround = false;

    void FixedUpdate()
    {
        CharactersJump();
        CharactersMovement();
    }

    /// <summary>
    /// Karakterin zýplama fonksiyonunu içerir.
    /// </summary>
    void CharactersJump()
    {
        if(Input.GetKeyDown(KeyCode.W) && isGround) 
        {
            rb2d.gravityScale = jumpGravity;
            rb2d.velocity = Vector3.up * jumpPower;
        }
        else if(rb2d.velocity.y > 0)
        {
            rb2d.gravityScale = 5f;
        }
    }

    /// <summary>
    /// Karakterin hareket etmesi için yazýlan kodlar.
    /// </summary>
    private void CharactersMovement()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb2d.velocity = Vector2.left * movementSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rb2d.velocity = Vector2.right * movementSpeed;
        }
    }


    #region Zemin Kontrol
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
    #endregion


}
