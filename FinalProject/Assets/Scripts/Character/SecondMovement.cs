using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMovement : MonoBehaviour
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
    /// Karakterin z�plama fonksiyonunu i�erir.
    /// </summary>
    void CharactersJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGround())
        {

            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        if (rb2d.velocity.y >= 0)
        {
            rb2d.gravityScale = jumpGravity;
        }
        else if (rb2d.velocity.y < 0)
        {
            rb2d.gravityScale = fallGravity;
        }
    }

    /// <summary>
    /// Karakterin x ekseninde sol ok veya A tu�u ile sola; sa� ok ile veya D tu�u ile sa�a do�ru hareketi i�in yazd�m.
    /// </summary>
    public void CharactersMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal2") * movementSpeed * Time.deltaTime; // Time.deltaTime t�m bilgisayarlarda  ayn� h�zda �al��mas�n� sa�lar.        
        transform.Translate(horizontalMovement, 0, 0);       
    }


    #region Zemin Kontrol
    private bool IsGround()
    {
        return Physics2D.OverlapCircle(feetPos.position, radius, layerMask);
    }
    #endregion

}
