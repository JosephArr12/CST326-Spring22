using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{

    public int P1Score = 0;
    public int P2Score = 0;
    public int ScoreLimit = 11;

    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI winner;

    public AudioClip gameOver;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        score1.text = P1Score+ "";
        score2.text = P2Score+"";
        winner.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            resumeGame();
            winner.text = "";
            score1.text = P1Score + "";
            score2.text = P2Score + "";
            score2.color=Color.white;
            score1.color=Color.white;
        }
    }

    public void ScoreKeeper()
    {
        if(P1Score>P2Score){
            score1.color=Color.green;
            score2.color=Color.red;
        }
        else if(P2Score>P1Score){
            score2.color=Color.green;
            score1.color=Color.red;
        }
        else{
            score2.color=Color.white;
            score1.color=Color.white;
        }

        score1.text = P1Score + "";
        score2.text = P2Score + "";
        Debug.Log("Left: " + P1Score + "  Right: " + P2Score);

        if (P1Score >= ScoreLimit)
        {
            winner.text = "Left Paddle Wins!!!";
            Debug.Log("Left Paddle Wins!");
            pauseGame();
            Reset();
        }
        else if (P2Score >= ScoreLimit)
        {
            Debug.Log("Right Paddle Wins!");
            winner.text = "Right Paddle Wins!!!";
            pauseGame();
            Reset();
        }
        
    }

    public void Reset()
    {
        GameObject.Find("Paddle1").GetComponent<Paddle1>().ResetPaddles();
        GameObject.Find("Paddle2").GetComponent<Paddle1>().ResetPaddles();
        GameObject.Find("Ball").GetComponent<Ball>().Start();

        GameObject.Find("Powerup").GetComponent<Powerup>().ResetPowerups();
        GameObject.Find("Powerup2").GetComponent<Powerup>().ResetPowerups();

        P1Score = 0;
        P2Score = 0;
    }

    public void pauseGame()
    {
        GameOver();
        GameObject.Find("Ball").GetComponent<Ball>().Reset();
        Time.timeScale = 0f;

        
    }

    void resumeGame()
    {
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        audioSource.clip = gameOver;
        audioSource.Play();
    }
}
