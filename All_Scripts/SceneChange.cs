using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public float timer;
    public GameObject fade;
    public GameObject fade1;
    public GameObject fade2;
    public GameObject fade3;
    public GameObject fade4;
    public GameObject fade5;
    public GameObject fade6;
    public GameObject fade7;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadDevice("cardboard", true));
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.0f)
        {
            fade.SetActive(true);
        }

        if (timer >= 5.0f)
        {
            fade.SetActive(false);
            fade1.SetActive(true);
        }

        if (timer >= 10.0f)
        {
            fade1.SetActive(false);
            fade2.SetActive(true);
        }

        if (timer >= 15.0f)
        {
            fade2.SetActive(false);
            fade3.SetActive(true);
        }

        if (timer >= 20.0f)
        {
            fade3.SetActive(false);
            fade4.SetActive(true);
        }

        if (timer >= 25.0f)
        {
            fade4.SetActive(false);
            fade5.SetActive(true);
        }

        if (timer >= 30.0f)
        {
            fade5.SetActive(false);
            fade6.SetActive(true);
        }

        if (timer >= 35.0f)
        {
            fade6.SetActive(false);
            fade7.SetActive(true);
        }

        if (timer >= 40.0f)
        {
            fade7.SetActive(false);
            SceneManager.LoadScene("Scene02");
        }
    }

    IEnumerator LoadDevice(string newDevice, bool enable)
    {
        UnityEngine.XR.XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        UnityEngine.XR.XRSettings.enabled = enable;
    }
}
