using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public AudioClip won;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
         Debug.Log("won game!!!");
         GameObject.Find("Main Camera").GetComponent<Song>().stopPlaying();
         Invoke("playWin",0.2f);

    }

    private void playWin(){
         GameObject.Find("Mario Basic").GetComponent<MarioCharacterController>().GameOver=true;
         audioSource.clip = won;
         audioSource.Play();
    }

}
