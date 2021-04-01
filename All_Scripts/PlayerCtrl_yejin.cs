using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/*
   플래이어의 커서 동작 관리 스크립트
*/

public class PlayerCtrl_yejin : MonoBehaviour
{
    //public 변수
    public float timeElapsed;
    public Image CursorGaugeImage; //커서 게이지 이미지
    

    //private 변수
    private RaycastHit hit;
    private GameObject Cursor_observe; //커서_돋보기
    private GameObject Cursor; //중앙 커서
    //private GameObject Player;

    //Event e = null;
    Story_yejin storyManager;
    //public float h;

    void Start()
    {
        storyManager = FindObjectOfType<Story_yejin>();
        Cursor_observe = GameObject.Find("Cursor_observe");
        Cursor = GameObject.Find("CursorBG_white");
        //Player = GameObject.Find("Player");
        //h = Player.GetComponent<CapsuleCollider>().height;
        //Debug.Log("플래이어 키: " + h);
        //h = 2;
    }

    void Update()
    {
        
        Vector3 forward = this.transform.TransformDirection(Vector3.forward) * 3f;
        Debug.DrawRay(this.transform.position, forward, Color.green);
        CursorGaugeImage.fillAmount = timeElapsed;
        if (Physics.Raycast(this.transform.position, forward, out hit, 3f) && storyManager.Di == false)
        {
            if (hit.collider.CompareTag("observe")) //Btn 태그로 상호작용 //콜라이더에 닿은 물체 태그가 observe라면
            {
                Cursor_observe.transform.DOScale(1, 1).SetEase(Ease.OutQuad); //돋보기를 확대 하고
                Cursor.transform.DOScale(0, 0.4f).SetEase(Ease.OutQuad); //중앙 흰점은 안보이게
                timeElapsed += 1.0f / 2.0f * Time.deltaTime;
                if (timeElapsed >= 1.0f) //커서게이지가 가득차면
                {
                    timeElapsed = 0.0f;
                    hit.transform.GetComponent<Button>().onClick.Invoke();
                }
            }
            else
            {
                timeElapsed = 0.0f;
                Cursor_observe.transform.DOScale(0, 0.4f).SetEase(Ease.OutQuad);
                Cursor.transform.DOScale(1, 1).SetEase(Ease.OutQuad);
            }

        }
        else
        {
            timeElapsed = 0.0f;
            Cursor_observe.transform.DOScale(0, 0.4f).SetEase(Ease.OutQuad);
            Cursor.transform.DOScale(1, 1).SetEase(Ease.OutQuad);
        }

        


    }



}
