using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RayClick1 : MonoBehaviour
{
    public GameObject mainCam;
    public Image cursorGaugeImage;

    private float gaugeTimer = 0.0f;
    private float gagueTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = mainCam.transform.TransformDirection(Vector3.forward) * 10;

        UnityEngine.Debug.DrawRay(this.transform.position, forward, Color.blue);

        cursorGaugeImage.fillAmount = gaugeTimer;

        float mainCam_x = mainCam.transform.eulerAngles.x;

        if (Physics.Raycast(this.transform.position, forward, out hit))
        {
            gaugeTimer += 1.0f / gagueTime * Time.deltaTime;

            if (gaugeTimer >= 1.0f)
            {
                hit.transform.GetComponent<Button>().onClick.Invoke();
                gaugeTimer = 0.0f;
            }
        }
        else gaugeTimer = 0.0f;
    }
}
