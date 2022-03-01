using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qUV : MonoBehaviour
{
        private float accumulatedTime =0f;
        private float offset =1.0f;
        public Material[] material;
        Renderer rend;
        private bool used=false;

    // Start is called before the first frame update
    void Start()
    {
        rend= GetComponent<Renderer>();
        rend.enabled=true;
        rend.sharedMaterial=material[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        if(used==false){
        Material mat = GetComponent<MeshRenderer>().material;

        accumulatedTime+=Time.deltaTime;

        if(accumulatedTime>0.15f){
            accumulatedTime=0.0f;
            offset-=0.20f;

            mat.mainTextureOffset= new Vector2(0f,offset);

        }
        }
    
    }
        public void changeMaterial(){
            Debug.Log("change material");
        rend.sharedMaterial=material[1];
        used=true;
    }
}
