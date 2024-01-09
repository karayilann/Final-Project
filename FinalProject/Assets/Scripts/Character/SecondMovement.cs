using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public int coin2;


    private Rigidbody2D rb2d;
    private Collider2D playerCollider;
    [SerializeField] TextMeshProUGUI scorCoin2;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        coin2 = 0;
    }

    void Update()
    {
        CharactersJump();
        CharactersMovement();
        GetDown();
    }

    /// <summary>
    /// Karakterin zýplama fonksiyonunu içerir.
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
    /// Karakterin x ekseninde sol ok veya A tuþu ile sola; sað ok ile veya D tuþu ile saða doðru hareketi için yazdým.
    /// </summary>
    public void CharactersMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal2") * movementSpeed * Time.deltaTime; // Time.deltaTime tüm bilgisayarlarda  ayný hýzda çalýþmasýný saðlar.        
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
        if (Input.GetKeyDown(KeyCode.DownArrow))
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coin2 += 1;
            scorCoin2.text = coin2.ToString();
            Destroy(collision.gameObject);
        }
    }

}
