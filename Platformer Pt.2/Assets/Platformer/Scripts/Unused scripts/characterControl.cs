using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.RightArrow)){
           transform.localEulerAngles= new Vector3(0,90,0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
           transform.localEulerAngles= new Vector3(0,-90,0);

        }
        
    }
}
