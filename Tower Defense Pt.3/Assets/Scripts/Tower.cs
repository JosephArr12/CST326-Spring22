using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public int health = 20;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(){
        health--;
        slider.value=health;
        // Debug.Log(health);
        if(health<=0){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject en in enemies){
                    Destroy(en);
                }
            GameObject.Find("Main Camera").GetComponent<Manager>().GameLost();
            Destroy(this.gameObject);

        }
    }
}
