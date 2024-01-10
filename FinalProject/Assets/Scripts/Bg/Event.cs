using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    [SerializeField] private GameObject[] events;
    [SerializeField] private float eventWait;
    [SerializeField] private float nextEvent;
    public int whichEvent;
    public bool isSpawnable;

    private void Start()
    {
        StartCoroutine(Select());
        
    }

    private void Update()
    {
        //isSpawnable = false;

    }

    private int GetRandomIndex()
    {
        int randomEvent = Random.Range(0, events.Length);
        return randomEvent;
    }

    private IEnumerator Select()
    {
        yield return new WaitForSeconds(eventWait);
        while (true)
        {
            
            whichEvent = GetRandomIndex();
            isSpawnable = true;
            yield return new WaitForSeconds(nextEvent);
        }
    }


}
