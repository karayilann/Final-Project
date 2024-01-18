using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyZone : MonoBehaviour
{
    public GameObject losePanel;
    private Movement movementScript;
    private SecondMovement secondMovementScript;
    bool isContinue;  // Oyunda ölünce yeniden baþladýðýnda sahneninde yeniden baþlamasý için

    private void Start()
    {
        movementScript = GameObject.Find("Blue").GetComponent<Movement>();
        secondMovementScript = GameObject.Find("Pink").GetComponent<SecondMovement>();
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (isContinue)
        {
            Time.timeScale = 1;
            isContinue = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            movementScript.deathSound.Play();
            losePanel.SetActive(true);
        }
        else if(collision.gameObject.CompareTag("Player2"))
        {
            Time.timeScale = 0;
            secondMovementScript.deathSound2.Play();
            losePanel.SetActive(true);
        }

        if(collision.gameObject.CompareTag("Platform"))
        {
            Destroy(collision.gameObject);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isContinue = true;
    }


}
