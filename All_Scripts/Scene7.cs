using System.Collections;
using UnityEngine;
using UnityEngine.UI; //<Button>사용
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Scene7 : MonoBehaviour
{
    public Text DialogueText;
    public GameObject DialogueBox;

    public GameObject Canvas_Q1;
    public GameObject Canvas_Q1_1;
    public GameObject Canvas_Q2;
    public GameObject Canvas_Q3;
    public GameObject Canvas_Q4;
    public GameObject Fade;

    private GameObject PlayerCamera;
    private AudioSource Audio;
    public AudioClip sound1;

    PlayerCtrl_yejin2 player_script;

    void Start()
    {
        player_script = GameObject.Find("Camera_Player's view").GetComponent<PlayerCtrl_yejin2>();
        DialogueText.text = "";
        Audio = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "Scene07")
        {
            PlayerCamera = GameObject.Find("Camera_Player's view");
            StartCoroutine(s7_start());
            Audio = GetComponent<AudioSource>();
            Audio.clip = sound1;
            Audio.Play();
        }
        if (SceneManager.GetActiveScene().name == "Scene08")
        {
            StartCoroutine(s8_start());
            Canvas_Q2.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);

        }
        if (SceneManager.GetActiveScene().name == "Scene09")
        {
            StartCoroutine(s9_start());
            Canvas_Q2.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
            Canvas_Q3.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
            Canvas_Q4.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);

        }

    }


    public IEnumerator s7_start()
    {
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Q("날씨 진짜 좋네."));
        yield return new WaitForSeconds(5f);
        StartCoroutine(Q2("오랫만에 등산하니까 힘들다..", "여기가 어디쯤이지?"));
        yield return new WaitForSeconds(5f);
        StartCoroutine(Q("나무가 엄청 많네.."));
        yield return new WaitForSeconds(5f);
        StartCoroutine(Q("가을인데 모기 물리는건 아니겠지?"));
        yield return new WaitForSeconds(4.5f);
        DialogueText.text = "";
        UpBox();
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<LookWalk>().enabled = true;
        T("응? 저게 뭐지?", 1); //텍스트 나옴
        yield return new WaitForSeconds(1.5f);
        DialogueText.text = "";
        T("뭐가 반짝거리는거 같은데..?", 1);
        yield return new WaitForSeconds(1.5f);
        DialogueText.text = "";
        T("가까이 가서 확인해보자.", 1);
        yield return new WaitForSeconds(2f);
        DownBox();
        PlayerCamera.GetComponent<PlayerCtrl_yejin>().enabled = true;
        PlayerCamera.GetComponent<PlayerCtrl_yejin2>().enabled = false;
        DialogueBox.GetComponent<Animator>().enabled = true;
        
    }

    public void mushroom()
    {
        Fade.GetComponent<Image>().DOFade(1, 3);
        SceneManager.LoadScene("Scene08");
    }


    /* 
       #씬8
    */

    public IEnumerator s8_start()
    {
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Q2("어쩌다 보니 산속 깊숙이 들어와 버렸다", "어떡해야 하지?"));
    }


    public void Q1_lost_1()
    {
        StartCoroutine(Q2("....서비스 제한 지역입니다?", "전화가 안 터지는 거 같다."));
        Canvas_Q1_1.GetComponent<Transform>().DOScale(0, 0.4f).SetEase(Ease.OutQuad);
    }
    public void Q1_lost_2()
    {
        StartCoroutine(Q2("뭔가 같은 곳을 빙빙 도는 느낌이다.", "왔던 길에 표시를 해두자."));
        Canvas_Q1.GetComponent<Transform>().DOScale(0, 0.4f).SetEase(Ease.OutQuad);
        StartCoroutine(lost());
    }
    public IEnumerator lost()
    {
        yield return new WaitForSeconds(4.5f);
        Canvas_Q2.SetActive(true);
        Canvas_Q2.GetComponent<Transform>().DOScale(0.01f, 0.4f).SetEase(Ease.OutQuad);
    }

    public void Q2_check()
    {
        StartCoroutine(Q2("이렇게 표시를 해두자.", "이러면 적어도 헷갈릴 일은 없겠지"));
        Canvas_Q2.GetComponent<Transform>().DOScale(0, 0.4f).SetEase(Ease.OutQuad);
        StartCoroutine(check());

    }
    public IEnumerator check()
    {
        yield return new WaitForSeconds(4.5f);
        Fade.GetComponent<Image>().DOFade(1, 3);
        Audio.clip = sound1;
        Audio.Play();
        yield return new WaitForSeconds(4.5f);
        Audio.Stop();
        Fade.GetComponent<Image>().DOFade(0, 1);
        SceneManager.LoadScene("Scene09");
    }

    /* 
           #씬9
    */
    public IEnumerator s9_start()
    {
        DialogueText.text = "";
        DialogueBox.GetComponent<Transform>().DOLocalMove(new Vector3(45, -185, -640), 0).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(0.1f);
        UpBox();
        yield return new WaitForSeconds(0.5f);
        T("앗 여기는?", 1); //텍스트 나옴
        yield return new WaitForSeconds(1.5f);
        DialogueText.text = "";
        T("아까 내가 표시한 곳이잖아!", 1);
        yield return new WaitForSeconds(1.5f);
        DialogueText.text = "";
        T("아무래도 같은 곳을 빙빙 돌고 있는 거 같다.", 1);
        yield return new WaitForSeconds(1.5f);
        DialogueText.text = "";
        T("해가 거의 다 떨어져서 점점 어두워진다...", 1);
        yield return new WaitForSeconds(1.5f);
        DialogueText.text = "";
        T("어두워져서 표식조차 구분하지 못해", 1);
        yield return new WaitForSeconds(1.5f);
        DialogueText.text = "";
        T("이제 어떡하지..", 1);
        yield return new WaitForSeconds(2f);
        DownBox();
    }

    public void Scene09_Q1_rest_1()
    {
        StartCoroutine(Q("어디서 쉬는게 좋을까?"));
        Canvas_Q1.GetComponent<Transform>().DOScale(0, 0.4f).SetEase(Ease.OutQuad);
        Canvas_Q2.SetActive(true);
        Canvas_Q2.GetComponent<Transform>().DOScale(0.01f, 0.4f).SetEase(Ease.OutQuad).SetDelay(2.5f);
    }
    public void Scene09_Q1_rest_2()
    {
        StartCoroutine(Q2("아직 포기할 수 없어.", "조금만 더 걸으면 길이 나올거야."));
        Canvas_Q1.GetComponent<Transform>().DOScale(0, 0.4f).SetEase(Ease.OutQuad);
        StartCoroutine(Bad(4.5f, "BadEnding3"));
        //배드엔딩
    }

    public void Scene09_Q2_1() //주변이 돌로 쌓인 곳
    {
        StartCoroutine(Bad(0, "BadEnding4"));
        Canvas_Q2.GetComponent<Transform>().DOScale(0, 0.4f).SetEase(Ease.OutQuad);
    }
    public void Scene09_Q2_2() //경사가 심하고 주변에 나무가 있는 곳
    {
        StartCoroutine(Bad(0, "BadEnding5"));
        Canvas_Q2.GetComponent<Transform>().DOScale(0, 0.4f).SetEase(Ease.OutQuad);
    }
    public void Scene09_Q2_3() //큰 바위가 있으면서 땅이 조금 패인 곳
    {
        StartCoroutine(Q2("적당한 곳을 발견했다.", "몸이 조금 으슬으슬하다..."));
        Canvas_Q2.GetComponent<Transform>().DOScale(0, 0.4f).SetEase(Ease.OutQuad);
        Canvas_Q3.SetActive(true);
        Canvas_Q3.GetComponent<Transform>().DOScale(0.01f, 0.4f).SetEase(Ease.OutQuad).SetDelay(3.5f);
    }
    public void Scene09_Q3_hot_1()
    {
        StartCoroutine(Q2("핫팩을 찾았다.", "핫팩을 쥐고 있으니 체온이 조금 올라가는 거 같다."));
        Canvas_Q3.GetComponent<Transform>().DOScale(0, 0.4f).SetEase(Ease.OutQuad);
        StartCoroutine(food());
        Canvas_Q4.SetActive(true);
        Canvas_Q4.GetComponent<Transform>().DOScale(0.01f, 0.4f).SetEase(Ease.OutQuad).SetDelay(7f);
    }
    public void Scene09_Q3_hot_2()
    {
        StartCoroutine(Q2("추워....", "다른건 없나..?"));
        Canvas_Q3.GetComponent<Transform>().DOScale(0, 0.4f).SetEase(Ease.OutQuad);
        StartCoroutine(Bad(4.5f, "BadEnding5"));
    }
    public IEnumerator food()
    {
        yield return new WaitForSeconds(4.5f);
        StartCoroutine(Q("배도 약간 출출한데 먹을게 있나?"));
    }
    public void Scene09_Q4_food_1()
    {
        StartCoroutine(Scene09_food());
        Canvas_Q4.GetComponent<Transform>().DOScale(0, 0.4f).SetEase(Ease.OutQuad);
    }
    public void Scene09_Q4_food_2()
    {
        StartCoroutine(Q("너무 배고파.."));
        Canvas_Q4.GetComponent<Transform>().DOScale(0, 0.4f).SetEase(Ease.OutQuad);
    }
    public IEnumerator Scene09_food()
    {
        DialogueText.text = "";
        DialogueBox.GetComponent<Transform>().DOLocalMove(new Vector3(45, -185, -640), 0).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(0.1f);
        UpBox();
        yield return new WaitForSeconds(0.5f);
        T("가방에서 에너지 바를 찾았다.", 1); //텍스트 나옴
        yield return new WaitForSeconds(1.5f);
        DialogueText.text = "";
        T("에너지 바를 먹었더니 허기가 좀 채워졌다.", 1);
        yield return new WaitForSeconds(1.5f);
        DialogueText.text = "";
        T("하루 종일 걸었더니 피곤하네..", 1);
        yield return new WaitForSeconds(1.5f);
        DialogueText.text = "";
        T("오늘은 푹 쉬고 내일 길을 찾아봐야겠다.", 1);
        yield return new WaitForSeconds(2f);
        DownBox();
        Fade.GetComponent<Image>().DOFade(1, 3);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("HappyEnding");
    }



    public IEnumerator Bad(float time, string sceneName) //원하는 엔딩으로 이동
    {
        yield return new WaitForSeconds(time);
        Fade.GetComponent<Image>().DOFade(1, 3);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName);
    }

    //텍스트 함수 - 고정

    public IEnumerator Q(string txt) //한문장 나올때
    {
        DialogueText.text = "";
        DialogueBox.GetComponent<Transform>().DOLocalMove(new Vector3(45, -185, -640), 0).SetEase(Ease.OutQuad);
        UpBox();
        yield return new WaitForSeconds(0.5f);
        T(txt, 1); //텍스트 나옴
        yield return new WaitForSeconds(2f);
        DownBox();
        //Canvas_Q1.GetComponent<Transform>().DOScale(0.01f, 0.5f).SetEase(Ease.OutQuad);
    }
    public IEnumerator Q2(string txt, string txt2) //두문장
    {
        DialogueText.text = "";
        DialogueBox.GetComponent<Transform>().DOLocalMove(new Vector3(45, -185, -640), 0).SetEase(Ease.OutQuad);
        UpBox();
        yield return new WaitForSeconds(0.5f);
        T(txt, 1); //텍스트 나옴
        yield return new WaitForSeconds(1.5f);
        DialogueText.text = "";
        T(txt2, 1);
        yield return new WaitForSeconds(2f);
        DownBox();
        
        //Canvas_Q1.GetComponent<Transform>().DOScale(0.01f, 0.5f).SetEase(Ease.OutQuad);
    }

    private void T(string dia, float t)
    {
        DialogueText.GetComponent<Text>().DOText(dia, t);
    }


    private void UpBox()
    {
        player_script.di = true;
        DialogueBox.GetComponent<Transform>().DOLocalMove(new Vector3(45, -125, -640), 0.5f).SetEase(Ease.OutQuad);

    }
    public void DownBox()
    {
        player_script.di = false;
        DialogueBox.GetComponent<Transform>().DOLocalMove(new Vector3(45, -300, -640), 0.5f).SetEase(Ease.OutQuad);

    }
}
