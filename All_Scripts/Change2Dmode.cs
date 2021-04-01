using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change2Dmode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadDevice("none", true));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadDevice(string newDevice, bool enable)
    {
        UnityEngine.XR.XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        UnityEngine.XR.XRSettings.enabled = enable;
    }
}