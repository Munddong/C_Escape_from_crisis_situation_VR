using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndClick : MonoBehaviour
{
    //public GameObject house;
    public GameObject katalk;
    public GameObject message;
    public GameObject re;
    public GameObject icon;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void kakaoClick()
    {
        katalk.SetActive(false);
        message.SetActive(true);
        //message.GetComponent<DialogueTrigger>().TriggerDialogue();
    }
    public void kakaoClick2()
    {
        message.SetActive(false);
        re.SetActive(true);
        icon.SetActive(true);
    }
    public void reClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
