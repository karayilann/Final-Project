using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float jumpPower;
    public float jumpGravity;
    public float fallGravity;
    public float movementSpeed;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;
    

     private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CharactersJump();
        CharactersMovement();
    }

    /// <summary>
    /// Karakterin zýplama fonksiyonunu içerir.
    /// </summary>
    void CharactersJump()
    {
        if(Input.GetKeyDown(KeyCode.W) && IsGround()) 
        {
            
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        if(rb2d.velocity.y >= 0)
        {
            rb2d.gravityScale = jumpGravity;
        }
        else if(rb2d.velocity.y < 0)
        {
            rb2d.gravityScale = fallGravity;
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
    private bool IsGround()
    {
        return Physics2D.OverlapCircle(feetPos.position, radius, layerMask);
    }
    #endregion


}
