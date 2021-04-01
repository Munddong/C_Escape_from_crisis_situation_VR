using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float LimitTime = 60;
    public int min;
    public int sec;
    public Text text_Timer;

    public Image clackImage;
    private float GaugeTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        clackImage.fillAmount = GaugeTimer;
        GaugeTimer += Time.deltaTime * 1/60f;

        if (GaugeTimer >= 1f)
        {
            GaugeTimer = 0.0f;
        }
            

        if (LimitTime <= 0f)
        {
            LimitTime = 0f;
            text_Timer.text = Mathf.Round(min) + "분 " + Mathf.Round(sec) + "초";
        }
        else if (LimitTime >= 0f)
        {
            LimitTime -= Time.deltaTime;
            min = (int)LimitTime / 60;
            sec = (int)LimitTime % 60;

            text_Timer.text = Mathf.Round(min) + "분 " + Mathf.Round(sec) + "초";
        }

        
    }
}