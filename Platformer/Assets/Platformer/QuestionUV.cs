using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionUV : MonoBehaviour
{
        private float accumulatedTime =0f;
        private float totalTime =0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Material mat = GetComponent<MeshRenderer>().material;

        accumulatedTime+=Time.deltaTime;

        if(accumulatedTime>0.2f){
            if(totalTime>1.0){
                accumulatedTime=0.0f;
                totalTime=0.0f;
                mat.mainTextureOffset =new Vector2(0f,1.0f);
            }
            else{
                mat.mainTextureOffset= new Vector2(0f,1.0f - accumulatedTime);
            }
            
        }
    
    }
}
