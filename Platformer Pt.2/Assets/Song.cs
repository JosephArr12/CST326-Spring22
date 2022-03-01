using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{

    public AudioClip song;
    public AudioClip song2;
    public AudioClip jump;
    public AudioClip gameOver;
    private AudioSource audioSource;
    public bool GameOver=false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = song;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void timeRunningOut(){

        if(!GameOver){
        audioSource.Pause();
        audioSource.clip = song2;
        Invoke("playSong",0.25f);
        }
    }

    public void playSong(){
        if(!GameOver){
        audioSource.Play();
        }

    }

    public void timeOver(){
        if(!GameOver){
        audioSource.Pause();
        audioSource.clip = gameOver;
        Invoke("playSong",0.25f);
        }

    }

    public void stopPlaying(){
        audioSource.Stop();
    }
}
