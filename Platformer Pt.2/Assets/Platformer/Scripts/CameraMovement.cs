using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;


    void LateUpdate()
    {
        transform.position= new Vector3(target.position.x+2.5f,7.0f,-100f);   
    }
}
