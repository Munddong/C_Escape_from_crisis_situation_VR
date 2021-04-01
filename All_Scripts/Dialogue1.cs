using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Dialogue1 : MonoBehaviour
{
    [Header("Objects")]
    public GameObject doorCanvas;
    public GameObject doorCanvas2;
    public GameObject closet1;
    public GameObject drawer1;
    public GameObject door_s2;
    public GameObject cursorImage;

    [Header("Dialogue")]
    public GameObject NarrationBox;
    public GameObject BlackBox;
    public Text NarrationText;
    public Text NarrationText2;

    [Header("UI")]
    public Image tip1;
    public Image tip2;
    public Image tip3;
    public Image tip4;
    public Image black;
    public Image clickImage;
    
    [Header("Sounds")]
    private AudioSource audioSource;
    //public AudioClip typing;
    public AudioClip pop;
    public AudioClip crash;
    public AudioClip waterSound;

    [Header("Animations")]
    public PlayableDirector playableDirectorHome;

    public TimelineAsset OpenClosetTimeline;
    public TimelineAsset OpenDoorTimeline;
    public TimelineAsset OpenDoorTimeline2;
    public TimelineAsset OpenDoorTimeline3;
    public TimelineAsset OpenDrawerTimeline;
    public TimelineAsset OpenClosetTimeline2;
    public TimelineAsset OpenDoorTimeline4;
    public TimelineAsset moveBicycleTimeline;

    private int tipState = 0;
    private IEnumerator coroutine;
    PlayerCtrl1 playerCtrl;
    private bool isTexting = false;

    private void Awake()
    {
        StartCoroutine(LoadDevice("cardboard", true));
    }

    void Start()
    {
        coroutine = tips();  
        NarrationText.text = "";
        NarrationText2.text = "";
        audioSource = GetComponent<AudioSource>();
        playerCtrl = GetComponent<PlayerCtrl1>();
        StartCoroutine(coroutine);
    }
    private void Update()
    {
        if (tipState == 0)
            if (Input.GetMouseButtonDown(0))
            {
                StopCoroutine(coroutine);
                tip4.gameObject.SetActive(false);
                tip3.gameObject.SetActive(false);
                tip2.gameObject.SetActive(false);
                tip1.gameObject.SetActive(false);
                black.gameObject.SetActive(false);
                clickImage.gameObject.SetActive(false);
                StartCoroutine(chapter1());
                
            }

        if (isTexting == true)
        {
            playerCtrl.gaugeTimer = 0.0f;
        }
    }
    public IEnumerator tips()
    {
        UnityEngine.Debug.Log("Tips");

        float time = 0;

        yield return new WaitForSeconds(2.5f);
        tip4.gameObject.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        tip3.gameObject.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        tip2.gameObject.SetActive(false);
        yield return new WaitForSeconds(2.5f);

        Color fadeColor = tip1.color;
        fadeColor.a = Mathf.Lerp(1, 0, time);
        clickImage.gameObject.SetActive(false);
        while (fadeColor.a != 0) //알파 값 0 될 때 까지
            {
                time += Time.deltaTime / 3.0f; //3초동안 fade in
                fadeColor.a = Mathf.Lerp(1, 0, time);
                tip1.color = fadeColor;
                black.color = fadeColor;
                yield return null;
            }
        StartCoroutine(chapter1());      
    }
    public IEnumerator chapter1()
    {
        tipState = 1;
        //yield return new WaitForSeconds(15.5f);

        UnityEngine.Debug.Log("Chapter1");
        Tweener texting;
        
        yield return new WaitForSeconds(1f);

        StartCoroutine(Scale_up(NarrationBox));
        yield return new WaitForSeconds(0.5f);
        texting = NarrationText.DOText(Narration_Script1.player1, 3.5f);
        yield return new WaitForSeconds(4.0f);
        NarrationText.text = "";

        StartCoroutine(Scale_down(NarrationBox));

        gameObject.GetComponent<PlayerCtrl1>().enabled = true;
    }
    public IEnumerator c1_bed1()
    {
        Tweener texting;
        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText(Narration_Script1.bed1, 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));

    }
    public IEnumerator c1_phone1()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText(Narration_Script1.phone1, 1.5f);
        yield return new WaitForSeconds(2.5f);
        NarrationText.text = "";
        NarrationText.DOText(Narration_Script1.phone1_1, 1.5f);
        yield return new WaitForSeconds(2.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));
    }
    public IEnumerator c1_switch1()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText(Narration_Script1.switch1, 1.5f);
        yield return new WaitForSeconds(2.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));
    }
    public IEnumerator c1_water1()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText("물이 조금 남아있다.", 1.5f);
        yield return new WaitForSeconds(2.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));
    }
    public IEnumerator c4_water1()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText(Narration_Script1.water_1, 1.5f);
        yield return new WaitForSeconds(2.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));
        audioSource.PlayOneShot(waterSound);
    }
    public IEnumerator c1_closet1()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText(Narration_Script1.closet1, 1.5f);
        yield return new WaitForSeconds(2.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));
    }
    public IEnumerator c4_closet1()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText(Narration_Script1.closet4, 1.5f);
        yield return new WaitForSeconds(2.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));
    }
    public IEnumerator c1_door1()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText(Narration_Script1.door1, 3.5f);
        yield return new WaitForSeconds(4.5f);
        NarrationText.text = "";

        StartCoroutine(Scale_down(NarrationBox));
    }
    public IEnumerator c4_door1()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText(Narration_Script1.player4, 3.5f);
        yield return new WaitForSeconds(4.5f);
        NarrationText.text = "";
        texting = NarrationText.DOText(Narration_Script1.player4_1, 3.5f);
        yield return new WaitForSeconds(4.5f);
        NarrationText.text = "";

        StartCoroutine(Scale_down(NarrationBox));
    }
    public IEnumerator c1_door1_1()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText(Narration_Script1.door1_1, 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";

        StartCoroutine(Scale_down(NarrationBox));

        doorCanvas.SetActive(true);
    }
    public IEnumerator c1_yes()
    {
        Tweener texting;

        doorCanvas.SetActive(false);

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText("...!!!", 1.5f);
        yield return new WaitForSeconds(2.5f);
        NarrationText.text = "";
        texting = NarrationText.DOText("문고리가 뜨거워서 손을 데였다.", 2.5f);
        yield return new WaitForSeconds(2.5f);
        NarrationText.text = "";
        texting = NarrationText.DOText(Narration_Script1.player2, 2.5f);
        yield return new WaitForSeconds(2.5f);
        NarrationText.text = "";

        StartCoroutine(Scale_down(NarrationBox));
        closet1.gameObject.tag = "closet1";
        drawer1.gameObject.tag = "drawer1";
    }
    public IEnumerator c1_no()
    {
        Tweener texting;

        doorCanvas.SetActive(false);

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText("문고리가 뜨거워 보인다.", 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        texting = NarrationText.DOText(Narration_Script1.player2, 2.5f);
        yield return new WaitForSeconds(2.5f);
        NarrationText.text = "";

        StartCoroutine(Scale_down(NarrationBox));
        closet1.gameObject.tag = "closet1";
        drawer1.gameObject.tag = "drawer1";
    }

    public IEnumerator openCloset ()
    {
        //문열림
        playableDirectorHome.Play(OpenClosetTimeline);

        yield return new WaitForSeconds(3f);
    }
    public IEnumerator clothes()
    {
        //문열림
        playableDirectorHome.Play(OpenClosetTimeline);

        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText("옷이 있다.", 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        texting = NarrationText.DOText(Narration_Script1.player2, 2.5f);
        yield return new WaitForSeconds(2.5f);
        NarrationText.text = "";

    }
    public IEnumerator c3_others()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText("도움이 될만한건 없어보인다.", 3.5f);
        yield return new WaitForSeconds(4.5f);
        NarrationText.text = "";

        StartCoroutine(Scale_down(NarrationBox));
    }

    public IEnumerator openDoor()
    {
        //문열림
        playerCtrl.walkSpeed = 0;
        playableDirectorHome.Play(OpenDoorTimeline);
        yield return new WaitForSeconds(3f);
        doorCanvas2.SetActive(true);
        Tweener texting;

        
        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText(Narration_Script1.player3, 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));
        playerCtrl.walkSpeed = 0.015f;
    }
    public IEnumerator c5_door()
    {
        //문열림
        playableDirectorHome.Play(OpenDoorTimeline2);
        yield return new WaitForSeconds(3f);  
    }
    public IEnumerator bathroomDoor()
    {
        //문열림
        playableDirectorHome.Play(OpenDoorTimeline3);
        yield return new WaitForSeconds(3f);
    }
    public IEnumerator openDrawer()
    {
        //문열림
        playableDirectorHome.Play(OpenDrawerTimeline);
        yield return new WaitForSeconds(3f);
    }
    public IEnumerator c6_closet()
    {
        //문열림
        playableDirectorHome.Play(OpenClosetTimeline2);
        yield return new WaitForSeconds(3f);
    }
    public IEnumerator terraceDoor()
    {
        //문열림
        playableDirectorHome.Play(OpenDoorTimeline4);
        yield return new WaitForSeconds(3f);
    }
    public IEnumerator waiting()
    {
        doorCanvas2.SetActive(false);
        Tweener texting;
        playerCtrl.walkSpeed = 0;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText("누군가 신고해주지 않았을까?", 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        texting = NarrationText.DOText("구조를 기다려보자.", 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));

        //사망
        isTexting = true;
        BlackBox.SetActive(true);
        texting = NarrationText2.DOText("그렇게 하염없이 구조를 기다리던 나는 정신을 잃고 쓰러지게 되었다.", 6.5f);
        yield return new WaitForSeconds(7.5f);
        NarrationText2.text = "";
        texting = NarrationText2.DOText("뒤늦게 구조대가 도착했을 땐 이미 늦은 상태였다.", 5.5f);
        yield return new WaitForSeconds(8.5f);
        NarrationText2.text = "";
        //씬전환
        SceneManager.LoadScene("FireReplay");
    }
    public IEnumerator finding()
    {
        doorCanvas2.SetActive(false);
        Tweener texting;
        playerCtrl.walkSpeed = 0;
        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText("구조대를 기다리기엔 시간이 없을 것 같아...", 3.5f);
        yield return new WaitForSeconds(4.5f);
        NarrationText.text = "";
        texting = NarrationText.DOText("탈출 방법을 찾아봐야겠어.", 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        texting = NarrationText.DOText(Narration_Script1.closet4_1, 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));

        door_s2.SetActive(true);
        playerCtrl.walkSpeed = 0.015f;
    }
    public IEnumerator going()
    {
        doorCanvas2.SetActive(false);
        Tweener texting;
        playerCtrl.walkSpeed = 0;
        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText("잠깐만 참으면 현관으로 갈 수 있을 거 같은데...", 3.5f);
        yield return new WaitForSeconds(4.5f);
        NarrationText.text = "";
        texting = NarrationText.DOText("한 번 가보자!", 1.5f);
        yield return new WaitForSeconds(2.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));
        playerCtrl.walkSpeed = 0.02f;
        //사망
        isTexting = true;
        BlackBox.SetActive(true);
        texting = NarrationText2.DOText("그렇게 불길을 가로질렀지만, 뜨거움과 고통은 생각보다 컸다.", 5.5f);
        yield return new WaitForSeconds(7.5f);
        NarrationText2.text = "";
        texting = NarrationText2.DOText("나는 심각한 전신 화상을 입게 되었고, 뒤늦게 병원에 옮겨졌지만", 5.5f);
        yield return new WaitForSeconds(7.5f);
        NarrationText2.text = "";
        texting = NarrationText2.DOText("끝내 숨을 거두고 말았다.", 3.5f);
        yield return new WaitForSeconds(7.5f);
        NarrationText2.text = "";
        //씬전환
        SceneManager.LoadScene("FireReplay");
    }

    public IEnumerator c6_shower()
    {
        Tweener texting;
        audioSource.PlayOneShot(waterSound);

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText(Narration_Script1.shower5, 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        texting = NarrationText.DOText(Narration_Script1.player5, 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        texting = NarrationText.DOText(Narration_Script1.player5_1, 3.5f);
        yield return new WaitForSeconds(4.5f);
        NarrationText.text = "";

        StartCoroutine(Scale_down(NarrationBox));
    }
    public IEnumerator c6_candle()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText("형이 자주 사용하는 향초들이다.", 3.0f);
        yield return new WaitForSeconds(4.0f);
        NarrationText.text = "";      

        StartCoroutine(Scale_down(NarrationBox));
    }
    public IEnumerator c6_bed()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText(Narration_Script1.bed5, 1.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        texting = NarrationText.DOText(Narration_Script1.bed5_1, 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";

        StartCoroutine(Scale_down(NarrationBox));
    }
    public IEnumerator c6_shower2()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText("이불에 물을 묻혔다.", 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        texting = NarrationText.DOText("테라스쪽으로 갈 수 있을 것 같다.", 3.0f);
        yield return new WaitForSeconds(4.0f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));

        //테라스 앞 콜라이더 제거
    }
    public IEnumerator warning1()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText(Narration_Script1.warning6, 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        texting = NarrationText.DOText(Narration_Script1.warning6_1, 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));

    }
    public IEnumerator lock1()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText(Narration_Script1.lock6, 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));

    }
    public IEnumerator lock2()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText(Narration_Script1.lock6_1, 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));
    }
    public IEnumerator bicycle1()
    {
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText(Narration_Script1.bicycle6, 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));
    }
    public IEnumerator bicycle2()
    {
        //자전거 치우기
        playableDirectorHome.Play(moveBicycleTimeline);
        yield return new WaitForSeconds(2.5f);
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText("자전거를 치웠다.", 2.5f);
        yield return new WaitForSeconds(3.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));
    }
    public IEnumerator ending()
    {
        doorCanvas2.SetActive(false);
        Tweener texting;

        StartCoroutine(Scale_up(NarrationBox));
        texting = NarrationText.DOText("부셔보자!", 1.5f);
        yield return new WaitForSeconds(2.5f);
        NarrationText.text = "";
        StartCoroutine(Scale_down(NarrationBox));

        audioSource.PlayOneShot(crash);
        //엔딩
        isTexting = true;
        BlackBox.SetActive(true);
        texting = NarrationText2.DOText("난 경량칸막이를 부수고 옆집으로 무사히 피신할 수 있었다.", 6.5f);
        yield return new WaitForSeconds(7.5f);
        NarrationText2.text = "";
        texting = NarrationText2.DOText("나중에 얘기를 들어보니 형이 부엌에 향초를 피워놓고 나가서 화재가 나게 된 것이라고 한다.", 6.5f);
        yield return new WaitForSeconds(7.5f);
        NarrationText2.text = "";
        texting = NarrationText2.DOText("불행 중 다행으로 화재로 인한 인명피해는 없었다고 한다.", 6.5f);
        yield return new WaitForSeconds(6.5f);
        NarrationText2.text = "";
        //씬전환
        SceneManager.LoadScene("FireReplay");

    }
    public IEnumerator Scale_up(GameObject box) //UI 나타날때 효과 함수
    {
        isTexting = true;

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
        box.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f).SetEase(Ease.Linear);
        audioSource.PlayOneShot(pop);

        yield return new WaitForSeconds(0.2f);
        box.transform.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        box.transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f).SetEase(Ease.Linear);

        yield return new WaitForSeconds(1f);
    }
    public IEnumerator Scale_down(GameObject s_box)
    {
        isTexting = false;

        for (int i = 0; i < s_box.transform.childCount; i++)
        {
            if (s_box.transform.GetChild(i).GetComponent<Button>() != null)
                s_box.transform.GetChild(i).GetComponent<Button>().enabled = false;
        }
        if (s_box.GetComponent<Button>() != null)
            s_box.GetComponent<Button>().enabled = false;
        s_box.transform.DOScale(new Vector3(1f, 1f, 1f), 0.3f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        s_box.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);
        s_box.transform.DOScale(new Vector3(0, 0, 0), 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.2f);    
        yield return new WaitForSeconds(0.5f);
        s_box.SetActive(false);
    }

    IEnumerator LoadDevice(string newDevice, bool enable)
    {
        UnityEngine.XR.XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        UnityEngine.XR.XRSettings.enabled = enable;
    }
}