using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class ScreenButton : MonoBehaviour
{
    public GameObject produce;
    public GameObject Fade;

    void Start()
    {
        gameObject.GetComponent<ScreenUp>().enabled = false;
        gameObject.GetComponent<ScreenDown>().enabled = false;
        //StartCoroutine(fadeStart1());
        Invoke("fadestart", 1.2f);

    }
    public void fadestart()
    {
        //yield return new WaitForSeconds(1f);
        Fade.SetActive(false);

    }

    //선택창
    public void StartSelcet()
    {
        gameObject.GetComponent<ScreenUp>().enabled = true;
        gameObject.GetComponent<ScreenDown>().enabled = false;
    }

    public void ProduceSelect()
    {
        produce.SetActive(true);
    }

    public void ProduceBackSelect()
    {
        produce.SetActive(false);
    }

    public void BackSelect()
    {
        gameObject.GetComponent<ScreenUp>().enabled = false;
        gameObject.GetComponent<ScreenDown>().enabled = true;
    }

    public void QuitSelect()
    {
        Application.Quit();
    }

    public void EarthQuake()
    {
        SceneManager.LoadScene("EarthQuake");
    }

    public void Fire()
    {
        SceneManager.LoadScene("Fire");
    }

    public void Distress()
    {
        SceneManager.LoadScene("Scene00");
    }

    public void Kidnap()
    {
        SceneManager.LoadScene("Kidnap");
    }
}
