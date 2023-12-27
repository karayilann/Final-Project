using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TextMover : MonoBehaviour
{
    private RectTransform rectTransform;
    private float topPosition;
    float moveSpeed = 50f;  // Metnin hareket hýzý
    public Vector2 startingPosition;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startingPosition = rectTransform.anchoredPosition;
        topPosition = rectTransform.anchoredPosition.y + (rectTransform.rect.height * 0.5f) + 296.1968f;
    }

    private void Update()
    {
        if (rectTransform.anchoredPosition.y < topPosition)
        {
            rectTransform.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;
        }
    }
}
