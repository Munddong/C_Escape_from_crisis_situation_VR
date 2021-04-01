using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl1 : MonoBehaviour
{
    public Image cursorGaugeImage;
    public GameObject mainCam;
    public AudioClip button;
    public AudioClip keySound;
    public AudioClip doorSound;
    public AudioClip walkingSound;
    public AudioClip drawerSound;

    private AudioSource audioSource;
    private AudioSource audioSource2;

    public float gaugeTimer = 0.0f;
    private float gagueTime = 3.5f;
    public float walkSpeed;
    private bool isMoving = false;
    private Vector3 goalPosition;

    public int chapter_s = 1;
    private int closet = 0;
    private int water = 0;
    private int key = 0;
    private int drawer = 0;
    private int closet2 = 0;
    private int shower = 0;
    private int bed2 = 0;
    private int bicycle = 0;
    private int lock1 = 0;

    Dialogue1 dialogue_s;

    // Use this for initialization
    void Start()
    {
        dialogue_s = GameObject.Find("Player").GetComponent<Dialogue1>();
        chapter_s = 1;
        audioSource = GetComponent<AudioSource>();
        audioSource2 = mainCam.GetComponent<AudioSource>();

        walkSpeed = 0.015f;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = mainCam.transform.TransformDirection(Vector3.forward) * 10;
        
        UnityEngine.Debug.DrawRay(this.transform.position, forward, Color.blue);
        
        cursorGaugeImage.fillAmount = gaugeTimer;

        float mainCam_x = mainCam.transform.eulerAngles.x;

        if (Physics.Raycast(this.transform.position, forward, out hit))
        {
            goalPosition = new Vector3(hit.point.x, this.transform.position.y, hit.point.z);

            if (hit.collider.tag == "switch1")
            {
                gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                if (gaugeTimer >= 1.0f)
                {
                    dialogue_s.StartCoroutine(dialogue_s.c1_switch1());
                    gaugeTimer = 0.0f;
                }
            }
            else if (hit.collider.tag == "drawer2" && drawer == 0)
            {
                gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                if (gaugeTimer >= 1.0f)
                {
                    audioSource.PlayOneShot(drawerSound);
                    dialogue_s.StartCoroutine(dialogue_s.openDrawer());
                    gaugeTimer = 0.0f;
                    drawer = 1;
                }
            }
            else if (hit.collider.tag == "key")
            {
                gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                if (gaugeTimer >= 1.0f)
                {
                    audioSource.PlayOneShot(keySound);
                    Destroy(hit.collider.gameObject);
                    gaugeTimer = 0.0f;
                    key = 1;
                }
            }
            else if (hit.collider.tag == "phone1")
            {
                gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                if (gaugeTimer >= 1.0f)
                {
                    dialogue_s.StartCoroutine(dialogue_s.c1_phone1());
                    gaugeTimer = 0.0f;
                }
            }
            else if (hit.collider.tag == "bed1")
            {
                gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                if (gaugeTimer >= 1.0f)
                {
                    dialogue_s.StartCoroutine(dialogue_s.c1_bed1());
                    gaugeTimer = 0.0f;
                }
            }
            else if (chapter_s == 1)
            {
                if (hit.collider.tag == "others1")
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        dialogue_s.StartCoroutine(dialogue_s.c1_closet1());
                        gaugeTimer = 0.0f;
                    }
                }
                else if (hit.collider.tag == "water1")
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        dialogue_s.StartCoroutine(dialogue_s.c1_water1());
                        gaugeTimer = 0.0f;
                    }
                }
                else gaugeTimer = 0.0f;
            }
            else if (chapter_s == 2)
            {
                if (hit.collider.tag == "door1")
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        dialogue_s.StartCoroutine(dialogue_s.c1_door1_1());
                        gaugeTimer = 0.0f;
                    }
                }
                else if (hit.collider.tag == "button")
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        audioSource.PlayOneShot(button);
                        chapter_s = 3;
                        gaugeTimer = 0.0f;
                        hit.transform.GetComponent<Button>().onClick.Invoke();
                    }
                }
                else gaugeTimer = 0.0f;
            }
            else if(chapter_s == 3)
            {
                if (hit.collider.tag == "drawer1")
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        dialogue_s.StartCoroutine(dialogue_s.c3_others());
                        gaugeTimer = 0.0f;
                       
                    }
                }
                else if (hit.collider.tag == "closet1")
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        gaugeTimer = 0.0f;
                        audioSource.PlayOneShot(drawerSound);
                        dialogue_s.StartCoroutine(dialogue_s.openCloset());
                        chapter_s = 4;
                    }
                }
                else if (hit.collider.tag == "water1")
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        gaugeTimer = 0.0f;
                        dialogue_s.StartCoroutine(dialogue_s.c1_water1());
                    }
                }
                else if (hit.collider.tag == "door1")
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        dialogue_s.StartCoroutine(dialogue_s.c4_door1());
                        gaugeTimer = 0.0f;
                    }
                }
                else gaugeTimer = 0.0f;
            }
            else if (chapter_s == 4)
            {
                if (hit.collider.tag == "door1")
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        dialogue_s.StartCoroutine(dialogue_s.c4_door1());
                        gaugeTimer = 0.0f;
                    }
                }
                else if (hit.collider.tag == "water1")
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        gaugeTimer = 0.0f;
                        dialogue_s.StartCoroutine(dialogue_s.c4_water1());
                        water = 1;
                        
                    }
                }
                else if (hit.collider.tag == "closet1")
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        gaugeTimer = 0.0f;
                        dialogue_s.StartCoroutine(dialogue_s.c4_closet1());
                        closet = 1;
    
                    }
                }
                else gaugeTimer = 0.0f;
                if (closet == 1 && water == 1) chapter_s = 5;
            }
            else if(chapter_s == 5)//문을 보면 문열림 & 선택지 나오기
            {
                if (hit.collider.tag == "door1")
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        audioSource.PlayOneShot(doorSound);
                        dialogue_s.StartCoroutine(dialogue_s.openDoor());
                        gaugeTimer = 0.0f;
                    }
                }
                else if (hit.collider.tag == "button")
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        audioSource.PlayOneShot(button);
                        chapter_s = 6;
                        gaugeTimer = 0.0f;
                        hit.transform.GetComponent<Button>().onClick.Invoke();
                    }
                }
                else gaugeTimer = 0.0f;
            }
            else if (chapter_s == 6)
            {
                if (hit.collider.tag == "shower"&&bed2 == 0)
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        
                        dialogue_s.StartCoroutine(dialogue_s.c6_shower());
                        gaugeTimer = 0.0f;
                        shower = 1;
                    }
                }
                else if (hit.collider.tag == "closet2" && closet2 == 0)
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        audioSource.PlayOneShot(drawerSound);
                        dialogue_s.StartCoroutine(dialogue_s.c6_closet());
                        gaugeTimer = 0.0f;
                        closet2 = 1;
                    }
                }
                else if (hit.collider.tag == "closet2" && closet2 == 1)
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        dialogue_s.StartCoroutine(dialogue_s.c6_candle());
                        gaugeTimer = 0.0f;
                    }
                }
                else if (hit.collider.tag == "bed2" && shower == 1)
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        dialogue_s.StartCoroutine(dialogue_s.c6_bed());
                        gaugeTimer = 0.0f;
                        bed2 = 1;
                    }
                }
                else if (hit.collider.tag == "shower" && bed2 == 1)
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        
                        dialogue_s.StartCoroutine(dialogue_s.c6_shower2());
                        gaugeTimer = 0.0f;
                        chapter_s = 7;
                    }
                }
                else gaugeTimer = 0.0f;
            }
            else if (chapter_s == 7) {
                if (hit.collider.tag == "warning"&&bicycle==0)
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        dialogue_s.StartCoroutine(dialogue_s.warning1());
                        gaugeTimer = 0.0f;
                    }
                }
                else if (hit.collider.tag == "lock" && key == 1)
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        audioSource.PlayOneShot(keySound);
                        dialogue_s.StartCoroutine(dialogue_s.lock1());
                        gaugeTimer = 0.0f;
                        Destroy(hit.collider.gameObject);
                        lock1 = 1;
                    }
                }
                else if (hit.collider.tag == "lock" && key == 0)
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        dialogue_s.StartCoroutine(dialogue_s.lock2());
                        gaugeTimer = 0.0f;
                    }
                }
                else if (hit.collider.tag == "bicycle" && bicycle == 0 && lock1 == 0)
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        dialogue_s.StartCoroutine(dialogue_s.bicycle1());
                        gaugeTimer = 0.0f;
                    }
                }
                else if (hit.collider.tag == "bicycle" && bicycle == 0 && lock1 == 1)
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        dialogue_s.StartCoroutine(dialogue_s.bicycle2());
                        gaugeTimer = 0.0f;
                        bicycle = 1;
                    }
                }
                else if (hit.collider.tag == "warning" && bicycle == 1)
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        dialogue_s.StartCoroutine(dialogue_s.ending());
                        gaugeTimer = 0.0f;
                    }
                }
                else if (hit.collider.tag == "box")
                {
                    gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

                    if (gaugeTimer >= 1.0f)
                    {
                        dialogue_s.StartCoroutine(dialogue_s.c3_others());
                        gaugeTimer = 0.0f;
                    }
                }
                else gaugeTimer = 0.0f;
            }
            else gaugeTimer = 0.0f;
        }
        else
        {
            gaugeTimer = 0.0f; 
        }

        if (Input.GetMouseButton(0))
        {
            isMoving = true;
            MovePlayer();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            audioSource2.Stop();
        }
        else isMoving = false;
    }
    private void OnTriggerEnter(Collider other)//이동장소에 캐릭터가 도착하면
    {
        if (other.gameObject.tag == "door_s" && chapter_s == 1)
        {  
            dialogue_s.StartCoroutine(dialogue_s.c1_door1());
            Destroy(other.gameObject);
            chapter_s = 2;
        }
        if (other.gameObject.tag == "door_s" && chapter_s == 6)
        {
            audioSource.PlayOneShot(doorSound);
            dialogue_s.StartCoroutine(dialogue_s.c5_door());
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "bathroomDoor_s")
        {
            audioSource.PlayOneShot(doorSound);
            dialogue_s.StartCoroutine(dialogue_s.bathroomDoor());
            Destroy(other.gameObject);
        }
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "block_s" && chapter_s == 7)
        {
            audioSource.PlayOneShot(doorSound);
            Destroy(other.gameObject);
            dialogue_s.StartCoroutine(dialogue_s.terraceDoor());
        }
    }
    void MovePlayer()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, goalPosition, walkSpeed);
        if(!audioSource2.isPlaying) audioSource2.PlayOneShot(walkingSound);
    }

    public void openDoorYes()
    {
        dialogue_s.StartCoroutine(dialogue_s.c1_yes());
    }
    public void openDoorNo()
    {
        dialogue_s.StartCoroutine(dialogue_s.c1_no());
    }
    public void waiting()
    {
        dialogue_s.StartCoroutine(dialogue_s.waiting());
    }
    public void finding()
    {
        dialogue_s.StartCoroutine(dialogue_s.finding());
    }
    public void going()
    {
        dialogue_s.StartCoroutine(dialogue_s.going());
    }
}