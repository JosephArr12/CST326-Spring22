using UnityEngine;

// Technique for making sure there isn't a null reference during runtime if you are going to use get component
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float speed = 5;
    Rigidbody rb;

    //-----------------------------------------------------------------------------
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Fire();
    }

    //-----------------------------------------------------------------------------
    private void Fire()
    {
        rb.velocity = new Vector3(0f, 1.0f*5.0f, 0f);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Shield")){
            Debug.Log("hit the shield");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if(other.gameObject.CompareTag("ColorWall")){
        }
        else{
            // // Destroy(other.gameObject);
            // Destroy(this.gameObject);
        }

        
    }
}
