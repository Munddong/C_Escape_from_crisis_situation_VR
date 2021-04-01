using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TransformVR : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(VRSetting("OpenVR", false));
    }
    IEnumerator VRSetting(string sdkName, bool flag)
    {
        XRSettings.LoadDeviceByName(sdkName);

        yield return null;

        XRSettings.enabled = flag;

    }
}
