using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //<Button>사용
using DG.Tweening;
using UnityEngine.SceneManagement;


public class Scene3 : MonoBehaviour
{

    public Text DialogueText;
    public GameObject DialogueBox;
    public GameObject Canvas_Q1;
    public GameObject Fade;
    PlayerCtrl_yejin2 player_script;


    void Start()
    {
        player_script = GameObject.Find("Camera_Player's view").GetComponent<PlayerCtrl_yejin2>();
        DialogueText.text = "";
        if (SceneManager.GetActiveScene().name == "Scene03")
        {
            StartCoroutine(startStory());
            Canvas_Q1.GetComponent<Transform>().transform.localScale = new Vector3(0, 0, 0);
        }
        if (SceneManager.GetActiveScene().name == "Scene04")
        {
            StartCoroutine(startStory2());
        }


        
        
    }

    public IEnumerator startStory()
    {
        DialogueBox.GetComponent<Transform>().DOLocalMove(new Vector3(45, -185, -640), 0).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(0.5f);
        UpBox();
        yield return new WaitForSeconds(0.5f);
        T("역시 다이어트엔 등산이지!", 1);
        yield return new WaitForSeconds(1.5f);
        DialogueText.text = "";
        T("...근데 가기 전에 해야 할 게 있었나?", 1);
        yield return new WaitForSeconds(1.5f);
        DownBox();
        Canvas_Q1.GetComponent<Transform>().DOScale(0.01f, 0.5f).SetEase(Ease.OutQuad);
    }

    public IEnumerator startStory2()
    {
        DialogueBox.GetComponent<Transform>().DOLocalMove(new Vector3(45, -185, -640), 0).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(0.5f);
        UpBox();
        yield return new WaitForSeconds(0.5f);
        T("등산 갈 때 뭘 입으면 좋을까?", 1);
        yield return new WaitForSeconds(1.5f);
        DialogueText.text = "";
        T("일단 옷장으로 가보자.", 1);
        yield return new WaitForSeconds(1.5f);
        DownBox();
        Canvas_Q1.GetComponent<Transform>().DOScale(0.01f, 0.5f).SetEase(Ease.OutQuad);
        this.GetComponent<LookWalk>().enabled = true;
    }



    public void Q1_select1()
    {
        StartCoroutine(Bad1());
    }
    public void Q1_select2()
    {
        StartCoroutine(s1());
    }



    public IEnumerator Bad1() //배드엔딩1
    {
        UpBox();
        DialogueText.text = "";
        yield return new WaitForSeconds(0.5f);
        T("뭐 가볍게 산책처럼 가는건데 뭐, 그냥 가자!", 1);
        yield return new WaitForSeconds(1.5f);
        Fade.GetComponent<Image>().DOFade(1, 3);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("BadEnding1");
    }
    public IEnumerator Bad2() //배드엔딩2
    {
        UpBox();
        DialogueText.text = "";
        yield return new WaitForSeconds(0.5f);
        T("뭐 가볍게 산책처럼 가는건데 뭐, 그냥 가자!", 1);
        yield return new WaitForSeconds(1.5f);
        Fade.GetComponent<Image>().DOFade(1, 3);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("BadEnding2");
    }


    public IEnumerator s1()
    {
        UpBox();
        DialogueText.text = "";
        yield return new WaitForSeconds(0.5f);
        T("등산 갈때 입을 옷부터 정하자", 1);
        yield return new WaitForSeconds(1.5f);
        Fade.GetComponent<Image>().DOFade(1, 3);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Scene04");

    }
    //옷장 바라볼시
    public void Cloth() 
    {
        StartCoroutine(clothSelect());
    }
    private IEnumerator clothSelect()
    {
        Fade.GetComponent<Image>().DOFade(1, 1);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Scene05");
    } //옷장


    //텍스트 함수
    private void T(string dia, float t)
    {
        DialogueText.GetComponent<Text>().DOText(dia, t);
    }


    private void UpBox()
    {
        DialogueBox.GetComponent<Transform>().DOLocalMove(new Vector3(45, -125, -640), 0.5f).SetEase(Ease.OutQuad);
        player_script.di = true;
    }
    public void DownBox()
    {
        DialogueBox.GetComponent<Transform>().DOLocalMove(new Vector3(45, -300, -640), 0.5f).SetEase(Ease.OutQuad);
        player_script.di = false;
    }



}
