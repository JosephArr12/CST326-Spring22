using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qUV : MonoBehaviour
{
        private float accumulatedTime =0f;
        private float offset =1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Material mat = GetComponent<MeshRenderer>().material;

        accumulatedTime+=Time.deltaTime;

        if(accumulatedTime>0.15f){
            accumulatedTime=0.0f;
            offset-=0.20f;

            mat.mainTextureOffset= new Vector2(0f,offset);

        }
    
    }
}
