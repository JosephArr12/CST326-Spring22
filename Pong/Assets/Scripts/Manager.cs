using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public int P1Score = 0;
    public int P2Score = 0;
    public int ScoreLimit = 11;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            resumeGame();
        }


    }

    public void ScoreKeeper()
    {

        Debug.Log("Left: " + P1Score + "  Right: " + P2Score);

        if (P1Score >= ScoreLimit)
        {
            Debug.Log("Left Paddle Wins!");
            pauseGame();
            Reset();
        }
        else if (P2Score >= ScoreLimit)
        {
            Debug.Log("Right Paddle Wins!");
            pauseGame();
            Reset();
            
        }
        
    }

    public void Reset()
    {
        GameObject.Find("Paddle1").GetComponent<Paddle1>().ResetPaddles();
        GameObject.Find("Paddle2").GetComponent<Paddle1>().ResetPaddles();
        GameObject.Find("Ball").GetComponent<Ball>().Reset();
        P1Score = 0;
        P2Score = 0;
    }

    public void pauseGame()
    {
        Time.timeScale = 0f;
    }

    void resumeGame()
    {
        Time.timeScale = 1f;
    }
}
