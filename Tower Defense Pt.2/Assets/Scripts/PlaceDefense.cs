using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDefense : MonoBehaviour
{
    public bool placed = false;
    public GameObject turret;
    public int coins;
    public AudioClip buy;
    public AudioClip placedSound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    
    void Start()
    {
        placed=false;
        audioSource = GetComponent<AudioSource>();
    }
    public void Defense(){
       if(placed){
           audioSource.clip = placedSound;
           audioSource.Play();
       }
       else{
           audioSource.clip = buy;
           audioSource.Play();
           Manager.coins-=2;
           Invoke("SpawnTurret",0.5f);
           placed=true;
       }
    }

    public void SpawnTurret(){
        GameObject defense = Instantiate(turret, this.transform.position + Vector3.up * 2, Quaternion.identity);
    }
}
