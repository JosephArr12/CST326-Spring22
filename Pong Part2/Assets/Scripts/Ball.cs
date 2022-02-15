using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;
    public int scoredDirection;  

    public float x = 1;
    public float y = 1;

    public AudioClip paddleSound;
    public AudioClip wallSound;
    private AudioSource audioSource;
    private Vector3 originalScale;

    public bool isHit = false;
    public bool LastHitP1;

    public ParticleSystem collisionParticleSystem;

    // Start is called before the first frame update
    public void Start()
    {
        isHit = false;
        originalScale = transform.lossyScale;
        audioSource = GetComponent<AudioSource>();
        int direction = Random.Range(1, 100);

        if (direction % 2 == 0)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }

        x = Random.Range(1, 2)*direction;
        y = Random.Range(0.0f, 0.5f * direction);
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(speed*x,speed*y,0)*Time.deltaTime*60;
    }

    void Update()
    {        
    }

    public void waitSecond(){
        Invoke("Reset",1);
    }


    public void Reset()
    {
        speed = 5f;
        isHit = false;
        x = Random.Range(1, 2);
        x *= scoredDirection;
        y = Random.Range(0.0f, 0.5f);
        float posY = Random.Range(-3, 3);
        GetComponent<Rigidbody>().position = new Vector3(0f, posY, 0f);
        GetComponent<Rigidbody>().velocity = new Vector3(speed * x, speed * y, 0) * Time.deltaTime*60;

    }

    private void OnCollisionEnter(Collision collision)
    {
        isHit = true;

        var emission = collisionParticleSystem.emission;
        var duration= collisionParticleSystem.duration;

        emission.enabled=true;

        collisionParticleSystem.Play();



        if (collision.gameObject.CompareTag("Paddle"))
        {
            audioSource.clip = paddleSound;
            audioSource.pitch = 1 + speed * 0.10f;
            audioSource.Play();
            x *=-1;


            speed += 1f;
            rb.velocity = new Vector3(speed * x, speed *y, 0) * Time.deltaTime*60;
            //transform.localScale = new Vector3(3f, 3f, 3f);

        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            audioSource.clip = wallSound;
            audioSource.pitch = 1 + speed * 0.10f;
            audioSource.Play();
            y *=-1;
            rb.velocity = new Vector3(speed * x, speed * y, 0) * Time.deltaTime*60;
        }

            if(x<0){
                LastHitP1=false;
            }
            else{
                LastHitP1=true;
            }
    }

    public void ballPowerDown(){
            x *=-1;
            speed += 5f;
            rb.velocity = new Vector3(speed * x, speed *y, 0) * Time.deltaTime*60;
    }

}