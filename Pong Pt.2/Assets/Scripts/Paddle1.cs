using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle1 : MonoBehaviour
{
    public bool isP1;
    private float speed = 500f;
    private Vector3 originalPosition;
    private Vector3 originalScale;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = gameObject.transform.position;
        originalScale = transform.localScale;
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
        GameObject.Find("Powerup").GetComponent<Powerup>().playShrinkSound();
        transform.localScale = originalScale;
        transform.position = originalPosition;
    }

    public void powerUp()
    {
        transform.localScale = new Vector3(0.3f, 30f, 3f);
        Invoke("ResetPaddles", 7);
    }
}
