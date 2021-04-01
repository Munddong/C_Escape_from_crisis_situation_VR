using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class BadEnding : MonoBehaviour
{
    public Text txt1;
    public Text txt2;
    public GameObject button1;
    public Text txt_restart;

    void Start()
    {
        button1.SetActive(false);
        if (SceneManager.GetActiveScene().name == "BadEnding1")
        {
            StartCoroutine(BadEnding1());
            //button1.SetActive(false);
        }
        if (SceneManager.GetActiveScene().name == "BadEnding2")
        {
            StartCoroutine(BadEnding2());
            //button1.SetActive(false);

        }
        if (SceneManager.GetActiveScene().name == "BadEnding3")
        {
            StartCoroutine(BadEnding3());
        }
        if (SceneManager.GetActiveScene().name == "BadEnding4")
        {
            StartCoroutine(BadEnding4());
        }
        if (SceneManager.GetActiveScene().name == "BadEnding5")
        {
            StartCoroutine(BadEnding5());
        }
        if (SceneManager.GetActiveScene().name == "HappyEnding")
        {
            StartCoroutine(HappyEnding());
        }
    }

    public IEnumerator BadEnding1()
    {
        txt1.text = "";
        yield return new WaitForSeconds(0.5f);
        T("등산이 이렇게 힘든거였나..?", 1.3f);
        yield return new WaitForSeconds(2f);
        txt1.text = "";
        T("하아.. 올라갈수록 점점 숨이 가빠진다.", 1.8f);
        yield return new WaitForSeconds(2.5f);
        txt1.text = "";
        txt1.GetComponent<Text>().DOText("포기하고 싶어....", 2).SetEase(Ease.OutCirc);
        yield return new WaitForSeconds(1.5f);
        txt1.GetComponent<Text>().DOFade(0, 3);
        yield return new WaitForSeconds(1);
        txt2.GetComponent<Text>().DOFade(1, 3);
        
        yield return new WaitForSeconds(2f);
        button1.SetActive(true);
        txt_restart.GetComponent<Text>().DOFade(1, 0.8f).SetLoops(-1, LoopType.Yoyo).SetDelay(0.1f);
    }

    public IEnumerator BadEnding2()
    {
        txt1.text = "";
        yield return new WaitForSeconds(0.5f);
        T("등산을 하니 슬슬 땀이나기 시작한다.", 1.3f);
        yield return new WaitForSeconds(2f);
        txt1.text = "";
        T("위이잉..위이잉 위이이잉", 1.2f);
        yield return new WaitForSeconds(1.9f);
        txt1.text = "";
        T("위이이이이이잉위이이이잉위이이이잉위이이이잉위이이이잉\n" +
            "위이이이잉위이이잉위이이이잉위이이이이이잉\n위이이이잉위이이잉", 1.2f);
        yield return new WaitForSeconds(1.4f);
        txt1.text = "";
        T("무슨소리지?", 0.6f);
        yield return new WaitForSeconds(1f);
        txt1.text = "";
        this.GetComponent<Transform>().DOPunchPosition(new Vector3(30, 20, 10), 0.7f, 25);
        txt1.GetComponent<Text>().DOText("으아아아아아아아아아아악", 2).SetEase(Ease.OutCirc);
        txt1.GetComponent<Text>().DOColor(new Color(183, 10, 10), 1);
        txt1.GetComponent<Text>().DOColor(Color.red, 2);
        yield return new WaitForSeconds(1.5f);
        txt1.GetComponent<Text>().DOFade(0, 3);
        yield return new WaitForSeconds(1);
        txt2.GetComponent<Text>().DOFade(1, 3);

        yield return new WaitForSeconds(2f);
        button1.SetActive(true);
        txt_restart.GetComponent<Text>().DOFade(1, 0.8f).SetLoops(-1, LoopType.Yoyo).SetDelay(0.1f);
    }

    public IEnumerator BadEnding3()
    {
        txt1.text = "";
        yield return new WaitForSeconds(0.5f);
        T("조금만 더 가면 길이 나올거야.", 1.3f);
        yield return new WaitForSeconds(2f);
        txt1.text = "";
        T("조금... 조금만 더 가면....", 2f);
        yield return new WaitForSeconds(2.5f);
        txt1.GetComponent<Text>().DOFade(0, 3);
        yield return new WaitForSeconds(1);
        txt2.GetComponent<Text>().DOFade(1, 3);

        yield return new WaitForSeconds(2f);
        button1.SetActive(true);
        txt_restart.GetComponent<Text>().DOFade(1, 0.8f).SetLoops(-1, LoopType.Yoyo).SetDelay(0.1f);
    }
    public IEnumerator BadEnding4()
    {
        txt1.text = "";
        yield return new WaitForSeconds(0.5f);
        T("주변이 돌무더기라 바람은 막아주겠지", 1.3f);
        yield return new WaitForSeconds(2f);
        txt1.text = "";
        T("오늘은 여기서 자볼까?", 1.5f);
        yield return new WaitForSeconds(2.2f);
        txt1.text = "";
        T("........Zzz", 2f);
        yield return new WaitForSeconds(2.1f);
        txt1.text = "";
        T("쿠르르르르쾅!!", 1f);
        yield return new WaitForSeconds(1.5f);
        txt1.text = "";
        T("뭐야?", 0.5f);
        yield return new WaitForSeconds(1.5f);
        txt1.text = "";
        T("으악! 돌이 내려오고 있어!!", 2f);
        yield return new WaitForSeconds(2f);
        txt1.GetComponent<Text>().DOFade(0, 3);
        yield return new WaitForSeconds(1);
        txt2.GetComponent<Text>().DOFade(1, 3);

        yield return new WaitForSeconds(2f);
        button1.SetActive(true);
        txt_restart.GetComponent<Text>().DOFade(1, 0.8f).SetLoops(-1, LoopType.Yoyo).SetDelay(0.1f);
    }

    public IEnumerator BadEnding5()
    {
        txt1.text = "";
        yield return new WaitForSeconds(0.5f);
        T("오늘은 어쩔수 없이..여기서 그냥 자볼까..", 2.3f);
        yield return new WaitForSeconds(2.7f);
        txt1.text = "";
        T("........Zzz", 2f);
        yield return new WaitForSeconds(2.2f);
        txt1.text = "";
        T("휘이이이이이잉", 0.7f);
        yield return new WaitForSeconds(1.2f);
        txt1.text = "";
        T("으..오늘 바람이 왜이렇게 부는거야..?", 2f);
        yield return new WaitForSeconds(2.5f);
        txt1.text = "";
        T("너무 추워...", 1.5f);
        yield return new WaitForSeconds(1.5f);
        txt1.GetComponent<Text>().DOFade(0, 3);
        yield return new WaitForSeconds(1);
        txt2.GetComponent<Text>().DOFade(1, 3);

        yield return new WaitForSeconds(2f);
        button1.SetActive(true);
        txt_restart.GetComponent<Text>().DOFade(1, 0.8f).SetLoops(-1, LoopType.Yoyo).SetDelay(0.1f);
    }
    public IEnumerator HappyEnding()
    {
        txt1.text = "";
        yield return new WaitForSeconds(0.5f);
        T("........Zzz", 2f);
        yield return new WaitForSeconds(2.2f);
        txt1.text = "";
        T("저기요!", 0.7f);
        yield return new WaitForSeconds(1.2f);
        txt1.text = "";
        T("으응..?", 1.5f);
        yield return new WaitForSeconds(2f);
        txt1.text = "";
        T("구급대원입니다. 정신이 좀 드시나요?", 1.5f);
        yield return new WaitForSeconds(1.7f);
        txt1.GetComponent<Text>().DOFade(0, 3);
        yield return new WaitForSeconds(3);
        txt1.text = "";
        txt1.GetComponent<Text>().DOFade(1, 1);
        yield return new WaitForSeconds(1);

        T("정신을 차려보니 병원이었다.", 1.5f);
        yield return new WaitForSeconds(1.5f);
        txt1.text = "";
        T("의사 말로는 조금만 늦었으면 큰일 났을 뻔했다고 한다.", 2.5f);
        yield return new WaitForSeconds(3f);
        txt1.text = "";
        T("휴... 다행이야", 1f);
        yield return new WaitForSeconds(1.5f);
        txt1.text = "";
        T("앞으로는 다이어트 같은거 하지 말아야지.", 2f);
        yield return new WaitForSeconds(2.3f);
        txt1.GetComponent<Text>().DOFade(0, 3);
        yield return new WaitForSeconds(1);
        txt2.GetComponent<Text>().DOFade(1, 3);

        yield return new WaitForSeconds(2f);
        button1.SetActive(true);
        txt_restart.GetComponent<Text>().DOFade(1, 0.8f).SetLoops(-1, LoopType.Yoyo).SetDelay(0.1f);
    }

    public void MoveScene03()
    {
        SceneManager.LoadScene("Scene03");
    }
    public void MoveScene05()
    {
        SceneManager.LoadScene("Scene05");
    }

    public void MoveScene09()
    {
        SceneManager.LoadScene("Scene09");
    }
    public void MoveMain() //재시작
    {
        SceneManager.LoadScene("DistressReplay");
    }

    private void T(string text, float t)
    {
        txt1.GetComponent<Text>().DOText(text, t);
    }
}
