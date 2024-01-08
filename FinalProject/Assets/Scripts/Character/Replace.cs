using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Replace : MonoBehaviour
{
    public Transform character1;
    public Transform character2;
    Vector3 characterPos1;
    public int minute, seconds;

    public float firstSwap, minSwapRate, maxSwapRate;

    [SerializeField] TextMeshProUGUI timer;

    float elapsedTime;

    private void Start()
    {
        InvokeRepeating("ChangePosition", firstSwap, Random.Range(minSwapRate,maxSwapRate));
        //InvokeRepeating("ChangePosition", 60f,60f);  60 sn ge�tikten sonra 60sn de bir karakterlerin yerleri de�i�ecek.
    }

    void Update()
    {
        Timer();
    }

    /// <summary>
    /// Karakterin 60 sn aral�klarla karakterlerin yer de�i�mesini sa�layacak kod
    /// </summary>
    private void ChangePosition()
    {
        characterPos1 = character1.position;
        character1.position = character2.position;
        character2.position = characterPos1;
        Debug.Log("De�i�ti" + " " + minute + " " + seconds);
    }

    private void Timer()
    {
        elapsedTime += Time.deltaTime;
        minute = Mathf.FloorToInt(elapsedTime / 60);
        seconds = Mathf.FloorToInt(elapsedTime % 60);
        timer.text = string.Format("Time: {0:00}:{1:00}", minute, seconds);
    }
}
