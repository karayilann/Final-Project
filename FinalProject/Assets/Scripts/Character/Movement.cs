using System.Collections;
using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float jumpPower;
    public float jumpGravity;
    public float fallGravity;
    private float movementSpeed = 10f;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;
    public int levelUnlockSpace;
    public int coin;

    private Rigidbody2D rb2d;
    private Collider2D playerCollider;
    [SerializeField] TextMeshProUGUI scorCoin;
    [SerializeField] private GameObject deadPanel;

    [SerializeField] private GameObject idle;
    [SerializeField] private GameObject jump;
    [SerializeField] private GameObject fall;
    public AudioSource deathSound;
    private SpriteRenderer spriteRenderer;

    AsteroitSpawn spawn;
    
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        spriteRenderer = idle.GetComponent<SpriteRenderer>();
        idle.SetActive(true);
        jump.SetActive(false);
        fall.SetActive(false);
        levelUnlockSpace = 0;
        coin = 0;
        Time.timeScale = 1;
    }

    void Update()
    {
        CharactersJump();
        CharactersMovement();
        GetDown();

        if(IsGround() == true)
        {
            idle.SetActive(true);
            jump.SetActive(false);
            fall.SetActive(false);
        }
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

        if(rb2d.velocity.y >= 0 && IsGround() == false)
        {
            rb2d.gravityScale = jumpGravity;
            idle.SetActive(false);
            jump.SetActive(true);
            fall.SetActive(false);
        }
        else if(rb2d.velocity.y < 0 && IsGround() == false)
        {
            rb2d.gravityScale = fallGravity;
            idle.SetActive(false);
            jump.SetActive(false);
            fall.SetActive(true);
        }
    }

    /// <summary>
    /// Karakterin x ekseninde sol ok veya A tuþu ile sola; sað ok ile veya D tuþu ile saða doðru hareketi için yazdým.
    /// </summary>
    public void CharactersMovement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime; // Time.deltaTime tüm bilgisayarlarda  ayný hýzda çalýþmasýný saðlar.     
        transform.Translate(horizontalMovement, 0, 0);
        if(horizontalMovement > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(horizontalMovement < 0)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            coin += 1;
            scorCoin.text = "Skorunuz : " + coin.ToString();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Asteroit"))
        {
            deadPanel.SetActive(true);
            Time.timeScale = 0;
            deathSound.Play();
        }
    }



}
