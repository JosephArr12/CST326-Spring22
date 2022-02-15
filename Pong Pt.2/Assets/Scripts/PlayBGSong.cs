using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBGSong : MonoBehaviour
{
    public AudioClip bgSound;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgSound;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
