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
    [SerializeField] private GameObject deadPanel;


    private Rigidbody2D rb2d;
    private Collider2D playerCollider;
    [SerializeField] TextMeshProUGUI scorCoin2;

    [SerializeField] private GameObject idle;
    [SerializeField] private GameObject jump;
    [SerializeField] private GameObject fall;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        spriteRenderer = idle.GetComponent<SpriteRenderer>();
        idle.SetActive(true);
        jump.SetActive(false);
        fall.SetActive(false);
        coin2 = 0;
        Time.timeScale = 1;
    }

    void Update()
    {
        CharactersJump();
        CharactersMovement();
        GetDown();

        if (IsGround() == true)
        {
            idle.SetActive(true);
            jump.SetActive(false);
            fall.SetActive(false);
        }
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
            idle.SetActive(false);
            jump.SetActive(true);
            fall.SetActive(false);
        }
        else if (rb2d.velocity.y < 0)
        {
            rb2d.gravityScale = fallGravity;
            idle.SetActive(false);
            jump.SetActive(false);
            fall.SetActive(true);
        }
    }

    /// <summary>
    /// Karakterin x ekseninde sol ok veya A tu�u ile sola; sa� ok ile veya D tu�u ile sa�a do�ru hareketi i�in yazd�m.
    /// </summary>
    public void CharactersMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal2") * movementSpeed * Time.deltaTime; // Time.deltaTime t�m bilgisayarlarda  ayn� h�zda �al��mas�n� sa�lar.        
        transform.Translate(horizontalMovement, 0, 0);
        if (horizontalMovement > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalMovement < 0)
        {
            spriteRenderer.flipX = true;
        }
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
            scorCoin2.text = "Skorunuz : " + coin2.ToString();
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("Asteroit"))
        {
            deadPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
