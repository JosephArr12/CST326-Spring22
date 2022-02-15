using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Color active;
    public Color normal;
    public ButtonType type;
    public enum ButtonType {START,QUIT,BACK};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // gameObject.GetComponent<Text>().color = active;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // gameObject.GetComponent<Text>().color = normal;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (type)
        {
            case ButtonType.START:
                SceneManager.LoadScene("SampleScene");
                break;
            case ButtonType.BACK:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
                break;
            case ButtonType.QUIT:
                UnityEditor.EditorApplication.isPlaying = false;
                break;
        }

    }
}
