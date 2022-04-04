using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 10f;

    public void Find (Transform target2){
        target=target2;
    }

    // Update is called once per frame
    void Update()
    {
        if(target==null){
            Destroy(gameObject);
            return;
        }
        
        Vector3 direction = target.position - transform.position;
        float distance = speed * Time.deltaTime;
        if(direction.magnitude<= distance){
            Hit();
            return;
        }
        transform.Translate(direction.normalized * distance, Space.World);
    }

    void Hit(){
        Destroy(gameObject);
    }
}
