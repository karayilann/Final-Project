using UnityEngine;

public class PlatformFollow : MonoBehaviour
{
    public Transform Follow;  // Karakterin transform bilgisi
    public float initialYPosition = 0f;  // Platformun ba�lang�� y�ksekli�i
    private Rigidbody2D rb;   // RigidBody2D bile�eni

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // RigidBody2D bile�enini al
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the platform!");
        }
        // Platformun ba�lang�� y�ksekli�ini ayarla
        transform.position = new Vector2(transform.position.x, initialYPosition);
    }

    void LateUpdate()
    {
        if (rb != null && Follow != null)
        {
            // Karakterin y�ksekli�i de�i�ti�inde platformun y�ksekli�ini g�ncelle
            float desiredY = Mathf.Max(Follow.position.y, initialYPosition);

            Vector2 desiredPosition = new Vector2(transform.position.x, desiredY);  // X pozisyonunu sabit tut
            rb.MovePosition(desiredPosition);  // RigidBody2D ile pozisyonu g�ncelle
        }
    }
}







/*using UnityEngine;

public class PlatformFollow : MonoBehaviour
{
    public GameObject Follow;
    private float offset;

    void Start()
    {
        offset = transform.position.y - Follow.transform.position.y;
    }

    void LateUpdate()
    {
        float desiredY = Follow.transform.position.y + offset;
        transform.position = new Vector3(transform.position.x, desiredY, transform.position.z);
    }
}*/

