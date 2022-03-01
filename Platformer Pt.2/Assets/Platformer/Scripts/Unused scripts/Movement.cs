using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed =5f;
    public Rigidbody rb;
    public float moveInput;
    public bool onGround=true;
    public AudioClip jump;
    public AudioClip coin;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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

        if(Physics.Raycast(transform.position,transform.TransformDirection (Vector3.up),out RaycastHit hitInfo,0.5f)){
            Debug.Log("hit it");
            if(hitInfo.transform.tag=="Brick"){
                    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f,-1f,0f),ForceMode.Impulse);
                    Destroy(hitInfo.collider.gameObject);

                    // var brick = Instantiate(brickPrefab);
                    // question.transform.position = new Vector3(column,row,0f);
                    
                   
            }
            if(hitInfo.transform.tag=="Question"){
                    audioSource.clip = coin;
                    audioSource.Play();
                    // Destroy(hit.collider.gameObject);
                    // coinCounter();
                    GameObject.Find("Main Camera").GetComponent<Raycast>().coinCounter();
                    hitInfo.collider.gameObject.GetComponent<qUV>().changeMaterial();
            }
        }
        else{
            Debug.DrawRay(transform.position,transform.TransformDirection (Vector3.up) *1f,Color.green);
        }

        if(Physics.Raycast(transform.position,transform.TransformDirection (Vector3.down),out RaycastHit hit,0.5f)){
            if(hit.transform.tag=="Goomba"){
                    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f,10f,0f),ForceMode.Impulse);
                    GameObject.Find("GOOMBA").GetComponent<Goomba>().goombaKill();
                    // Destroy(hit.collider.gameObject);
            }
        }
    }

    void Jump(){
        if(Input.GetButtonDown("Jump")){
            if(onGround==true){
            onGround=false;
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f,10f,0f),ForceMode.Impulse);
            audioSource.clip = jump;
            audioSource.Play();
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
