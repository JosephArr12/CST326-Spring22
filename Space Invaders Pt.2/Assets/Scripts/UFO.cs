using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{

    public float spawn=0.0f;
    public float move =0.02f;
    public float position =5.0f;
    public int direction =-1;
    private float speed = 3f;
    public float randomNumber=0.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(25.74f,3.6f,3.469902f);
        randomNumber = Random.Range(10.0f, 20.0f);
        // gameObject.transform.Translate(5f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 movement = new Vector3(direction,0f,0f);
        transform.position+=movement*Time.deltaTime*speed;

        spawn+=Time.deltaTime;
        
        if(spawn>=randomNumber){
        
        this.transform.position = new Vector3(10.74f,3.6f,3.469902f);
        
        spawn=0.0f;
        randomNumber = Random.Range(10.0f, 20.0f);
        }
    }

    // public void moveBack()
    // {
    //     randomNumber = Random.Range(10.0f, 20.0f);
    //     spawn=0.0f;
    // }
}
