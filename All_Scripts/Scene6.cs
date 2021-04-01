using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class Scene6 : MonoBehaviour
{
    public GameObject Story1;

    public GameObject chocobar; //초코바
    public GameObject tumbler; //보온병
    public GameObject water; //물
    public GameObject band; //반창고
    //빨간선
    public GameObject thumb1;
    public GameObject thumb2;
    public GameObject thumb3;
    public GameObject thumb4;

    public GameObject obtain;
    public GameObject Door;

    private AudioSource Audio;
    public AudioClip sound_UI_3;
    public AudioClip open_door;

    private int count;

    void Start()
    {
        //StartStory.onClick.Invoke();
        //Story1.GetComponent<Button>().onClick.Invoke();
        thumb1.SetActive(false);
        thumb2.SetActive(false);
        thumb3.SetActive(false);
        thumb4.SetActive(false);
        Door.SetActive(false);

        count = 0;
        obtain.SetActive(false);

        Audio = GetComponent<AudioSource>();
        Audio.clip = sound_UI_3;
        
    }

    public void Story1Active()
    {
        Story1.SetActive(false);
    }

    //아이템 획득
    public void Fun_chocobar()
    {
        chocobar.SetActive(false);
        thumb1.SetActive(true);
        Audio.Play();
        count++;
        Fun_obtain();
    }

    public void Fun_tumbler()
    {
        tumbler.SetActive(false);
        thumb2.SetActive(true);
        Audio.Play();
        count++;
        Fun_obtain();
    }

    public void Fun_water()
    {
        water.SetActive(false);
        thumb3.SetActive(true);
        Audio.Play();
        count++;
        Fun_obtain();
    }

    public void Fun_band()
    {
        band.SetActive(false);
        thumb4.SetActive(true);
        Audio.Play();
        count++;
        Fun_obtain();
    }

    //4개 획득하면 뜨는거
    public void Fun_obtain()
    {
        if(count == 4)
        {
            obtain.SetActive(true);
            //obtain.GetComponent<Image>().DOFade(1, 3).SetLoops(-1, LoopType.Yoyo);
            Door.SetActive(true);
        }

    }
    //문열기
    public void door()
    {
        StartCoroutine(MoveScene06());
    }
    public IEnumerator MoveScene06() //문 열고 나가기
    {
        Audio.clip = open_door;
        Audio.Play();
        yield return new WaitForSeconds(0.5f);
        //Fade.GetComponent<Image>().DOFade(1, 3);
        SceneManager.LoadScene("Scene07");
    }
}
