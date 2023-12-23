using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
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
    private Collider2D playerCollider;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        CharactersJump();
        CharactersMovement();
        GetDown();
    }


    /// <summary>
    /// Karakterin z�plama fonksiyonunu i�erir.
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
    /// Karakterin x ekseninde sol ok veya A tu�u ile sola; sa� ok ile veya D tu�u ile sa�a do�ru hareketi i�in yazd�m.
    /// </summary>
    public void CharactersMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime; // Time.deltaTime t�m bilgisayarlarda  ayn� h�zda �al��mas�n� sa�lar.     
        transform.Translate(horizontalMovement, 0, 0);             
    }


    #region Zemin Kontrol
    private bool IsGround()
    {
        return Physics2D.OverlapCircle(feetPos.position, radius, layerMask);
    }
    #endregion

   private void GetDown()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine("ColliderClose");
        }
    }

    private IEnumerator ColliderClose()
    {
        playerCollider.isTrigger = true;
        yield return new WaitForSeconds(0.1f);
        playerCollider.isTrigger = false;
    }


}
