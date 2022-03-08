using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Renderer rend;
    public float speed = 5;
    Rigidbody rb;

    [SerializeField]
    private Color green = Color.green;


    //-----------------------------------------------------------------------------
    void Start()
    {
        rend = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
        Fire();
    }

    //-----------------------------------------------------------------------------
    private void Fire()
    {
        rb.velocity = new Vector3(0f, -3.0f, 0f);
    }


        void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("hit the player!!!");
            GameObject.Find("Player").GetComponent<Player>().dead();
        }
        // else if(other.gameObject.CompareTag("Squid")){
            
        // }
        // else if(other.gameObject.CompareTag("Crab")){
            
        // }
        // else if(other.gameObject.CompareTag("Octopus")){
            
        // }
        // else if(other.gameObject.CompareTag("EnemyBullet")){
            
        // }
        else if(other.gameObject.CompareTag("Bullet")){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if(other.gameObject.CompareTag("Shield")){
            Debug.Log("hit the shield");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if(other.gameObject.CompareTag("BottomWall")){
            Destroy(this.gameObject);
        }
        else if(other.gameObject.CompareTag("ColorWall")){
            rend.material.color = green;
        }
        else{

        }        
    }
}
