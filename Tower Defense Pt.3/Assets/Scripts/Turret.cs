using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    public float range = 4f;
    public float turn = 10f;
    public float fireRate=2f;
    public float countdown =0f;
    public GameObject bullet;
    public Transform firePoint;
    public AudioClip shoot;
    private AudioSource audioSource;
    public Transform cube;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(cube);
        InvokeRepeating("UpdateTarget",0f,0.5f);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target==null){
            return;
        }
        Vector3 direction = target.position - transform.position;
        Quaternion look = Quaternion.LookRotation(direction);
        Vector3 rotate = Quaternion.Lerp(transform.rotation,look,Time.deltaTime*turn).eulerAngles;
        transform.rotation = Quaternion.Euler(0f,rotate.y,0f);

        if(countdown<=0f){
            Shoot();
            countdown=1f/fireRate;
        }
        countdown-=Time.deltaTime;
    }

    void Shoot(){
        // Debug.Log("shoot");
        GameObject bulletGameObject=(GameObject)Instantiate(bullet,firePoint.position,firePoint.rotation);
        Bullet bullet1 = bulletGameObject.GetComponent<Bullet>();
        if(bullet1!=null){
            bullet1.Find(target);
        }
        audioSource.clip = shoot;
        audioSource.Play();
    }

    void UpdateTarget(){
        float shortest = Mathf.Infinity;
        GameObject nearest= null;
        foreach (GameObject enemies in GameObject.FindGameObjectsWithTag("Enemy")){
           float distance = Vector3.Distance(transform.position,enemies.transform.position);  
           if(distance<shortest){
               shortest=distance;
               nearest = enemies;
           }
        }
        if(nearest !=null && shortest<=range){
            target=nearest.transform;
        }
        else{
            target=null;
        }
    }
}
