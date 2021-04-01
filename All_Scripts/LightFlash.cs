using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlash : MonoBehaviour
{
    public GameObject lightObject;
    public GameObject light1;
    public GameObject light2;
    private float r;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(lightFlash());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator lightFlash()
    {
        while (true)
        {
            r = Random.Range(0.1f, 0.5f);
            yield return new WaitForSeconds(r);
            lightObject.SetActive(false);
            light1.SetActive(false);
            light2.SetActive(false);
            yield return new WaitForSeconds(r);
            lightObject.SetActive(true);
            light1.SetActive(true);
            light2.SetActive(true);
        }
    }
}
