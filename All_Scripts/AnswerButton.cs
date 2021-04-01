using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButton : MonoBehaviour
{
    public GameObject cam;
    CameraShake cameraShakeScript_AnswerButton;

    // Start is called before the first frame update
    void Start()
    {
        cameraShakeScript_AnswerButton = GameObject.Find("Player").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnswerButton1()
    {
        cam.SetActive(true);
    }

    public void AnswerButton2()
    {
        cameraShakeScript_AnswerButton.speed = 1.5f;
    }

    public void AnswerButton3()
    {
        cameraShakeScript_AnswerButton.speed = 1.5f;
    }

    public void AnswerButton4()
    {
        cameraShakeScript_AnswerButton.speed = 1.5f;
    }
}
