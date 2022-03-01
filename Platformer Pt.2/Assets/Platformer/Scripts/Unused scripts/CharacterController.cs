using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float runForce=100f;
    public float jumpImpulse=20f;
    public float sustainForce=7.5f;
    public float maxHorizontalSpeed=6f;

    public Rigidbody rb;

    public AudioClip jump;
    public AudioClip coin;
    private AudioSource audioSource;

    public Animator animComp;
    public bool isJumping=false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        animComp = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // animComp.SetBool("isJumping",false);

        Jump();

        var x = Input.GetAxis("Horizontal");
        rb.AddForce(Vector3.right*x*Time.deltaTime*runForce,ForceMode.Acceleration);


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
                    GameObject.Find(hitInfo.collider.gameObject.ToString()).GetComponent<qUV>().changeMaterial();
            }
        }
        else{
            //Debug.DrawRay(transform.position,transform.TransformDirection (Vector3.up) *1f,Color.green);
        }

        if(Physics.Raycast(transform.position,transform.TransformDirection (Vector3.down),out RaycastHit hit,0.1f)){
            if(hit.transform.tag=="Goomba"){
                    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f,10f,0f),ForceMode.Impulse);
                    GameObject.Find("GOOMBA").GetComponent<Goomba>().goombaKill();
                    // Destroy(hit.collider.gameObject);
            }
            else{
                isJumping= false;
                animComp.SetBool("isJumping",false);
            }
        }
        else{
            isJumping=true;
        }

        
        // Debug.DrawRay(transform.position,transform.TransformDirection (Vector3.down),Color.green);


        animComp.SetFloat("Speed",rb.velocity.magnitude);

    }

    void Jump(){
        if(Input.GetButtonDown("Jump")){
            if(!isJumping){
            // isJumping=true;
            animComp.SetBool("isJumping",true);
            rb.AddForce((Vector3.up*Time.deltaTime*jumpImpulse),ForceMode.Impulse);
            audioSource.clip = jump;
            audioSource.Play();
            }
        }
    }

    void Turbo(){
        // if(Input.GetKeyDown(KeyCode.Shift)){

        // }
    }
}
