using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    private int randomPoints;
    private int[] array1 = new int[] {50,100,150,200,250};
    Animator animator;
    private float fireTime;
    private float randomNumber=0.0f;
    [FormerlySerializedAs("bullet")] public GameObject bulletPrefab;
    public GameObject UFOPrefab;
    [FormerlySerializedAs("shottingOffset")] public Transform shootOffsetTransform;
    // private Vector3 offset;

    void Start(){
        animator = gameObject.GetComponent<Animator>();
        animator.speed = 2.0f;
        randomNumber = Random.Range(2.0f, 100.0f);        
    }

    void Update(){
        fireTime+=Time.deltaTime;

        if(this.gameObject.CompareTag("UFO")){
        }
        else if(fireTime>randomNumber){
            // offset =new Vector3(transform.position.x-1.0f , transform.position.y -0.5f , transform.position.z);
            GameObject.Find("Main Camera").GetComponent<Manager>().Shoot();
            GameObject shot = Instantiate(bulletPrefab, shootOffsetTransform.position, Quaternion.identity);

            Destroy(shot, 3f);

            randomNumber = Random.Range(20.0f, 50.0f);
            fireTime=0.0f;
        }
    }

    //-----------------------------------------------------------------------------
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("RightWall")){
            GameObject.Find("Pack").GetComponent<Pack>().hitRightWall();
        }
        else if (other.gameObject.CompareTag("LeftWall")){
            GameObject.Find("Pack").GetComponent<Pack>().hitLeftWall();
        }
        else if (other.gameObject.CompareTag("BottomWall")){
            GameObject.Find("Main Camera").GetComponent<Manager>().GameLost();
            GameObject.Find("Pack").GetComponent<Pack>().canMove=false;
            Debug.Log("bottom wall");
        }
        else if (other.gameObject.CompareTag("EnemyBullet")){   
        }
        else if (other.gameObject.CompareTag("Player")){   
        }
        else if (other.gameObject.CompareTag("Shield")){
            Destroy(other.transform.parent.gameObject);
        }
        else{
        addPoints(this.gameObject.tag);
        Debug.Log(this.gameObject.tag);

        // todo - trigger death animation
        animator.SetTrigger("Death");
        Destroy(other.gameObject); // destroy bullet
        GameObject.Find("Pack").GetComponent<Pack>().dead();
        Destroy(this.gameObject,0.2f);
        // GameObject.Find("Player").GetComponent<Player>().canShootBullet();
        }
    }

    void addPoints(string name){
        if(name=="Crab"){
            GameObject.Find("Main Camera").GetComponent<Manager>().PlayerScore+=20;
            GameObject.Find("Main Camera").GetComponent<Manager>().updateScore();
            Debug.Log("Score +20");

        }
        else if (name=="Squid"){
            GameObject.Find("Main Camera").GetComponent<Manager>().PlayerScore+=30;
            GameObject.Find("Main Camera").GetComponent<Manager>().updateScore();
            Debug.Log("Score +30");
        }
        else if (name=="Octopus"){
            GameObject.Find("Main Camera").GetComponent<Manager>().PlayerScore+=10;
            GameObject.Find("Main Camera").GetComponent<Manager>().updateScore();
            Debug.Log("Score +10");
        }
        else{
            randomPoints = Random.Range(0,5);
            randomPoints= array1[randomPoints];
            GameObject.Find("Main Camera").GetComponent<Manager>().PlayerScore+=randomPoints;
            GameObject.Find("Main Camera").GetComponent<Manager>().updateScore();
            Debug.Log("Score +"+randomPoints.ToString());
            Instantiate(UFOPrefab);
        }
    }

}
