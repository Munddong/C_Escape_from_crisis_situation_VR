using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRPlayer : MonoBehaviour
{
    public Image ClickImage;
    public GameObject Cam;
    public CapsuleCollider cc;
    public GameObject Canv;
    private float GaugeTimer;
    float MoveSpeed = 1;
    public bool IsMove;
    public bool lope;
    public bool Knife;
    Factory_Narration_YSC FACTO_Narration;

    public AudioSource audioSource;
    public AudioClip Walk_Sound;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CapsuleCollider>();
        IsMove = false;
        lope = true;
        Knife = false;
        FACTO_Narration = GameObject.Find("head").GetComponent<Factory_Narration_YSC>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update iscalled once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = Cam.transform.TransformDirection(Vector3.forward) * 1000;
        Quaternion Canv_for = Cam.transform.localRotation;
        ClickImage.fillAmount = GaugeTimer;

        Debug.DrawRay(Cam.transform.position, forward);

        //레이캐스트로 물건확인
        if (IsMove == false)
        {
            if (Physics.Raycast(Cam.transform.position, forward, out hit) && hit.collider.CompareTag("Button"))
            {
                Debug.Log(hit.transform.gameObject.name);
                GaugeTimer += 1.0f / 2.0f * Time.deltaTime;
                if (GaugeTimer >= 1.0f)
                {
                    Debug.Log(hit.transform.gameObject.name);
                    hit.transform.GetComponent<Button>().onClick.Invoke();
                    GaugeTimer = 0.0f;
                }
            }
            else
            {
                GaugeTimer = 0.0f;
            }
        }

        else if (IsMove == true)
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("누름");
                MoveLookAt();
                if(audioSource.isPlaying == false)
                {
                    audioSource.clip = Walk_Sound;
                    audioSource.Play();
                }
                
            }
            else if(Input.GetMouseButtonUp(0)){
   
            }
        }
    }

    void MoveLookAt()
    {
        //메인카메라 바라보는 방향.
        Vector3 dir = Cam.transform.TransformDirection(Vector3.forward);
        gameObject.transform.Translate(dir * 1f * Time.deltaTime);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Door"))
        {
            GameObject.Find("head").GetComponent<Factory_Narration_YSC>().Find_Door();
        }
        else if (coll.gameObject.CompareTag("Oil"))
        {
            GameObject.Find("head").GetComponent<Factory_Narration_YSC>().Get_Oil();
        }
        else if (coll.gameObject.CompareTag("knife"))
        {
            Debug.Log(coll.name);
            GameObject.Find("head").GetComponent<Factory_Narration_YSC>().Cut_Lope();
        }
        else if (coll.gameObject.CompareTag("Train_Sound"))
        {
            Debug.Log(coll.name);
            GameObject.Find("head").GetComponent<Factory_Narration_YSC>().Train_Sound();
        }
        else if (coll.gameObject.CompareTag("Paper"))
        {
            Debug.Log(coll.name);
            GameObject.Find("head").GetComponent<Factory_Narration_YSC>().Get_Paper();
        }
        else if (coll.gameObject.CompareTag("SmartPhone"))
        {
            Debug.Log(coll.name);
            GameObject.Find("head").GetComponent<Factory_Narration_YSC>().Get_Phone();
        }
        else if (coll.gameObject.CompareTag("End_Door"))
        {
            Debug.Log(coll.name);
            GameObject.Find("head").GetComponent<Factory_Narration_YSC>().Go_Cop_Chatting();
        }
        else if (coll.gameObject.CompareTag("Vill_Door_Col"))
        {
            Debug.Log(coll.name);
            GameObject.Find("head").GetComponent<Factory_Narration_YSC>().Find_Vill_Door();
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.CompareTag("Door"))
        {
            FACTO_Narration.SelectBox_Door.SetActive(false);

        }
    }

}
