using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed =5f;
    public Rigidbody rb;
    public float moveInput;
    public bool onGround=true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position+=movement*Time.deltaTime*speed;
        //moveInput = Input.GetAxisRaw("Horizontal");
        //rb.velocity =  new Vector3(moveInput*speed*Time.deltaTime,0f,0f);

        // float x= Input.GetAxis("Horizontal")*speed *Time.deltaTime;

        // rb.velocity = new Vector3(x,0f,0f);
        // if(Input.GetKeyDown(KeyCode.Space)){
        //     rb.AddForce(new Vector3(0,6,0));
        // }
        
    }

    void Jump(){
        if(Input.GetButtonDown("Jump")){
            if(onGround==true){
            onGround=false;
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f,10f,0f),ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if (collision.gameObject.CompareTag("Rock"))
        // {
            onGround=true;

        // }
    }

    
}
