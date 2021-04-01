using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Transform2D : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(VRSetting("OpenVR", true));
    }
    IEnumerator VRSetting(string sdkName, bool flag)
    {
        XRSettings.LoadDeviceByName(sdkName);

        yield return null;

        XRSettings.enabled = flag;

    }
}
