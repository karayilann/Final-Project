using UnityEngine;

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
}
