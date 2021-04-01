using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookWalk : MonoBehaviour
{

    public Transform vrCamera;
    public float toggleAngle = 30.0f;
    public float speed = 100.0f;
    public bool moveForward;
    float time1 = 0;
    public AudioClip audio;

    private CharacterController cc;
    Event e = null;
    Vector3 playerCenter;


    void Start()
    {

        playerCenter = this.GetComponent<CapsuleCollider>().center;

    }



    void Update()
    {

        
        if (Input.GetMouseButton(0))
        {
            time1 += Time.deltaTime;

            if (time1 >= 0.2f)
            {
                moveForward = true;

                if (GetComponent<AudioSource>().isPlaying == false)
                {
                    GetComponent<AudioSource>().Play();
                }
            }
  
        }
        else
        {
            moveForward = false;
            GetComponent<AudioSource>().Stop();

            time1 = 0;
        }

        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            transform.position += forward * Time.deltaTime*speed;
            
        }


    }
    

    void OnGUI()
    {

        e = Event.current;
        if (e.isMouse)
        {

            if (e.clickCount == 2)
            {
                //Debug.Log("Mouse clicks: " + e.clickCount + "플래이어 키: " + playerCenter);
                if (this.GetComponent<CapsuleCollider>().center == new Vector3(0, -2, 0))
                    this.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.5f, 0);
                else
                    this.GetComponent<CapsuleCollider>().center = playerCenter;

            }
        }

    }

}