using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("bullet")] public GameObject bulletPrefab;
    [FormerlySerializedAs("shottingOffset")] public Transform shootOffsetTransform;

    private Animator playerAnimator;
    private float speed =5f;
    public float timeIdle =0.0f;

    public int points=0;
    private bool canShoot=true;
    private bool isIdle=true;
    Rigidbody rb;
    public AudioClip shoot;
    private AudioSource audioSource;

    //-----------------------------------------------------------------------------
    public void Start()
    {
        // playerAnimator.SetTrigger("Idle");
        playerAnimator = gameObject.GetComponent<Animator>();
        // playerAnimator.SetBool("Dead",false);

        rb = gameObject.GetComponent<Rigidbody>();
        canShoot=true;
        //gameObject.transform.Translate(0f, 0f, 0f);
        transform.position = new Vector3(0.01f, -2.82f, 0f);
        audioSource = GetComponent<AudioSource>();
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed;
        rb.velocity = new Vector3(x,0f, 0f);


        timeIdle+=Time.deltaTime;

        if(timeIdle>3f){
            playerAnimator.SetTrigger("Idle");
            isIdle=true;
            timeIdle=0.0f;
        }
        // else{
        //     playerAnimator.SetTrigger("None");
        // }

        if(isIdle){
            playerAnimator.SetTrigger("Idle");
        }
        else{
            playerAnimator.SetTrigger("None");
        }


        if (Input.GetButtonDown("Horizontal")){
            isIdle=false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            isIdle=false;
            timeIdle=0.0f;
            playerAnimator.SetTrigger("None");
            canShoot=false;
            // todo - trigger a "shoot" on the animator
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);
            playerAnimator.SetTrigger("Shoot");
            Invoke("none",0.8f);
            audioSource.clip = shoot;
            audioSource.Play();
            Destroy(shot, 3f);
            Invoke("canShootBullet",0.8f);
            // GameObject ufo = Instantiate(ufoPrefab);
            // Destroy(ufo, 100f);
        }
    }

    public void canShootBullet(){
        canShoot=true;
    }


    public void dead(){
        playerAnimator.SetTrigger("Death");
        Invoke("lostLife",0.8f);
    }

    public void hasLife(){
        transform.position = new Vector3(-20.51f, -2.82f, 0f);
        playerAnimator.SetTrigger("None");
        Invoke("invokeHasLife",0.3f);
    }

    public void none(){
        playerAnimator.SetTrigger("None");
    }


    public void invokeHasLife(){
        // playerAnimator.SetBool("Dead",false);
        transform.position = new Vector3(-2.51f, -2.82f, 0f);
        
    }

    public void lostLife(){
        GameObject.Find("Main Camera").GetComponent<Manager>().lostLife();
    }

    public void newUFO(){

    }
}
