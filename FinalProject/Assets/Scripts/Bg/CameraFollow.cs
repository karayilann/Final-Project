using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform target2;



    void Start()
    {
        
    }

    void LateUpdate()
    {
        if(target.position.y > transform.position.y && target.position.y > target2.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newPos;
        }
        else if(target2.position.y > transform.position.y && target2.position.y > target.position.y)
        {
            Vector3 newPos2 = new Vector3(transform.position.x, target2.position.y, transform.position.z);
            transform.position = newPos2;
        }
        
    }
}
