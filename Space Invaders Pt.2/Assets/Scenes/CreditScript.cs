using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MainMenu",5f);
        
    }

    // Update is called once per frame

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

}
