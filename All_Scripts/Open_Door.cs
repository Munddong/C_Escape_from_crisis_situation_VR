using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Door : MonoBehaviour
{
    public float doorOpenAngle;
    public float smoot = 2f;

    void Start() { }

    void Update()
    {
        Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoot * Time.deltaTime);
    }

}