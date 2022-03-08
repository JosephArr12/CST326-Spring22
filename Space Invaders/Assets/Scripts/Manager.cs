using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{

    public int PlayerScore;
    // public int highScore;
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI gameOver;
    private string m;
    private int lives =3;
    public AudioClip enemyShoot;
    public AudioClip playerDies;
    private AudioSource audioSource;
    // private string gameOverText="Game Over";
    // private float time=0.0f;
    // private bool gameDone=false;
    public float delay = 0.12f;
    // private string currentText ="";
    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.SetInt("hiScore",0);
        highScore.text=PlayerPrefs.GetInt("hiScore").ToString("D4");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updatePref(){
        if(PlayerPrefs.GetInt("hiScore")<PlayerScore){
        PlayerPrefs.SetInt("hiScore",PlayerScore);
        }
    }

    public void GameLost(){

        if(PlayerPrefs.GetInt("hiScore")<PlayerScore){
        PlayerPrefs.SetInt("hiScore",PlayerScore);
        }
        gameOver.color = Color.red;
        gameOver.text="Game Over. You Lose.";
        Time.timeScale=0.0f;
        // StartCoroutine(GameOverText("Game Over. You Lose"));
    }


    public void GameWon(){

        if(PlayerPrefs.GetInt("hiScore")<PlayerScore){
        PlayerPrefs.SetInt("hiScore",PlayerScore);
        }
        gameOver.color = Color.green;
        gameOver.text="You Win!!!";
        Time.timeScale=0.0f;
        // StartCoroutine(GameOverText("You Win!!!"));
    }

    public void lostLife(){
        lives-=1;
        if(lives==2){
            Destroy(GameObject.Find("Life1"));
        }
        if(lives==1){
            Destroy(GameObject.Find("Life2"));
        }
        if(lives<=0){
            Destroy(GameObject.Find("Life3"));
            Destroy (GameObject.FindWithTag("Player"));
            GameLost();
            // StartCoroutine(GameOverText(gameOverText));
        }
        else{
            gameContinue();
        }
        // gameDone=true;
    }

    public void updateScore(){
        Debug.Log(PlayerScore.ToString());
        currentScore.text= PlayerScore.ToString("D4");
        // currentScore.text=PlayerScore.ToString();
        updatePref();
    }

    // IEnumerator GameOverText(string s){
    //     for(int x=0;x<s.Length+1;x++){
    //         currentText=s.Substring(0,x);
    //         gameOver.text = currentText;
    //         yield return new WaitForSeconds(delay);
    //     }
    //     Time.timeScale=0.0f;
    // }

    public void gameContinue(){
        Time.timeScale=1.0f;
        GameObject.Find("Player").GetComponent<Player>().hasLife();
    }

    public void Shoot(){
        audioSource.clip = enemyShoot;
        audioSource.Play();
    }

    public void playerDeath(){
        audioSource.clip = playerDies;
        audioSource.Play();
    }

}
