using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
    public Rigidbody rb;
    private float speed = 3f;
    public int direction =-1;
    public AudioClip goombaDeath;
    private AudioSource audioSource;
    public bool dead=false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    // rb = GetComponent<Rigidbody>();
    // rb.velocity = new Vector3(-speed,0,0)*Time.deltaTime*60;
    // transform.tranlsate()

    }

    // Update is called once per frame
    void Update()
    {
    Vector3 movement = new Vector3(direction,0f,0f);
    transform.position+=movement*Time.deltaTime*speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
           direction*=-1;
        }
        if (collision.gameObject.CompareTag("Stone"))
        {
           direction*=-1;
        }
        if (collision.gameObject.CompareTag("Goomba"))
        {
           direction*=-1;
        }
    }

    public void goombaKill()
    {
    
    audioSource.clip = goombaDeath;
    audioSource.Play();

    transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z*0.8f);

    Invoke("DestroyGoomba",0.25f);
    }

    public void DestroyGoomba()
    {
    if(!dead){
        dead=true;
        Debug.Log("adding score");
        GameObject.Find("Main Camera").GetComponent<Raycast>().goombaScore();
        Destroy(this.gameObject);
    }
    }

}
