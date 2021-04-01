using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class NextScene : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject youtube1;
    public GameObject youtube2;
    public bool np;
    public bool cheak;

    void Start()
    {
        np = false;
        cheak = false;
        if (SceneManager.GetActiveScene().name == "Scene01")
        {
            Invoke("MoveScene02", 2.3f);
        }
        if (SceneManager.GetActiveScene().name == "Scene02")
        {
            StartCoroutine(FirstStory());
            GameObject youtube1 = GameObject.Find("Image_youtube");
            GameObject youtube2 = GameObject.Find("Image_youtube2");
        }
    }

    void MoveScene02()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator FirstStory()
    {
        GameObject story1 = GameObject.Find("story1");
        GameObject tuto1 = GameObject.Find("tuto1");
        Text tutoText = GameObject.Find("Text_tuto").GetComponent<Text>();

        GameObject canvas1 = GameObject.Find("Canvas1_weight");
        GameObject canvas2 = GameObject.Find("Canvas2_diet");
        youtube1.SetActive(false);
        youtube2.SetActive(false);




        canvas2.SetActive(false);

        tuto1.transform.localScale = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(1f);
        story1.GetComponent<Button>().onClick.Invoke();
        yield return new WaitForSeconds(3f);
        tuto1.GetComponent<Transform>().DOScale(new Vector3(0.05f, 0.05f, 0.05f), 0.3f).SetEase(Ease.OutQuad);
        tutoText.GetComponent<Text>().DOText("터치하면 앞으로 갈 수 있습니다.", 0.3f);
        yield return new WaitForSeconds(3f);
        tutoText.text = "";
        tutoText.GetComponent<Text>().DOText("버튼을 바라보면 상호작용 할 수 있습니다.", 0.3f);
    }
    
    public void shakeEvent() // 카메라 흔들림
    {
        //GameObject camera = GameObject.Find("Camera_Player's view");
        this.GetComponent<Transform>().DOShakePosition(0.5f, 0.1f, 16, 40).SetEase(Ease.OutQuad);
        Debug.Log("카메라 흔들림");
    }
    public void cheakActive()
    {
        cheak = true;
    }

    public void npActive() //문장이 끝나면 다음 씬으로 넘어가기 위한 조건 달성 -> Story_yejin에서 사용됨, 버튼 Onclick 실행
    {
        np = true;
        cheak = false;
        StartCoroutine(diet());
    }
    public IEnumerator diet()
    {
        GameObject story2 = GameObject.Find("story2");
        story2.GetComponent<Transform>().DOScale(0, 0.5f).SetEase(Ease.OutQuad);
        youtube1.SetActive(true);
        youtube1.GetComponent<Transform>().DOScale(1, 0.5f).SetEase(Ease.OutQuad).From();
        yield return new WaitForSeconds(1f);
        youtube2.SetActive(true);
        
        youtube2.GetComponent<Transform>().DOScale(1, 0.5f).SetEase(Ease.OutQuad).From();
    }

    public IEnumerator MoveScene03()
    {
        Image storyCube3 = GameObject.Find("CursorBG").GetComponent<Image>();
        storyCube3.DOFade(1, 1);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Scene03");
        
    }
}
