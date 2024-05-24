using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBar : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotateVel = 5;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,0,1), rotateVel * Time.deltaTime);
        // if(transform.rotation.z >= rotateBound) transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,rotateBound);
        // else if(transform.rotation.z <= -rotateBound) transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,-rotateBound);
    }
}
