using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;        // 따라다닐 타겟 오브젝트의 Transform
    private Transform tr;                // 카메라 자신의 Transform

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        Debug.Log(target.position);

        tr.position = new Vector3(target.position.x + -1f, target.position.y, target.position.z);
        //tr.rotation = new Quaternion(tr.position.x, target.position.y, tr.position.z);

        //tr.LookAt(target);
    }
}

