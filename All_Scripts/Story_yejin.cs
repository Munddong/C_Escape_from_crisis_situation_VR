using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Text자료형 사용
using UnityEngine.SceneManagement; //씬
using DG.Tweening; //dotween사용

public class Story_yejin : MonoBehaviour //스토리 매니저
{
    Queue<string> sentences;
    public Text storyTxt; //텍스트 박스
    public Animator animator; //애니메이터
    private AudioSource Audio;
    public AudioClip sound_txt;
    public AudioClip sound_txt2;
    public GameObject NextButton;
    public bool Di; //대화 UI-> 올라왔을때 true, 내려갔을때 false
    //public bool StartD1 = false; //대화문 나오면 true 됨

    private int count = 0;
    NextScene next;
    Scene3 scene3;

    void Start()
    {
        NextButton.SetActive(false);
        sentences = new Queue<string>(); //문장이 들어갈 큐 : 입력된 순서대로 나오는 자료구조
        Audio = GetComponent<AudioSource>();
        next = FindObjectOfType<NextScene>();

    }

    public void StartStory(StoryData_yejin Data)
    {
        animator.SetBool("IsOpen", true);
        Debug.Log("스토리를 사작합니다."); //테스트용
        sentences.Clear();
        Di = true; //UI 올라왔을 때 - 커서 안차게 하기 위함

        foreach(var sentence in Data.sentences)
        {
            Audio.clip = sound_txt;
            Audio.Play();
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndStory();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        storyTxt.text = "";
        
        foreach (char letter in sentence.ToCharArray())
        {
            
            //Debug.Log("Count : " + i);
            storyTxt.text += letter;
            yield return null;
        }
    }

    void EndStory()
    {
        Audio.clip = sound_txt2;
        Audio.Play();
        animator.SetBool("IsOpen", false);

        NextButton.SetActive(false);
        Di = false;


        if (SceneManager.GetActiveScene().name == "Scene02")
        {
            if (next.cheak == true)
            {
                //GameObject canvas2 = GameObject.Find("Canvas2");
                next.canvas2.SetActive(true);
                next.canvas2.GetComponent<Transform>().DOScale(1, 0.5f).SetEase(Ease.OutQuad).From();
                next.canvas1.GetComponent<Transform>().DOScale(0, 0.5f).SetEase(Ease.OutQuad);
            }

            if (next.np == true) //Scene03으로 넘어감
            {
                StartCoroutine(next.MoveScene03());
                Debug.Log("끝");
            }

        }



    }

}
