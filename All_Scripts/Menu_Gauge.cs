using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //커서 이미지
using UnityEngine.SceneManagement; //씬전환

public class Menu_Gauge : MonoBehaviour
{
    public float timeElapsed;
    public Image CursorGaugeImage;
    //private Vector3 ScreenCenter;

    void Start()
    {
        PlayerPrefs.DeleteAll(); //시작하면 레지스트리에 저장된 데이터 삭제
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 forward = this.transform.TransformDirection(Vector3.forward) * 1000;
        CursorGaugeImage.fillAmount = timeElapsed;
        if (Physics.Raycast(this.transform.position, forward, out hit))
        {
            timeElapsed += 1.0f / 2.0f * Time.deltaTime;
            if (timeElapsed >= 1.0f) //커서게이지가 가득차면
            {
                SceneManager.LoadScene("Room1");
            }
            
        }
        else
        {
            timeElapsed = 0.0f;

        }

    }

}
