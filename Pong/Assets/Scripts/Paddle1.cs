using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1 : MonoBehaviour
{
    public bool isP1;
    private float speed = 500f;
    public Vector3 originalPosition;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = gameObject.transform.position;
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isP1)
        {

            float yP1 = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
            rb.velocity = new Vector3(0f, yP1, 0f);


            // previous movement transform.Translate(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f);
            


        }
        else
        {
            float yP2 = Input.GetAxisRaw("Vertical2") * speed * Time.deltaTime;
            rb.velocity = new Vector3(0f, yP2, 0f);
            // previous movement transform.Translate(0f, Input.GetAxisRaw("Vertical2") * speed * Time.deltaTime, 0f);
        }
    }

    public void ResetPaddles()
    {
        transform.position = originalPosition;

    }
}
