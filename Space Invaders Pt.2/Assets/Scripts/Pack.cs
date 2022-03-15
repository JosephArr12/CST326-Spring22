using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Pack : MonoBehaviour
{
    public float move=0.0f;
    public float moveTime=0.8f;
    public float directionTime=0.0f;
    public float translation =0.06f;
    public bool moveDown = false;
    public int moveD=0;
    public int deadEnemies;
    public int totalDeadEnemies;
    public bool canMove=true;
    public AudioClip die;
    public AudioClip backgroundNoise;
    private AudioSource audioSource;
    [FormerlySerializedAs("pack")] public GameObject packPrefab;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundNoise;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if(canMove){


        if (transform.childCount == 0){
            GameObject.Find("Main Camera").GetComponent<Manager>().GameWon();
            translation=0;
         }

        move+=Time.deltaTime;

        if(move>=moveTime){
            gameObject.transform.Translate(translation, 0f, 0f);
            move=0.0f;
        }

        }

    }

    public void hitRightWall(){
        if(translation>0){
            translation*=-1;
            gameObject.transform.Translate(0f, -0.15f, 0f);
        }
    }


    public void hitLeftWall(){
        if(translation<0){
            translation*=-1;
            gameObject.transform.Translate(0f, -0.15f, 0f);
        }
    }

    public void dead(){
        GameObject.Find("Main Camera").GetComponent<Manager>().enemyDeath();
        deadEnemies++;
        if(deadEnemies>=5){
            audioSource.pitch+=0.03f;
            moveTime-=0.02f;
            deadEnemies=0;
        }
    }
}
