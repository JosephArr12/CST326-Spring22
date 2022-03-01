using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bounds : MonoBehaviour
{
    public AudioClip fell;
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
        if (other.gameObject.CompareTag("Mario")){
             RestartGame();
        }

    }

    public void RestartGame(){
        Debug.Log("playing song!");
        GameObject.Find("Main Camera").GetComponent<Raycast>().Lose();
        GameObject.Find("Main Camera").GetComponent<Song>().stopPlaying();
        audioSource.clip = fell;
        audioSource.Play();
        Invoke("Restart",4);

    }

    private void Restart(){

         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    

}
