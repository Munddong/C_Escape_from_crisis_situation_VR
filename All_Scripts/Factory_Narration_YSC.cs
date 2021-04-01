using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Factory_Narration_YSC : MonoBehaviour
{
    public GameObject Camera;
    public Rigidbody rd;
    public GameObject Narration;
    public GameObject Villain_Narration;
    public GameObject Cop_Narration;
    public GameObject News_Narration;
    public GameObject SelectBox_1;
    public GameObject SelectBox_2;
    public GameObject SelectBox_3;
    public GameObject SelectBox_4;
    public GameObject SelectBox_5;
    public GameObject SelectBox_Door;
    public GameObject SelectBox_Phone;
    public GameObject Knife;
    public GameObject Door_Col;
    public GameObject Door;
    public GameObject Question_tBox_1;
    public GameObject Question_tBox_2;
    public GameObject Question_tBox_3;
    public GameObject Ending_Sel;
    public GameObject End_Col;
    public GameObject Train_Col;
    public GameObject Cop;
    public GameObject Time_over_vill;
    public GameObject Game_over_vill;
    public GameObject Ending_vill;
    public GameObject Ending_Mask;
    public GameObject Light;
    public GameObject main_timer;
    public GameObject Block;
    public GameObject Paper_image;
    public bool Shoot_V_and_P;
    public bool Shoot_V;
    public bool die;
    public bool Play_one = false;
    public bool Calling_Cop = false;
    public bool Boom_on = false;
    public bool Vill_Move = false;
    public bool Vill_Hit = false;
    public int correct_count;
    public GameObject Boom_Point;
    public Vector3 Down_Pose;

    public GameObject Phone;
    public GameObject phone_image;
    public GameObject Tip_image;

    public Sprite[] Call_sprites;
    public Sprite[] Tip_sprites;

    public Text Narrationchat;
    public Text Villain_Narration_chat;
    public Text Cop_Narration_chat;
    public Text News_Narration_chat;

    public AudioSource audioSource;
    public AudioClip train_Sound;
    public AudioClip Bang_Sound;
    public AudioClip Paper_Sound;
    public AudioClip phone_Sound;
    public AudioClip push_butten_Sound;
    public AudioClip calling_Sound;
    public AudioClip Door_open;
    public AudioClip Hit_Sound;

    VRPlayer PlayerCtrl;
    Timer timer;

    private void Awake()
    {
        StartCoroutine(LoadDevice("cardboard", true));
        Debug.Log("2");
    }

    void Start()
    {
        rd = GameObject.Find("head").GetComponent<Rigidbody>();
        PlayerCtrl = GameObject.Find("head").GetComponent<VRPlayer>();
        timer = GameObject.Find("head").GetComponent<Timer>();
        Narrationchat.text = ""; //나레이션 텍스트 초기화
        Villain_Narration_chat.text = ""; //캐릭터 대화창 텍스트 초기화
        Cop_Narration_chat.text = "";
        Shoot_V_and_P = false;
        Shoot_V = false;
        die = false;
        StartCoroutine(Tip_time());
    }

    void Update() 
    {
        if(timer.LimitTime == 0f && Play_one==false)
        {
            StopAllCoroutines();
            
            Debug.Log("시작");
            StartCoroutine(time_over());
            Debug.Log("끝");
            Play_one = true;
            Time_over_vill.SetActive(true);
        }

        Down_Pose = new Vector3(Camera.transform.position.x, -0.5f, Camera.transform.position.z);

    }

    public void First_Choice_1()
    {
        StartCoroutine(Choice_1_1());
    }
    public void First_Choice_2()
    {
        StartCoroutine(Choice_1_2());
    }
    public void Second_Choice_1()
    {
        StartCoroutine(Choice_2_1());
    }
    public void Second_Choice_2()
    {
        StartCoroutine(Choice_2_2());
    }
    public void Third_Choice_1()
    {
        StartCoroutine(Choice_3_1());
    }
    public void Third_Choice_2()
    {
        StartCoroutine(Choice_3_2());
    }
    public void Fourth_Choice_1()
    {
        StartCoroutine(Choice_4_1());
    }
    public void Fourth_Choice_2()
    {
        StartCoroutine(Choice_4_2());
    }
    public void Fifth_Choice_1()
    {
        StartCoroutine(Choice_5_1());
    }
    public void Fifth_Choice_2()
    {
        StartCoroutine(Choice_5_2());
    }
    public void Cut_Lope()
    {
        StartCoroutine(Get_Knife());
    }
    public void Open_Door()
    {
        StartCoroutine(open_door());
    }
    public void Find_Door()
    {
        StartCoroutine(find_door());
    }
    public void Not_Open_Door()
    {
        StartCoroutine(not_open_door());
    }
    public void Get_Oil()
    {
        StartCoroutine(get_Oil());
    }
    public void Train_Sound()
    {
        StartCoroutine(Train_sound());
    }
    public void Get_Paper()
    {
        StartCoroutine(paper());
    }
    public void Get_Phone()
    {
        StartCoroutine(phone());
    }
    public void Call_Cop()
    {
        StartCoroutine(call_cop());
    }
    public void Dont_Call_Cop()
    {
        StartCoroutine(dont_call_cop());
    }
    public void Sel_Facotry()
    {
        StartCoroutine(old_factory());
    }
    public void Sel_House()
    {
        StartCoroutine(old_house());
    }
    public void Sel_Hospital()
    {
        StartCoroutine(old_hospital());
    }
    public void Sel_GumArm()
    {
        StartCoroutine(gumarm());
    }
    public void Sel_Kyo()
    {
        StartCoroutine(kyo());
    }
    public void Sel_JangGi()
    {
        StartCoroutine(janggi());
    }
    public void Sel_Train_Sound()
    {
        StartCoroutine(train_sound());
    }
    public void Sel_Airport_Sound()
    {
        StartCoroutine(airport_sound());
    }
    public void Sel_Port_Sound()
    {
        StartCoroutine(port_sound());
    }
    public void Stand_Up()
    {
        StartCoroutine(stand_up());
    }
    public void Stand_Down()
    {
        StartCoroutine(stand_down());
    }
    public void Go_Cop_Chatting()
    {
        StartCoroutine(game_end());
    }
    public void Find_Vill_Door()
    {
        StartCoroutine(find_vill_door());
    }

    public IEnumerator Tip_time()
    {
        PlayerCtrl.IsMove = false;


        Tip_image.GetComponent<Image>().sprite = Tip_sprites[0];
        yield return new WaitForSeconds(1f);
        Tip_image.GetComponent<Image>().sprite = Tip_sprites[1];
        yield return new WaitForSeconds(5f);
        Tip_image.GetComponent<Image>().sprite = Tip_sprites[2];
        yield return new WaitForSeconds(5f);
        Tip_image.GetComponent<Image>().sprite = Tip_sprites[3];
        yield return new WaitForSeconds(5f);
        Tip_image.GetComponent<Image>().sprite = Tip_sprites[4];
        yield return new WaitForSeconds(5f);
        Tip_image.SetActive(false);

        StartCoroutine(chatting());
    }

    //시작
    IEnumerator chatting()
    {
        PlayerCtrl.IsMove = false;
        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        Tweener texting = Narrationchat.DOText(Narration_Script.Fir_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Fir_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Fir_Player_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        yield return new WaitForSeconds(0.5f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Fir_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Fir_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Fir_Villain_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Fir_Player_Narration3, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Fir_Player_Narration4, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        SelectBox_1.SetActive(true);
        StartCoroutine(Local_Scale_up(SelectBox_1));
        yield return new WaitForSeconds(0.5f);
    }

    //1-1번 선택지(약 요구)
    public IEnumerator Choice_1_1()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(SelectBox_1));
        yield return new WaitForSeconds(0.5f);
        SelectBox_1.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Sel1_1_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel1_1_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Sel1_1_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Sel1_1_Player_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel1_1_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel1_1_Villain_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        timer.LimitTime += 120;

        StartCoroutine(chatting2());
    }

    //1-2번 선택지(참는다)
    public IEnumerator Choice_1_2()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(SelectBox_1));
        yield return new WaitForSeconds(0.5f);
        SelectBox_1.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Sel1_2_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Sel1_2_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel1_2_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Sel1_2_Player_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel1_2_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel1_2_Villain_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);


        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Sel1_2_Player_Narration3, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        StartCoroutine(chatting2());
    }

    IEnumerator chatting2()
    {
        PlayerCtrl.IsMove = false;

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Sec_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sec_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        SelectBox_2.SetActive(true);
        StartCoroutine(Local_Scale_up(SelectBox_2));
        yield return new WaitForSeconds(0.5f);
    }

    //2-1번 선택지(호의적인 대답)
    public IEnumerator Choice_2_1()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(SelectBox_2));
        yield return new WaitForSeconds(0.5f);
        SelectBox_2.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Sel2_1_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Sel2_1_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel2_1_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel2_1_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        timer.LimitTime += 120;

        StartCoroutine(chatting3());
    }

    //2-2번 선택지(적대적인 대답)
    public IEnumerator Choice_2_2()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(SelectBox_2));
        yield return new WaitForSeconds(0.5f);
        SelectBox_2.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Sel2_2_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Sel2_2_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel2_2_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel2_2_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        StartCoroutine(chatting3());
    }

    IEnumerator chatting3()
    {
        PlayerCtrl.IsMove = false;

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Thr_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Thr_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Thr_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Thr_Player_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        SelectBox_3.SetActive(true);
        StartCoroutine(Local_Scale_up(SelectBox_3));
        yield return new WaitForSeconds(0.5f);
    }

    //3-1번 선택지(호의적인 대답)
    public IEnumerator Choice_3_1()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(SelectBox_3));
        yield return new WaitForSeconds(0.5f);
        SelectBox_3.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Sel3_1_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Sel3_1_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel3_1_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel3_1_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel3_1_Villain_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel3_1_Villain_Narration3, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        timer.LimitTime += 120;

        StartCoroutine(chatting4());
    }

    //3-2번 선택지(적대적인 대답)
    public IEnumerator Choice_3_2()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(SelectBox_3));
        yield return new WaitForSeconds(0.5f);
        SelectBox_3.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Sel3_2_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel3_2_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Sel3_2_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel3_2_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        StartCoroutine(chatting4());
    }

    IEnumerator chatting4()
    {
        PlayerCtrl.IsMove = false;

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Villain_Narration_chat.DOText(Narration_Script.Fou_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Fou_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Fou_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Fou_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Fou_Player_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        SelectBox_4.SetActive(true);
        StartCoroutine(Local_Scale_up(SelectBox_4));
        yield return new WaitForSeconds(0.5f);
    }

    //4-1번 선택지(긍정적 대답)
    public IEnumerator Choice_4_1()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(SelectBox_4));
        yield return new WaitForSeconds(0.5f);
        SelectBox_4.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Sel4_1_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Sel4_1_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Sel4_1_Player_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel4_1_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel4_1_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel4_1_Villain_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        timer.LimitTime += 120;

        StartCoroutine(chatting5());
    }

    //4-2번 선택지(소리치며 관심을 끈다)
    public IEnumerator Choice_4_2()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(SelectBox_4));
        yield return new WaitForSeconds(0.5f);
        SelectBox_4.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Sel4_2_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        texting = Narrationchat.DOText(Narration_Script.Sel4_2_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        texting = Narrationchat.DOText(Narration_Script.Sel4_2_Player_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel4_2_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Sel4_2_Player_Narration3, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        StartCoroutine(chatting5());
    }

    IEnumerator chatting5()
    {
        PlayerCtrl.IsMove = false;

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Fif_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Fif_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Fif_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Fif_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Fif_Player_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Fif_Player_Narration3, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Fif_Player_Narration4, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        SelectBox_5.SetActive(true);
        StartCoroutine(Local_Scale_up(SelectBox_5));
        yield return new WaitForSeconds(0.5f);
    }

    //5-1번 선택지(먹는다)
    public IEnumerator Choice_5_1()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(SelectBox_5));
        yield return new WaitForSeconds(0.5f);
        SelectBox_5.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Sel5_1_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel5_1_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel5_1_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        timer.LimitTime += 120;


        StartCoroutine(Lastchatting());
    }

    //5-2번 선택지(안먹는다)
    public IEnumerator Choice_5_2()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(SelectBox_5));
        yield return new WaitForSeconds(0.5f);
        SelectBox_5.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Sel5_2_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel5_2_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Sel5_2_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel5_2_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Sel5_2_Villain_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Sel5_2_Player_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        StartCoroutine(Lastchatting());
    }

    IEnumerator Lastchatting()
    {
        PlayerCtrl.IsMove = false;

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Villain_Narration_chat.DOText(Narration_Script.Last_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Last_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Last_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        GameObject.Find("head").GetComponent<Timer>().enabled = true;
        main_timer.SetActive(true);
        GameObject.Find("Mask").GetComponent<up>().enabled = true;


        PlayerCtrl.IsMove = true;
    }

    public IEnumerator find_vill_door()
    {
        PlayerCtrl.IsMove = false;
        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Vill_Door_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Narrationchat.DOText(Narration_Script.Vill_Door_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Narrationchat.DOText(Narration_Script.Vill_Door_Player_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);
        PlayerCtrl.IsMove = true;

    }

        //문 나레이션
    public IEnumerator find_door()
    {
        PlayerCtrl.IsMove = false;
        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Find_Door_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Narrationchat.DOText(Narration_Script.Find_Door_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);
        yield return new WaitForSeconds(0.3f);

        SelectBox_Door.SetActive(true);
        StartCoroutine(Local_Scale_up(SelectBox_Door));
        yield return new WaitForSeconds(0.5f);
    }


    //문열기
    public IEnumerator open_door()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(SelectBox_Door));
        yield return new WaitForSeconds(0.5f);
        SelectBox_Door.SetActive(false);


        if (PlayerCtrl.lope == true)
        {
            Narration.SetActive(true);
            StartCoroutine(Scale_up(Narration));
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            Tweener texting = Narrationchat.DOText(Narration_Script.Lope_Player_Narration0, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            StartCoroutine(Scale_down(Narration));
            Narration.SetActive(false);
            PlayerCtrl.IsMove = true;
        }
        else if(PlayerCtrl.lope == false && PlayerCtrl.Knife == true)
        {
            Narration.SetActive(true);
            StartCoroutine(Scale_up(Narration));
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            Tweener texting = Narrationchat.DOText(Narration_Script.Door_Open_Player_Narration0, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Door_Open_Player_Narration1, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Door_Open_Player_Narration2, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            audioSource.PlayOneShot(Door_open);
            GameObject.Find("Metal_Door_01").GetComponent<Open_Door>().enabled = true;
            StartCoroutine(Scale_down(Narration));
            Door_Col.SetActive(false);
            Narration.SetActive(false);
            PlayerCtrl.IsMove = true;
        }
        else if (PlayerCtrl.lope == false && PlayerCtrl.Knife == false)
        {
            Narration.SetActive(true);
            StartCoroutine(Scale_up(Narration));
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            Tweener texting = Narrationchat.DOText(Narration_Script.Cannot_Open_Player_Narration0, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Cannot_Open_Player_Narration1, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Stay_Player_Narration0, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            StartCoroutine(Scale_down(Narration));
            Narration.SetActive(false);
            PlayerCtrl.IsMove = true;
        }
    }


    public IEnumerator not_open_door()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(SelectBox_Door));
        yield return new WaitForSeconds(0.5f);
        SelectBox_Door.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Stay_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);
        PlayerCtrl.IsMove = true;
    }



    public IEnumerator Get_Knife()
    {
        PlayerCtrl.IsMove = false;

        if(PlayerCtrl.lope == true) 
        {
            Narration.SetActive(true);
            StartCoroutine(Scale_up(Narration));
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            Tweener texting = Narrationchat.DOText(Narration_Script.Get_Knife_Player_Narration0, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Get_Knife_Player_Narration1, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Get_Knife_Player_Narration2, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            Knife.SetActive(false);
            StartCoroutine(Scale_down(Narration));
            Narration.SetActive(false);

            PlayerCtrl.lope = false;
            PlayerCtrl.Knife = true;
            PlayerCtrl.IsMove = true;
        }
        else if (PlayerCtrl.lope == false)
        {
            Narration.SetActive(true);
            StartCoroutine(Scale_up(Narration));
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            Tweener texting = Narrationchat.DOText(Narration_Script.JGet_Knife_Player_Narration0, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.JGet_Knife_Player_Narration1, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.JGet_Knife_Player_Narration2, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            Knife.SetActive(false);
            StartCoroutine(Scale_down(Narration));
            Narration.SetActive(false);

            PlayerCtrl.Knife = true;
            PlayerCtrl.IsMove = true;
        }
    }

    public IEnumerator get_Oil()
    {
        PlayerCtrl.IsMove = false;

        if(PlayerCtrl.lope == true)
        {
            Narration.SetActive(true);
            StartCoroutine(Scale_up(Narration));
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            Tweener texting = Narrationchat.DOText(Narration_Script.Get_Oil_Player_Narration0, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Get_Oil_Player_Narration1, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Get_Oil_Player_Narration2, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            StartCoroutine(Scale_down(Narration));
            Narration.SetActive(false);

            PlayerCtrl.lope = false;
            PlayerCtrl.IsMove = true;
        }
        else if(PlayerCtrl.lope == false)
        {
            Narration.SetActive(true);
            StartCoroutine(Scale_up(Narration));
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            Tweener texting = Narrationchat.DOText(Narration_Script.Unuse_Oil_Player_Narration0, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Unuse_Oil_Player_Narration1, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            StartCoroutine(Scale_down(Narration));
            Narration.SetActive(false);

            PlayerCtrl.IsMove = true;
        } 
    }
    //열차소리
    public IEnumerator Train_sound()
    {
        PlayerCtrl.IsMove = false;

        audioSource.PlayOneShot(train_Sound);
        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Train_Sound_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Narrationchat.DOText(Narration_Script.Train_Sound_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Narrationchat.DOText(Narration_Script.Train_Sound_Player_Narration2, 3.0f);
        yield return new WaitForSeconds(5.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Narrationchat.DOText(Narration_Script.Train_Sound_Player_Narration3, 3.0f);
        yield return new WaitForSeconds(4.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        PlayerCtrl.lope = false;
        PlayerCtrl.IsMove = true;
    }
    //종이
    public IEnumerator paper()
    {
        PlayerCtrl.IsMove = false;


        if(PlayerCtrl.lope == false)
        {
            Narration.SetActive(true);
            StartCoroutine(Scale_up(Narration));
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            Tweener texting = Narrationchat.DOText(Narration_Script.Paper_Player_Narration0, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Paper_Player_Narration1, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            audioSource.PlayOneShot(Paper_Sound);
            Paper_image.SetActive(true);
            texting = Narrationchat.DOText(Narration_Script.Paper_Player_Narration2, 1.5f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Paper_Player_Narration3, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Paper_Player_Narration4, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Paper_Player_Narration5, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Paper_Player_Narration6, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            texting = Narrationchat.DOText(Narration_Script.Paper_Player_Narration7, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            Paper_image.SetActive(false);
            StartCoroutine(Scale_down(Narration));
            Narration.SetActive(false);

            PlayerCtrl.IsMove = true;
        }
        else if(PlayerCtrl.lope == true)
        {
            Narration.SetActive(true);
            StartCoroutine(Scale_up(Narration));
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            Tweener texting = Narrationchat.DOText(Narration_Script.Can_not_Paper_Player_Narration0, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Can_not_Paper_Player_Narration1, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            StartCoroutine(Scale_down(Narration));
            Narration.SetActive(false);

            PlayerCtrl.IsMove = true;
        } 
    }

    public IEnumerator phone()
    {
        PlayerCtrl.IsMove = false;

        if (Calling_Cop==false)
        {
            Narration.SetActive(true);
            StartCoroutine(Scale_up(Narration));
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            Tweener texting = Narrationchat.DOText(Narration_Script.Phone_Player_Narration0, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Phone_Player_Narration1, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Phone_Player_Narration2, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Phone_Player_Narration3, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            texting = Narrationchat.DOText(Narration_Script.Phone_Player_Narration4, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            StartCoroutine(Scale_down(Narration));
            Narration.SetActive(false);

            SelectBox_Phone.SetActive(true);
            StartCoroutine(Local_Scale_up(SelectBox_Phone));
            yield return new WaitForSeconds(0.5f);
        }
        else
        {
            Narration.SetActive(true);
            StartCoroutine(Scale_up(Narration));
            Narrationchat.text = "";
            yield return new WaitForSeconds(0.5f);
            Tweener texting = Narrationchat.DOText(Narration_Script.Calling_Player_Narration0, 3.0f);
            yield return new WaitForSeconds(3.0f);
            Narrationchat.text = "";
            StartCoroutine(Scale_down(Narration));
            Narration.SetActive(false);

            PlayerCtrl.IsMove = true;
        }
        
    }
    //전화걸기
    public IEnumerator call_cop()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(SelectBox_Phone));
        yield return new WaitForSeconds(0.5f);
        SelectBox_Phone.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Call_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        texting = Narrationchat.DOText(Narration_Script.Call_Cop_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Phone.SetActive(true);
        StartCoroutine(Local_Scale_up(Phone));
        yield return new WaitForSeconds(0.5f);

        phone_image.GetComponent<Image>().sprite = Call_sprites[0];
        yield return new WaitForSeconds(2f);
        audioSource.PlayOneShot(phone_Sound);
        phone_image.GetComponent<Image>().sprite = Call_sprites[1];
        yield return new WaitForSeconds(0.5f);
        phone_image.GetComponent<Image>().sprite = Call_sprites[2];
        audioSource.PlayOneShot(push_butten_Sound);
        yield return new WaitForSeconds(0.5f);
        phone_image.GetComponent<Image>().sprite = Call_sprites[1];
        yield return new WaitForSeconds(0.5f); 
        phone_image.GetComponent<Image>().sprite = Call_sprites[2];
        audioSource.PlayOneShot(push_butten_Sound);
        yield return new WaitForSeconds(0.5f);
        phone_image.GetComponent<Image>().sprite = Call_sprites[1];
        yield return new WaitForSeconds(0.5f);
        phone_image.GetComponent<Image>().sprite = Call_sprites[3];
        audioSource.PlayOneShot(push_butten_Sound);
        yield return new WaitForSeconds(0.5f);
        phone_image.GetComponent<Image>().sprite = Call_sprites[4];
        audioSource.PlayOneShot(calling_Sound);
        yield return new WaitForSeconds(7f);
        phone_image.GetComponent<Image>().sprite = Call_sprites[5];

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        texting = Cop_Narration_chat.DOText(Narration_Script.Say_Where1_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        texting = Narrationchat.DOText(Narration_Script.Say_Where1_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        texting = Narrationchat.DOText(Narration_Script.Say_Where1_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        texting = Cop_Narration_chat.DOText(Narration_Script.Say_Where1_Cop_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        texting = Narrationchat.DOText(Narration_Script.Say_Where1_Player_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        texting = Cop_Narration_chat.DOText(Narration_Script.Say_Where1_Cop_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Question_tBox_1.SetActive(true);
        StartCoroutine(Local_Scale_up(Question_tBox_1));
        yield return new WaitForSeconds(0.5f);
    }

    //전화걸지않기
    public IEnumerator dont_call_cop()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(SelectBox_Phone));
        yield return new WaitForSeconds(0.5f);
        SelectBox_Phone.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Dont_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);
        PlayerCtrl.IsMove = true;
    }

    //위치말하기_1번(폐공장)
    public IEnumerator old_factory()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(Question_tBox_1));
        Question_tBox_1.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Say_1_1_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Cop_Narration_chat.DOText(Narration_Script.Say_1_1_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Narrationchat.DOText(Narration_Script.Say_1_1_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        correct_count += 1;

        StartCoroutine(ask_address_chatting());
    }

    //위치말하기_2번(폐가)
    public IEnumerator old_house()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(Question_tBox_1));
        Question_tBox_1.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Say_1_2_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Cop_Narration_chat.DOText(Narration_Script.Say_1_2_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Narrationchat.DOText(Narration_Script.Say_1_2_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        StartCoroutine(ask_address_chatting());
    }
    //위치말하기_3번(폐병원)
    public IEnumerator old_hospital()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(Question_tBox_1));
        Question_tBox_1.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Say_1_3_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Cop_Narration_chat.DOText(Narration_Script.Say_1_3_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Narrationchat.DOText(Narration_Script.Say_1_3_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        StartCoroutine(ask_address_chatting());
    }

    //주소 물어보기
    IEnumerator ask_address_chatting()
    {
        PlayerCtrl.IsMove = false;

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Cop_Narration_chat.DOText(Narration_Script.Say_Where2_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Say_Where2_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Say_Where2_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Question_tBox_2.SetActive(true);
        StartCoroutine(Local_Scale_up(Question_tBox_2));
        yield return new WaitForSeconds(0.5f);
    }

    //주소말하기_1번(검암동)
    public IEnumerator gumarm()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(Question_tBox_2));
        Question_tBox_2.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Say_2_1_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Cop_Narration_chat.DOText(Narration_Script.Say_2_1_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Narrationchat.DOText(Narration_Script.Say_2_1_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        StartCoroutine(ask_sound_chatting());
    }

    //주소말하기_2번(교동)
    public IEnumerator kyo()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(Question_tBox_2));
        Question_tBox_2.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Say_2_2_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Cop_Narration_chat.DOText(Narration_Script.Say_2_2_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Narrationchat.DOText(Narration_Script.Say_2_2_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        correct_count += 1;

        StartCoroutine(ask_sound_chatting());
    }

    //주소말하기_3번(장기동)
    public IEnumerator janggi()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(Question_tBox_2));
        Question_tBox_2.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Say_2_3_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Cop_Narration_chat.DOText(Narration_Script.Say_2_3_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Narrationchat.DOText(Narration_Script.Say_2_3_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        StartCoroutine(ask_sound_chatting());
    }

    //특징 물어보기
    IEnumerator ask_sound_chatting()
    {
        PlayerCtrl.IsMove = false;

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Cop_Narration_chat.DOText(Narration_Script.Say_Where3_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Say_Where3_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Question_tBox_3.SetActive(true);
        StartCoroutine(Local_Scale_up(Question_tBox_3));
        yield return new WaitForSeconds(0.5f);
    }

    //특징말하기_1번(철도)
    public IEnumerator train_sound()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(Question_tBox_3));
        Question_tBox_3.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Say_3_1_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Cop_Narration_chat.DOText(Narration_Script.Say_3_1_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Narrationchat.DOText(Narration_Script.Say_3_1_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        correct_count += 1;
        Calling_Cop = true;

        StartCoroutine(go_cop_chatting());
    }

    //특징말하기_2번(비행기)
    public IEnumerator airport_sound()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(Question_tBox_3));
        Question_tBox_3.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Say_3_2_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Cop_Narration_chat.DOText(Narration_Script.Say_3_2_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Narrationchat.DOText(Narration_Script.Say_3_2_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Calling_Cop = true;

        StartCoroutine(go_cop_chatting());
    }

    //특징말하기_3번(항구)
    public IEnumerator port_sound()
    {
        PlayerCtrl.IsMove = false;
        StartCoroutine(Local_Scale_down(Question_tBox_3));
        Question_tBox_3.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Say_3_3_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Cop_Narration_chat.DOText(Narration_Script.Say_3_3_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.5f);
        texting = Narrationchat.DOText(Narration_Script.Say_3_3_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Calling_Cop = true;

        StartCoroutine(go_cop_chatting());
    }

    //경찰전화 끝
    IEnumerator go_cop_chatting()
    {
        PlayerCtrl.IsMove = false;

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Cop_Narration_chat.DOText(Narration_Script.Say_go_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Say_go_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Say_go_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Local_Scale_down(Phone));
        Phone.SetActive(false);

        End_Col.SetActive(true);
        Train_Col.SetActive(false);

        if (correct_count == 3)
        {
            PlayerCtrl.IsMove = true;
            Ending_vill.SetActive(true);
            Block.SetActive(false);
        }
        else
        {
            StartCoroutine(game_over());
            Game_over_vill.SetActive(true);
        }
    }

    //경찰등장
    public IEnumerator game_end()
    {
        PlayerCtrl.IsMove = false;
        GameObject.Find("head").GetComponent<Timer>().enabled = false;
        main_timer.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Game_End_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
         texting = Villain_Narration_chat.DOText(Narration_Script.Game_End_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Game_End_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Game_End_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Game_End_Player_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Boom_Point.SetActive(true);
        Cop.SetActive(true);
        Boom_on = true;

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Cop_Narration_chat.DOText(Narration_Script.Game_End_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Game_End_Villain_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Game_End_Player_Narration3, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Game_End_Player_Narration4, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Ending_Sel.SetActive(true);
        StartCoroutine(Local_Scale_up(Ending_Sel));
        yield return new WaitForSeconds(0.5f);

    }

    //서있기
    public IEnumerator stand_up()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Local_Scale_down(Ending_Sel));
        Ending_Sel.SetActive(false);
        
        PlayerCtrl.IsMove = false;

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Stand_Up_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Cop_Narration_chat.DOText(Narration_Script.Stand_Up_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        Shoot_V_and_P = true;
        audioSource.PlayOneShot(Bang_Sound);
        die = true;
        texting = Cop_Narration_chat.DOText(Narration_Script.Stand_Up_Cop_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        audioSource.PlayOneShot(Bang_Sound);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Stand_Up_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Stand_Up_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Ending_Mask.SetActive(true);
        Light.SetActive(false);
        News_Narration.SetActive(true);
        StartCoroutine(Scale_up(News_Narration));
        News_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = News_Narration_chat.DOText(Narration_Script.Stand_Up_news_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        News_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = News_Narration_chat.DOText(Narration_Script.Stand_Up_news_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        News_Narration_chat.text = "";
        StartCoroutine(Scale_down(News_Narration));
        News_Narration.SetActive(false);
        SceneManager.LoadScene("KidnapReplay");
    }

    //엎드리기
    public IEnumerator stand_down()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Local_Scale_down(Ending_Sel));
        Ending_Sel.SetActive(false);

        PlayerCtrl.IsMove = false;

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Narrationchat.DOText(Narration_Script.Stand_Down_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);
        rd.useGravity=false;
        rd.isKinematic=true;
        Camera.transform.position = Vector3.MoveTowards(Camera.transform.position, Down_Pose, 0.3f);

        Cop_Narration.SetActive(true);
        StartCoroutine(Scale_up(Cop_Narration));
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Cop_Narration_chat.DOText(Narration_Script.Stand_Down_Cop_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Cop_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        Shoot_V = true;
        audioSource.PlayOneShot(Bang_Sound);
        die = true;
        texting = Cop_Narration_chat.DOText(Narration_Script.Stand_Down_Cop_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        audioSource.PlayOneShot(Bang_Sound);
        Cop_Narration_chat.text = "";
        StartCoroutine(Scale_down(Cop_Narration));
        Cop_Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Stand_Down_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Ending_Mask.SetActive(true);
        Light.SetActive(false);
        News_Narration.SetActive(true);
        StartCoroutine(Scale_up(News_Narration));
        News_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = News_Narration_chat.DOText(Narration_Script.Stand_Down_news_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        News_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = News_Narration_chat.DOText(Narration_Script.Stand_Down_news_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        News_Narration_chat.text = "";
        StartCoroutine(Scale_down(News_Narration));
        News_Narration.SetActive(false);
        SceneManager.LoadScene("KidnapReplay");
    }

    //게임오버
    public IEnumerator game_over()
    {
        PlayerCtrl.IsMove = false;

        Cop_Narration.SetActive(false);
        Villain_Narration.SetActive(false);
        Narration.SetActive(false);
        SelectBox_1.SetActive(false);
        SelectBox_2.SetActive(false);
        SelectBox_3.SetActive(false);
        SelectBox_4.SetActive(false);
        SelectBox_5.SetActive(false);
        SelectBox_Door.SetActive(false);
        SelectBox_Phone.SetActive(false);
        Knife.SetActive(false);
        Door_Col.SetActive(false);
        Door.SetActive(false);
        Question_tBox_1.SetActive(false);
        Question_tBox_2.SetActive(false);
        Question_tBox_3.SetActive(false);
        Phone.SetActive(false);
        phone_image.SetActive(false);
        GameObject.Find("head").GetComponent<Timer>().enabled = false;
        main_timer.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Villain_Narration_chat.DOText(Narration_Script.Game_Over_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Game_Over_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Vill_Move = true;
        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Game_Over_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Game_Over_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Game_Over_Villain_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Game_Over_Player_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Vill_Hit = true;
        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Game_Over_Villain_Narration3, 3.0f);
        yield return new WaitForSeconds(3.0f);
        audioSource.PlayOneShot(Hit_Sound);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);
        Light.SetActive(false);
        Ending_Mask.SetActive(true);
        Game_over_vill.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Game_Over_Player_Narration3, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        News_Narration.SetActive(true);
        StartCoroutine(Scale_up(News_Narration));
        News_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = News_Narration_chat.DOText(Narration_Script.Game_Over_news_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        News_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = News_Narration_chat.DOText(Narration_Script.Game_Over_news_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        News_Narration_chat.text = "";
        StartCoroutine(Scale_down(News_Narration));
        News_Narration.SetActive(false);
        SceneManager.LoadScene("KidnapReplay");
    }

    //타임오버
    public IEnumerator time_over()
    {
        PlayerCtrl.IsMove = false;
        Time_over_vill.SetActive(true);

        Cop_Narration.SetActive(false);
        Villain_Narration.SetActive(false);
        Narration.SetActive(false);
        SelectBox_1.SetActive(false);
        SelectBox_2.SetActive(false);
        SelectBox_3.SetActive(false);
        SelectBox_4.SetActive(false);
        SelectBox_5.SetActive(false);
        SelectBox_Door.SetActive(false);
        SelectBox_Phone.SetActive(false);
        Knife.SetActive(false);
        Door_Col.SetActive(false);
        Door.SetActive(false);
        Question_tBox_1.SetActive(false);
        Question_tBox_2.SetActive(false);
        Question_tBox_3.SetActive(false);
        Phone.SetActive(false);
        phone_image.SetActive(false);
        GameObject.Find("head").GetComponent<Timer>().enabled = false;
        main_timer.SetActive(false);
        GameObject.Find("SM_Bld_Interior_Door_01").GetComponent<Open_Door>().enabled = true;

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        Tweener texting = Villain_Narration_chat.DOText(Narration_Script.Time_Over_Villain_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Time_Over_Player_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        texting = Narrationchat.DOText(Narration_Script.Time_Over_Player_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Vill_Move = true;
        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Time_Over_Villain_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Time_Over_Player_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Villain_Narration.SetActive(true);
        StartCoroutine(Scale_up(Villain_Narration));
        Villain_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Villain_Narration_chat.DOText(Narration_Script.Time_Over_Villain_Narration2, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Villain_Narration_chat.text = "";
        StartCoroutine(Scale_down(Villain_Narration));
        Villain_Narration.SetActive(false);

        Narration.SetActive(true);
        StartCoroutine(Scale_up(Narration));
        Narrationchat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = Narrationchat.DOText(Narration_Script.Time_Over_Player_Narration3, 3.0f);
        yield return new WaitForSeconds(3.0f);
        Narrationchat.text = "";
        StartCoroutine(Scale_down(Narration));
        Narration.SetActive(false);

        Ending_Mask.SetActive(true);
        Light.SetActive(false);
        News_Narration.SetActive(true);
        StartCoroutine(Scale_up(News_Narration));
        News_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = News_Narration_chat.DOText(Narration_Script.Time_Over_news_Narration0, 3.0f);
        yield return new WaitForSeconds(3.0f);
        News_Narration_chat.text = "";
        yield return new WaitForSeconds(0.1f);
        texting = News_Narration_chat.DOText(Narration_Script.Time_Over_news_Narration1, 3.0f);
        yield return new WaitForSeconds(3.0f);
        News_Narration_chat.text = "";
        StartCoroutine(Scale_down(News_Narration));
        News_Narration.SetActive(false);
        SceneManager.LoadScene("KidnapReplay");
    }


    public IEnumerator Scale_up(GameObject box) //UI 나타날때 효과 함수
    {
        for (int i = 0; i < box.transform.childCount; i++)
        {
            if (box.transform.GetChild(i).GetComponent<Button>() != null)
                box.transform.GetChild(i).GetComponent<Button>().enabled = true;
        }
        if (box.GetComponent<Button>() != null)
            box.GetComponent<Button>().enabled = true;
        box.transform.DOScale(new Vector3(0f, 0f, 0f), 0f);
        yield return new WaitForSeconds(0.5f); //0.5초 뒤에
        box.SetActive(true); //활성화 시킴

        yield return new WaitForSeconds(0.2f);
        box.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        box.transform.DOScale(new Vector3(5f, 3.3f, 3f), 0.3f).SetEase(Ease.Linear);
    }

    public IEnumerator Scale_down(GameObject s_box)
    {
        for (int i = 0; i < s_box.transform.childCount; i++)
        {
            if (s_box.transform.GetChild(i).GetComponent<Button>() != null)
                s_box.transform.GetChild(i).GetComponent<Button>().enabled = false;
        }
        if (s_box.GetComponent<Button>() != null)
            s_box.GetComponent<Button>().enabled = false;
        s_box.transform.DOScale(new Vector3(5f, 3.3f, 3f), 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        s_box.transform.DOScale(new Vector3(2.5f, 1.6f, 1.5f), 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        s_box.transform.DOScale(new Vector3(0, 0, 0), 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);

    }
    public IEnumerator Local_Scale_up(GameObject box) //UI 나타날때 효과 함수
    {
        for (int i = 0; i < box.transform.childCount; i++)
        {
            if (box.transform.GetChild(i).GetComponent<Button>() != null)
                box.transform.GetChild(i).GetComponent<Button>().enabled = true;
        }
        if (box.GetComponent<Button>() != null)
            box.GetComponent<Button>().enabled = true;
        box.transform.DOScale(new Vector3(0f, 0f, 0f), 0f);
        yield return new WaitForSeconds(0.5f); //0.5초 뒤에
        box.SetActive(true); //활성화 시킴

        yield return new WaitForSeconds(0.1f); //0.1초 뒤에
        box.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.2f).SetEase(Ease.Linear);

        yield return new WaitForSeconds(0.2f);
        box.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        box.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.3f).SetEase(Ease.Linear);
    }

    public IEnumerator Local_Scale_down(GameObject s_box)
    {
        for (int i = 0; i < s_box.transform.childCount; i++)
        {
            if (s_box.transform.GetChild(i).GetComponent<Button>() != null)
                s_box.transform.GetChild(i).GetComponent<Button>().enabled = false;
        }
        if (s_box.GetComponent<Button>() != null)
            s_box.GetComponent<Button>().enabled = false;
        s_box.transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        s_box.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        s_box.transform.DOScale(new Vector3(0, 0, 0), 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
    }

    IEnumerator LoadDevice(string newDevice, bool enable)
    {
        UnityEngine.XR.XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        UnityEngine.XR.XRSettings.enabled = enable;
    }
}