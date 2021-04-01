using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; //씬전환

public class End_Gauge : MonoBehaviour
{
    int ifShowedPaper = 0;

    public float timeElapsed;
    public Image CursorGaugeImage; //커서 이미지

    public StoryData_yejin dialogue;

    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    private Queue<string> sentences;


    GameObject com1; //1번 컴퓨터 상호작용
    public Button continueButton; //다음 버튼 상호작용
    //public int click = 0;
    public GameObject paper1;

    Story_yejin dm;
    // ImageTrigger it;

    public bool test1 = false;
    public int count = 0;
    //public DialogueTrigger triggerD = new trigger();
    private StoryTrigger_yejin dt;

    private RaycastHit hit;

    //GameObject hitting_data;
    void Start()
    {
        com1 = GameObject.Find("interaction_com1");
        paper1.SetActive(false);
        sentences = new Queue<string>();
        dm = GameObject.Find("DialogueManager").GetComponent<Story_yejin>();
        GameObject.Find("Start").GetComponent<StoryTrigger_yejin>().TriggerStory();
        //it = GameObject.Find("interaction_cPaper").GetComponent<ImageTrigger>();
    }
    void ImageDisaaplear() //힌트이미지 없애기
    {
        //dm.hintImage.SetActive(false);
        //dm.EndD1 = false;
        count = 0;
        ifShowedPaper = 0;

    }

    void Update()
    {

        Vector3 forward = this.transform.TransformDirection(Vector3.forward) * 1;
        Debug.DrawRay(this.transform.position, forward, Color.green);
        CursorGaugeImage.fillAmount = timeElapsed;
        if (Input.GetMouseButtonDown(0))
        {
            continueButton.GetComponent<Button>().onClick.Invoke();
            //lookWalk.GetComponent<LookWalk>().enabled = false;
            //click++;
            /*
            if (dm.EndD1)
            {
                count++;
                if (count > 1)
                {
                    ImageDisaaplear();
                }
                //dm.hintImage.SetActive(false);
                //Invoke("Second1", 1);

                Debug.Log("종이사라지게");
                ifShowedPaper = 1;


            }
            */


        } //마우스 클릭 or 화면터치 이벤트 종료



        if (Physics.Raycast(this.transform.position, forward, out hit, 2))
        {

            if (hit.collider.CompareTag("interaction")) //BT상호작용
            {
                timeElapsed += 1.0f / 2.0f * Time.deltaTime;
                if (timeElapsed >= 1.0f) //커서게이지가 가득차면
                {
                    //com1.SetActive(false);
                    timeElapsed = 0.0f;
                    hit.transform.GetComponent<Button>().onClick.Invoke();
                    //lookWalk.GetComponent<LookWalk>().enabled = false;
                }

            }


        }
        else
        {
            timeElapsed = 0.0f;

        }
    }

    public void Second1()
    {
        {
            Debug.Log("1초후");
        }
    }
}
