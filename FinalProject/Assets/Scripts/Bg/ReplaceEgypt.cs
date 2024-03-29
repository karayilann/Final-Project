using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplaceEgypt : MonoBehaviour
{
    private Camera cameraScript;
    public Transform character1;
    public Transform character2;
    Vector3 characterPos1;
    public int minute, seconds;
    private Movement movementScript;
    private SecondMovement secondMovementScript;
    private int totalCoin;

    public float firstSwap, minSwapRate, maxSwapRate;

    [SerializeField] TextMeshProUGUI timer;


    float elapsedTime;

    private void Start()
    {
        cameraScript = GameObject.Find("Main Camera").GetComponent<Camera>();
        movementScript = GameObject.Find("Blue").GetComponent<Movement>();
        secondMovementScript = GameObject.Find("Pink").GetComponent<SecondMovement>();
        InvokeRepeating("ChangePosition", firstSwap, Random.Range(minSwapRate, maxSwapRate));
        //InvokeRepeating("ChangePosition", 60f,60f);  60 sn geçtikten sonra 60sn de bir karakterlerin yerleri değişecek.
    }

    void Update()
    {
        Timer();
        totalCoin = movementScript.coin + secondMovementScript.coin2;

        Score.coinStashMısır = totalCoin;
    }

    /// <summary>
    /// Karakterin 60 sn aralıklarla karakterlerin yer değişmesini sağlayacak kod
    /// </summary>
    private void ChangePosition()
    {
        characterPos1 = character1.position;
        character1.position = character2.position;
        character2.position = characterPos1;
        Debug.Log("Değişti" + " " + minute + " " + seconds);
    }

    private void Timer()
    {
        if (cameraScript.isStarted == true)
        {
            elapsedTime += Time.deltaTime;
            minute = Mathf.FloorToInt(elapsedTime / 60);
            seconds = Mathf.FloorToInt(elapsedTime % 60);
            timer.text = string.Format("Time: {0:00}:{1:00}", minute, seconds);
            Score.oyuncuSkoruMısır = timer.text;
        }

    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

}
