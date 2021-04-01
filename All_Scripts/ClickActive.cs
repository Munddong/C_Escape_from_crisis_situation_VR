using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickActive : MonoBehaviour
{
    //오브젝트
    public GameObject memo;
    public GameObject drawer_top;
    public GameObject drawer_bottom;
    public GameObject framDoor;
    public GameObject cardkeyDoor;
    public GameObject finalDoor;
    public GameObject key1; //키
    public GameObject ui_key1;
    public GameObject card; //카드키
    public GameObject ui_card;
    public GameObject inter_card;
    public GameObject key2; //키2
    public GameObject ui_key2;
    public GameObject lock_info; //잠김 알림
    public GameObject frame; //사진
    public GameObject frame_b;

    private bool drawer1_open = false;
    private bool drawer2_open = false;
    private bool framDoor_open = false;
    private bool ObtainKey1 = false; //키1 획득
    private bool ObtainCardKey = false; //카드키 획득
    private bool ObtainKey2 = false; //키2 획득
    private bool frameTime = false;
    public bool finalDoor_click = false; //열쇠 문 상호작용 여부

    //위치값
    Vector3 dt1;
    Vector3 dt2;
    Vector3 dt3;

    public int num = 0;
    private int num2 = 0;
    public float time = 0.0f;
    private int rot = 0; //회전각도

    //소리
    public AudioClip open;
    public AudioClip close;
    public AudioClip obtain;
    public AudioClip obtain2;
    public AudioClip obtain_card;
    public AudioClip locking;
    public AudioClip open_door;
    public AudioClip locking_door;


    void Start()
    {
        //memo = GameObject.Find("com1_memo");
        memo.SetActive(false);
        frame_b.SetActive(false);
        //drawer = GameObject.Find("drawer_top");
        //finalDoor.transform.Rotate(0,0 , 140);

    }
    void Update()
    {
        //사진 서랍
        if (frameTime)
        {
            time += Time.deltaTime;
            if (time >= 5.0f)
            {
                frame_b.SetActive(true);
                frame_b.GetComponent<StoryTrigger_yejin>().TriggerStory();
                frameTime = false;
            }
        }
        else if (frameTime == false)
        {
            time = 0.0f;

        }

        //열쇠획득 문열림 구현
        if(finalDoor_click && ObtainKey2)
        {
            
            for(rot = 0; rot<140; rot++)
            {
                finalDoor.transform.Rotate(0, 0, rot);
                Invoke("final", 0.2f);
            }
        }

        //카드키획득 문열림 구현
        if (finalDoor_click && ObtainCardKey)
        {

            for (rot = 0; rot < 140; rot++)
            {
                cardkeyDoor.transform.Rotate(0, 0, rot);
                Invoke("final", 0.2f);
            }
        }


    }

    public void memoActive()
    {
        memo.SetActive(true); //메모 이미지 활성화
    }


    public void drawer_1()
    {
        dt1 = drawer_top.transform.position;
        dt2 = new Vector3(drawer_top.transform.position.x, drawer_top.transform.position.y, drawer_top.transform.position.z + 0.2f);
        dt3 = new Vector3(drawer_top.transform.position.x, drawer_top.transform.position.y, drawer_top.transform.position.z - 0.2f);
        if (drawer1_open == false)
        {
            drawer_top.transform.position = Vector3.Lerp(dt2, dt1, Time.deltaTime * 0.1f);
            Debug.Log("열림");
            GetComponent<AudioSource>().PlayOneShot(open, 1.0f);
            drawer1_open = true;
            if (num == 0)
            {
                key1.SetActive(true); //처음 열릴때만 활성화
            }
            num++; //처음 열리는 거 확인하기 위함
        }

        else if (drawer1_open)
        {
            drawer_top.transform.position = Vector3.Lerp(dt3, dt1, Time.deltaTime * 0.1f);
            Debug.Log("닫힘");
            GetComponent<AudioSource>().PlayOneShot(close, 1.0f);
            drawer1_open = false;
        }
    }


    public void drawer_2()
    {
        dt1 = drawer_bottom.transform.position;
        dt2 = new Vector3(drawer_bottom.transform.position.x, drawer_bottom.transform.position.y, drawer_bottom.transform.position.z + 0.2f);
        dt3 = new Vector3(drawer_bottom.transform.position.x, drawer_bottom.transform.position.y, drawer_bottom.transform.position.z - 0.2f);
        if (drawer2_open == false)
        {
            drawer_bottom.transform.position = Vector3.Lerp(dt2, dt1, Time.deltaTime * 0.1f);
            Debug.Log("열림");
            GetComponent<AudioSource>().PlayOneShot(open, 1.0f);
            drawer2_open = true;
        }

        else if (drawer2_open)
        {
            drawer_bottom.transform.position = Vector3.Lerp(dt3, dt1, Time.deltaTime * 0.1f);
            Debug.Log("닫힘");
            GetComponent<AudioSource>().PlayOneShot(close, 1.0f);
            drawer2_open = false;
        }
    }// drawer_2 종료

    public void Obtatin_key1() //키획득
    {
        key1.SetActive(false);
        ui_key1.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(obtain, 1.0f);
        ObtainKey1 = true;
    }
    public void Obtatin_key2() //키획득2
    {
        key2.SetActive(false);
        ui_key2.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(obtain2, 1.0f);
        ObtainKey2 = true;
    }
    public void Obtatin_card() //카드키 획득
    {
        card.SetActive(false);
        ui_card.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(obtain_card, 1.0f);
        ObtainCardKey = true;
    }


    public void openRoom2()
    {
        if (ObtainKey1)
        {
            GameObject.Find("Door_room2").SetActive(false);
            GameObject.Find("Door_room2open").SetActive(true);
        }
    }

    public void drawer_3() //사진이 보관된 drawer_3 함수 관리
    {
        if (framDoor_open == false)
        {
            time = 0.0f;
            if (ObtainKey1)
            {
                framDoor.transform.Rotate(Vector3.up * -72.743f * 1);
                Debug.Log("열림");
                GetComponent<AudioSource>().PlayOneShot(open, 1.0f);
                framDoor_open = true;
                frame.SetActive(true);
                if (time >= 5)
                {
                    Debug.Log("5초 지남");
                }
            }
            else if (ObtainKey1 == false)
            {
                lock_info.SetActive(true);
                GetComponent<AudioSource>().PlayOneShot(locking, 1.0f);
                Invoke("lock_info_fal", 1);
            }
        }

        else if (framDoor_open)
        {
            framDoor.transform.Rotate(Vector3.up * 72.743f * 1);
            Debug.Log("닫힘");
            GetComponent<AudioSource>().PlayOneShot(close, 1.0f);
            framDoor_open = false;
            frame.SetActive(false);
        }
    } // end drawer_3 함수
    public void lock_info_fal()
    {
        lock_info.SetActive(false);
    }

    public void waitTenS()
    {
        time = 0.0f;
        frameTime = true;
    }



    public void CardKeyDoor_opening() //카드키 문열림
    {
        if (ObtainCardKey)
        {
            finalDoor_click = true;
            //finalDoor.transform.Rotate(Vector3.up * 140);
            Debug.Log("열림");
            GetComponent<AudioSource>().PlayOneShot(open_door, 1.0f);
            inter_card.SetActive(false);
        }
        else if (ObtainKey2 == false)
        {
            lock_info.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(locking_door, 1.0f);
            Invoke("lock_info_fal", 1);
        }
    }




    public void finalDoor_opening() //열쇠 문열림
    {

        if (ObtainKey2)
        {
            finalDoor_click = true;
            //finalDoor.transform.Rotate(Vector3.up * 140);
            Debug.Log("열림");
            GetComponent<AudioSource>().PlayOneShot(open_door, 1.0f);
        }
        else if (ObtainKey2 == false)
        {
            lock_info.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(locking_door, 1.0f);
            Invoke("lock_info_fal", 1);
        }

    }

    public void final()
    {
        finalDoor_click = false;
    }
}
