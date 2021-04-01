using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crack : MonoBehaviour
{
    public Image crackImage1;
    public Image crackImage2;
    public Image crackImage3;
    private float gaugeTimer = 0.0f;
    private float gazeTime = 4.0f;
    private bool time = false;

    // Use this for initialization
    void Start()
    {
        crackImage1.fillAmount = gaugeTimer;
        crackImage2.fillAmount = gaugeTimer;
        crackImage3.fillAmount = gaugeTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (time == true)
        {
            crackImage1.fillAmount += 1.0f / gazeTime * Time.deltaTime;
            crackImage2.fillAmount += 1.0f / 2.0f * Time.deltaTime;
            crackImage3.fillAmount += 1.0f / 3.0f * Time.deltaTime;
        }
    }

    public IEnumerator CrackingImage()
    {
        StartCoroutine(Cracking());
        yield return null;
    }

    public IEnumerator Cracking()
    {
        yield return new WaitForSeconds(2.0f);
        time = true;
    }
}
