using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{



    public Rigidbody rb;

    public float speed = 5f;

    public int scoredDirection;

    public TrailRenderer trail;


   

    public float x = 1;
    public float y = 1;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

        trail = GetComponent<TrailRenderer>();

        int direction = Random.Range(1, 100);

        if (direction % 2 == 0)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }

        x = Random.Range(1, 2);

        y = Random.Range(0.0f, 0.5f * direction);

        rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(speed*x,speed*y,0);
    }

    void Update()
    {        


    }

    public void Reset()
    {
        speed = 5f;


        x = Random.Range(1, 2);
        x *= scoredDirection;

        y = Random.Range(0.0f, 0.5f);

        float posY = Random.Range(-3, 3);

        GetComponent<Rigidbody>().position = new Vector3(0f, posY, 0f);

        GetComponent<Rigidbody>().velocity = new Vector3(speed * x, speed * y, 0);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            x *=-1;
            speed += 1f;
            rb.velocity = new Vector3(speed * x, speed *y, 0);

        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            y *=-1;
            rb.velocity = new Vector3(speed * x, speed * y, 0);
        }
    }





}