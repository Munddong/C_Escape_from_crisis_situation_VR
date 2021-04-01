using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongAnswerButton : MonoBehaviour
{
    CameraShake cameraShakeScript_WrongAnswerButton;

    // Start is called before the first frame update
    void Start()
    {
        cameraShakeScript_WrongAnswerButton = GameObject.Find("Player").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WrongAnswerButton1()
    {
        cameraShakeScript_WrongAnswerButton.speed = 5.0f;
    }

    public void WrongAnswerButton2()
    {
        cameraShakeScript_WrongAnswerButton.speed = 1.5f;
    }

    public void WrongAnswerButton3()
    {
        cameraShakeScript_WrongAnswerButton.speed = 1.5f;
    }

    public void WrongAnswerButton4()
    {
        cameraShakeScript_WrongAnswerButton.speed = 1.5f;
    }
}
