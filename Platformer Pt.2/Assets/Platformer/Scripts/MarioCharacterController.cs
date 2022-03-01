using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioCharacterController : MonoBehaviour
{
    public float runForce = 50f;
    public float jumpForce = 20f;
    public float jumpBonus = 5f;
    private Rigidbody rb; 
    private float maxRunSpeed=6f;
    private Collider collider;
    public Animator animComp;
    // private float notMoving=0f; 

    public bool feetInContactWithGround=true;
    public bool inContactWithWall=false;
    public bool inContactWithBlock=false;
    public bool GameOver=false;
    public bool dontFollow=false;

    private float jumpTimeCounter;
    private float jumpTime=0.25f;
    private bool isJumping=false;
    public AudioClip jump;
    public AudioClip coin;
    public AudioClip brick;
    private AudioSource audioSource;

    private float coyoteTime =0.2f;
    private float coyoteTimeCounter;
    private float jumpBufferTime = 0.1f;
    private float jumpBufferCounter;

    private float accumulatedTime=0.0f;

    private bool dead=false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        animComp = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if(!GameOver){

        if(Input.GetKey(KeyCode.RightArrow)){
           transform.localEulerAngles= new Vector3(0,90,0);
           dontFollow=false;
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
           transform.localEulerAngles= new Vector3(0,-90,0);
           dontFollow=true;
        }

        float castDistance = collider.bounds.extents.y+0.1f;
        float castDistance2 = -collider.bounds.extents.y+0.1f;

        feetInContactWithGround = Physics.Raycast(transform.position,Vector3.down,castDistance);
        inContactWithBlock = Physics.Raycast(transform.position,Vector3.down,castDistance2);
        
        float axis = Input.GetAxis("Horizontal");

        rb.AddForce(Vector3.right*runForce*axis,ForceMode.Force);

        if(feetInContactWithGround){
            coyoteTimeCounter=coyoteTime;
        }
        else{
            coyoteTimeCounter-=Time.deltaTime;
        }

        if(Input.GetButtonDown("Jump")){
            jumpBufferCounter=jumpBufferTime;
        }
        else{
            jumpBufferCounter-=Time.deltaTime;
        }
        
        if(jumpBufferCounter>0f && coyoteTimeCounter>0f){
            isJumping=true;
            jumpTimeCounter=jumpTime;
            rb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            audioSource.clip = jump;
            audioSource.Play();
            jumpBufferCounter=0f;
        }

        if(Input.GetKey(KeyCode.Space) && isJumping){
            if(jumpTimeCounter>0){

                rb.velocity = Vector3.up * jumpForce;
                jumpTimeCounter-=Time.deltaTime;
            }
            else{
                isJumping=false;
            }
            coyoteTimeCounter=0f;
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            isJumping=false;
        }

        if(Mathf.Abs(rb.velocity.x)>maxRunSpeed){
            float newX=maxRunSpeed*Mathf.Sign(rb.velocity.x);
            rb.velocity = new Vector3(newX,rb.velocity.y,rb.velocity.z);
        }

        if(Mathf.Abs(axis)<0.1f){
            float newX = rb.velocity.x *(1f-Time.deltaTime*20f);
            rb.velocity = new Vector3(newX,rb.velocity.y,rb.velocity.z);
        }

        if(Input.GetKey(KeyCode.LeftShift)&&Mathf.Abs(rb.velocity.x)>maxRunSpeed-1.0f){
            maxRunSpeed=8f;
            animComp.SetBool("Turbo",true);
        }
        else{
            maxRunSpeed=6f;
            animComp.SetBool("Turbo",false);
        }


        animComp.SetFloat("Speed",rb.velocity.magnitude);

        animComp.SetBool("isJumping",isJumping);


        if(inContactWithBlock){
        }


        if(Physics.Raycast(transform.position,transform.TransformDirection (Vector3.up),out RaycastHit hitInfo,1.8f)){
            if(hitInfo.transform.tag=="Brick"){
                    GameObject.Find("Main Camera").GetComponent<Raycast>().brickScore();
                    audioSource.clip = brick;
                    audioSource.Play();
                    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f,-1f,0f),ForceMode.Impulse);
                    Destroy(hitInfo.collider.gameObject);
            }
            if(hitInfo.transform.tag=="Question"){
                    audioSource.clip = coin;
                    audioSource.Play();
                    hitInfo.collider.gameObject.GetComponent<qUV>().changeMaterial();
                    hitInfo.collider.gameObject.tag="None";
                    GameObject.Find("Main Camera").GetComponent<Raycast>().coinCounter();
                    // GameObject.Find(hitInfo.collider.gameObject.ToString()).GetComponent<qUV>().changeMaterial();
            }
        }


        if(Physics.Raycast(transform.position,transform.TransformDirection (Vector3.down),out RaycastHit hitDown,1.0f)){
            if(hitDown.transform.tag=="Goomba"){
                    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f,5f,0f),ForceMode.Impulse);
                    hitDown.collider.gameObject.GetComponent<Goomba>().goombaKill();
            }
        }


        if(Physics.Raycast(transform.position,transform.TransformDirection (Vector3.forward),out RaycastHit hitForward,0.30f)){
            if(hitForward.transform.tag=="Goomba"&&!dead){
                GameObject.Find("CubeLose").GetComponent<Bounds>().RestartGame();
                dead=true;
                // collider.isTrigger=true;
                // rb.useGravity=false;
                    
            }
        }
        else if(Physics.Raycast(transform.position,transform.TransformDirection (Vector3.back),out RaycastHit hitBack,0.30f)){
            if(hitBack.transform.tag=="Goomba"&&!dead){
                GameObject.Find("CubeLose").GetComponent<Bounds>().RestartGame();
                dead=true;
                // collider.isTrigger=true;
                // rb.useGravity=false;
            }
        }

        }

        else{
            rb.velocity = new Vector3(0f,0f,0f);
            Celebration();
        }

    void Celebration(){
            accumulatedTime+=Time.deltaTime;
            if(accumulatedTime>3){
                rb.velocity = new Vector3(0f,0f,0f);
                transform.localEulerAngles= new Vector3(0,180,0);
                animComp.SetBool("Celebration",true);
            }
            else{
            rb.AddForce(Vector3.right*50f,ForceMode.Force);   
            animComp.SetFloat("Speed",1.10f);    
            }    
        }

    }
}
