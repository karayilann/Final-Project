using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public bool isStarted;
    public bool isMoving;
    [SerializeField] float cameraSpeed;
    private Spawn spawnerScript;
    [SerializeField] float speedUp;
    private int countPlus;
 

    void Start()
    {
        spawnerScript = GameObject.Find("Game Manager").GetComponent<Spawn>();
        isStarted = false;
        isMoving = true;
        countPlus = 0;

    }


    void Update()
    {

        if(Input.anyKeyDown)
        {
            isStarted = true;
        }

        if (spawnerScript.platformCount == countPlus + 20)
        {
            cameraSpeed += speedUp;
            countPlus = spawnerScript.platformCount;
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
