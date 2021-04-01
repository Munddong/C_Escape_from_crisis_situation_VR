using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AgainNarration : MonoBehaviour
{
    private AudioSource audioSource; // 카세트
    public AudioClip keyboard; // 키보드 소리
    public Text narrationText; // 나래이션 텍스트
    public GameObject narrationBox; // 나래이션 박스
    public GameObject speechBubble; // 말풍선

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartDialogue());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartDialogue()
    {
        narrationText.text = "";
        speechBubble.SetActive(true);
        narrationBox.SetActive(true);
        narrationText.DOText("으... 뭐지?? 분명히 나는 자고 있었는데..?", 3.0f);
        audioSource.clip = keyboard; // 짧은 소리, 노래는 Play()로;
        audioSource.Play(); // 채팅 타자소리
        yield return new WaitForSeconds(3.0f);
        audioSource.Stop();
        speechBubble.SetActive(false);
        narrationBox.SetActive(false);
    }    
}

