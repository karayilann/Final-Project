using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform target2;

    //AsteroitSpawn spawn;


    void Start()
    {
        //spawn = GameObject.FindAnyObjectByType<AsteroitSpawn>();
    }

    void LateUpdate()
    {

       // if (!spawn.isSpawn)
        {
        //    transform.Translate(0,1f*Time.deltaTime,0);
        }


        // aþaðýdakiler eski koddur þuanda 

        if(target.position.y > transform.position.y && target.position.y > target2.position.y)
        {
            Vector3 newpos = new Vector3(transform.position.x, target.position.y, transform.position.z);
            transform.position = newpos;
        }
        else if(target2.position.y > transform.position.y && target2.position.y > target.position.y)
        {
            Vector3 newpos2 = new Vector3(transform.position.x, target2.position.y, transform.position.z);
            transform.position = newpos2;
        }
         //eðer oyuncu hareketi olmazsa kamera hareket etmeye baþlayacak.

    }
}
