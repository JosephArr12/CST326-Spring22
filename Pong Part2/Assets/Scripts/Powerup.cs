using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Powerup : MonoBehaviour
{
    public GameObject powerUp;
    public float respawnTime = 2.0f;

    private bool t;
    private bool lastHit;
    public Vector3 originalPosition;
    public bool isPower1;

    public AudioClip powerSound;
    public AudioClip paddleShrink;
    private AudioSource audioSource;

    //private bool powerActive = true;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = this.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        

        //Debug.Log("is destroyed");
        t = GameObject.Find("Ball").GetComponent<Ball>().isHit;
        lastHit =  GameObject.Find("Ball").GetComponent<Ball>().LastHitP1;
        //StartCoroutine(timeToSpawn());

        if (t)
        {
            playSound();
            
            if (isPower1)
            {
               GameObject.Find("Ball").GetComponent<Ball>().ballPowerDown();
               this.transform.position = new Vector3(-500.65f, -300f, 18.3f);
               Invoke("ResetPowerups",15);
            }
            else
            {
                if(lastHit){
                    GameObject.Find("Paddle1").GetComponent<Paddle1>().powerUp();

                }
                else{
                    GameObject.Find("Paddle2").GetComponent<Paddle1>().powerUp();
                }
                this.transform.position = new Vector3(-500.65f, -300.48f, 18.3f);
                Invoke("ResetPowerups",15);
            }
            Debug.Log("hit powerup!");

            
        }
    }

    private void playSound(){
        audioSource.clip = powerSound;
        audioSource.Play();
    }

    
    public void playShrinkSound(){
        audioSource.clip = paddleShrink;
        audioSource.Play();
    }

    public void ResetPowerups()
    {
        this.transform.position = originalPosition;
    }

}
