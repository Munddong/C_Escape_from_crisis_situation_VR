using System.Collections;
using UnityEngine;
using UnityEngine.UI; //<Button>사용
using DG.Tweening;
using UnityEngine.SceneManagement;


public class Scene5 : MonoBehaviour
{

    public Text DialogueText;
    public GameObject DialogueBox;
    public GameObject Canvas_Q1;
    public GameObject Canvas_Q2;
    public GameObject Canvas_Q3;
    public GameObject Canvas_Q4;
    public GameObject Fade;
    //public bool di;
    PlayerCtrl_yejin2 player_script;

    void Start()
    {
        player_script = GameObject.Find("Camera_Player's view").GetComponent<PlayerCtrl_yejin2>();
        DialogueText.text = "";

        if (SceneManager.GetActiveScene().name == "Scene05")
        {
            StartCoroutine(Q("등산 갈 때 입을 옷을 고르자."));
            StartCoroutine(Box_appear(Canvas_Q1));
        }




    }





    //옷
    public void Q1_cloth_1() // 1. 얇고 짧은 반팔과 바지
    {
        StartCoroutine(Q("더울 땐 짧은 옷이 최고지!"));
        StartCoroutine(Box_disappear(Canvas_Q1));
        StartCoroutine(Bad2(2.4f));
    }
    public void Q1_cloth_2() // 2. 체온 유지가 잘 되는 등산복
    {
        StartCoroutine(Q2("산 위는 온도가 낮기 때문에","체온 유지가 적당히 되는 옷을 챙겨야 해!"));
        StartCoroutine(Box_disappear(Canvas_Q1));
        StartCoroutine(Q2_glove());
    }
    public void Q1_next()
    {
        
    }

    //장갑
    public IEnumerator Q2_glove()
    {
        yield return new WaitForSeconds(4.5f);
        StartCoroutine(Q("장갑.. 필요할까?"));
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(Box_appear(Canvas_Q2));
    }
    public void Q2_glove_1() // 1. 필요하다
    {
        StartCoroutine(Q2("손을 보호해야 하니까 끼도록 하자.", "더우면 벗으면 되지 뭐"));
        StartCoroutine(Box_disappear(Canvas_Q2));
        StartCoroutine(Q3_shose());
    }
    public void Q2_glove_2() //2. 필요 없다
    {
        StartCoroutine(Q2("더운데 무슨 장갑이야?", "그냥 가야겠다."));
        StartCoroutine(Box_disappear(Canvas_Q2));
        StartCoroutine(Bad2(2.4f));
    }


    //신발
    public IEnumerator Q3_shose()
    {
        yield return new WaitForSeconds(4.5f);
        StartCoroutine(Q("신발은 뭘 신을까?"));
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(Box_appear(Canvas_Q3));
    }
    public void Q3_shose_1()
    {
        StartCoroutine(Q("비가 올지도 모르니 장화를 신는 게 좋겠지?"));
        StartCoroutine(Box_disappear(Canvas_Q3));
        StartCoroutine(Bad2(2.5f));
    }
    public void Q3_shose_2()
    {
        StartCoroutine(Q("가볍고 바람이 잘 통하는 슬리퍼가 적당할 거야"));
        StartCoroutine(Box_disappear(Canvas_Q3));
        StartCoroutine(Bad2(2.5f));
    }
    public void Q3_shose_3()
    {
        StartCoroutine(Q("발을 보호하고 걷기 편한 등산화를 신자."));
        StartCoroutine(Box_disappear(Canvas_Q3));
        StartCoroutine(Q4_bag());
    }

    //신발
    public IEnumerator Q4_bag()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(Q2("가방을 매고 등산하는게 다이어트에 더 좋다고 했어", "가방은 뭘로 고르지.."));
        yield return new WaitForSeconds(3);
        StartCoroutine(Box_appear(Canvas_Q4));
    }
    public void Q4_bag_1()
    {
        StartCoroutine(Q("역시 등산은 여행가는 느낌으로 가는거지!"));
        StartCoroutine(Box_disappear(Canvas_Q4));
        StartCoroutine(Bad2(2.5f));
    }
    public void Q4_bag_2()
    {
        StartCoroutine(Q2("등산할 때 너무 무거운걸 들면 힘들어.", "이 가방이 제일 적당한거 같아."));
        StartCoroutine(Box_disappear(Canvas_Q4));
        StartCoroutine(MoveScene06(5));
    }
    public void Q4_bag_3()
    {
        StartCoroutine(Q2("파손 걱정 없이 튼튼하고 제일 많이 들어가는 가방이 최고지!", "이 가방이 제일 적당한거 같아."));
        StartCoroutine(Box_disappear(Canvas_Q4));
        StartCoroutine(Bad2(2.5f));
    }



    public IEnumerator Bad2(float time) //배드엔딩2
    {
        yield return new WaitForSeconds(time);
        Fade.GetComponent<Image>().DOFade(1, 3);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("BadEnding2");
    }

    public IEnumerator MoveScene06(float time)
    {
        yield return new WaitForSeconds(time);
        Fade.GetComponent<Image>().DOFade(1, 3);
        SceneManager.LoadScene("Scene06");
    }

    




    //텍스트 함수

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
    
    public IEnumerator Box_appear(GameObject box)
    {
        yield return new WaitForSeconds(0.3f);
        box.SetActive(true);
        box.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
        box.GetComponent<Transform>().DOScale(new Vector3(0.015f, 0.015f, 0.015f), 0.3f).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(0.3f);
        box.GetComponent<Transform>().DOScale(new Vector3(0.007f, 0.007f, 0.007f), 0.3f).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(0.3f);
        box.GetComponent<Transform>().DOScale(new Vector3(0.01f, 0.01f, 0.01f), 0.3f).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(0.3f);
        Debug.Log("Box_appear등장");
    }
    
    public IEnumerator Box_disappear(GameObject box)
    {
        box.GetComponent<Transform>().DOScale(new Vector3(0.013f, 0.013f, 0.013f), 0.3f).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(0.3f);
        box.GetComponent<Transform>().DOScale(new Vector3(0, 0, 0), 0.3f).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(0.3f);
        //box.SetActive(false);
    }
}
