using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ImageTrigger : MonoBehaviour
{
    public GameObject Image;
    Story_yejin dm;
    public bool image_data = false;

    void Start()
    {
        dm = GameObject.Find("DialogueManager").GetComponent<Story_yejin>();
    }

    public void TriggerImage()
    {
        //if (dm.endD2 == true)
        {
            //Debug.Log("TriggerImage 활성화");
            //Image.SetActive(true); //이미지 활성화
            //image_data = true; //이미지 활성화 체크 변수
            //dm.endD2 = false; //대화문 종료
        }
        //FindObjectOfType<ImageTrigger>().TriggerImage();
        //Image.SetActive(true);
    }

}
