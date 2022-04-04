using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager: MonoBehaviour{
    public static int coins=4;
    
    public TextMeshProUGUI coinUI;
    public TextMeshProUGUI lost;
    private int enemies=9;
    public GameObject enemy;
    public AudioClip cantPlace;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start(){
        coinUI.text = coins.ToString();
        audioSource = GetComponent<AudioSource>();
        Invoke("Spawn",0f);
        Invoke("Spawn",1.5f);
        Invoke("Spawn",3.4f);
        Invoke("Spawn",8.4f);
        Invoke("Spawn",10f);
        Invoke("Spawn",12f);
        Invoke("Spawn",17f);
        Invoke("Spawn",18f);
        Invoke("Spawn",20f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit, 10000.0f)){
                if(hit.transform.tag=="Enemy"){
                    Debug.Log("Hit the Enemy!");
                    hit.transform.gameObject.GetComponent<Enemy>().decrementHealth();
                }
                if(hit.transform.tag=="Defense"){
                    Debug.Log("Place a defense");
                    if(coins<2){
                        CantPlace();
                    }
                    else{
                    hit.transform.gameObject.GetComponent<PlaceDefense>().Defense();
                    coinUI.text = coins.ToString();
                    }
                }
            }
        }
    }

    public void EnemyKilled(){
        coins+=1;
        coinUI.text = coins.ToString();
        enemies--;
        if(enemies<=0){
            GameWon();
        }
    }
    
    public void CantPlace(){
        audioSource.clip = cantPlace;
        audioSource.Play();
        lost.text = "Not enough coins to place a defense!";
        lost.color =Color.white;
        Invoke("Clear",3.0f);
    }

    public void Clear(){
        lost.text = "";
    }

    public void GameLost(){
        lost.text = "You Lose";
        lost.color =Color.white;
    }

    public void GameWon(){
        lost.text = "You Win";
        lost.color =Color.white;
    }

    public void Spawn(){
        Instantiate(enemy);
    }
}