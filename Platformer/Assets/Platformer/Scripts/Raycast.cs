using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Raycast : MonoBehaviour
{

    public TextMeshProUGUI coins;
    public TextMeshProUGUI time;
    public TextMeshProUGUI score;

    private int coinCount=0;
    private float accumulatedTime =0f;
    private int startTime =400;
    private int scoreInt = 0;
    private string m;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0)){
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x,Input.mousePosition.y,100f));
            Vector3 direction = worldMousePosition -Camera.main.transform.position;

            RaycastHit hit;

            if(Physics.Raycast (Camera.main.transform.position,direction,out hit,100f)){
                if(hit.transform.tag=="Brick"){
                    Destroy(hit.collider.gameObject);
                }
                if(hit.transform.tag=="Question"){
                    // Destroy(hit.collider.gameObject);
                    coinCounter();

                }
            }
        }

        accumulatedTime+=Time.deltaTime;

        if(accumulatedTime>1){
            accumulatedTime=0f;
            startTime--;

            time.text=""+startTime;
            //Debug.Log("time is" + startTime);
        }
        
    }

    public void coinCounter(){
        coinCount++;
        if(coinCount>9){
            m="x";
        }
        else{
            m ="x0";   
        }
        coins.text = m +coinCount;

        m="";

        scoreInt+=200;

        for(int x=scoreInt.ToString().Length;x<9;x++){
            m+="0";
        }

        

        score.text = m + scoreInt;
    }


}
