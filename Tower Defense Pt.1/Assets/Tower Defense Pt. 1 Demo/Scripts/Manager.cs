using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager: MonoBehaviour{
    public int coins=0;
    public TextMeshProUGUI coinUI;
    public TextMeshProUGUI lost;
    private int enemies=3;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start(){
        Invoke("Spawn",0f);
        Invoke("Spawn",1.5f);
        Invoke("Spawn",3.4f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit, 500.0f)){
                if(hit.transform.tag=="Enemy"){
                    Debug.Log("Hit the Enemy!");
                    hit.transform.gameObject.GetComponent<EnemyDemo>().decrementHealth();
                }
            }
        }
    }

    public void EnemyKilled(){
        coins+=2;
        coinUI.text = coins.ToString();
        enemies--;
        if(enemies<=0){
            GameWon();
        }
    }

    public void GameLost(){
        lost.text = "You Lose";
        lost.color =Color.red;
    }

    public void GameWon(){
        lost.text = "You Win";
        lost.color =Color.blue;
    }

    public void Spawn(){
        Instantiate(enemy);
    }
}
