using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private bool isStarted;
    public bool isMoving;
    [SerializeField] float cameraSpeed;
    private Spawn spawnerScript;
    [SerializeField] float speedUp;

    void Start()
    {
        spawnerScript = GameObject.Find("Game Manager").GetComponent<Spawn>();
        isStarted = false;
        isMoving = true;

    }


    void Update()
    {
        if(Input.anyKeyDown)
        {
            isStarted = true;
        }
        
    }

    private void LateUpdate()
    {
        if(isStarted == true && isMoving == true)
        {
            transform.Translate(0, 1 * cameraSpeed * Time.deltaTime, 0);
        }
    }
}
