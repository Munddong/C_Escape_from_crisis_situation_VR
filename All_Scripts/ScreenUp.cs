using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenUp : MonoBehaviour
{
    Vector3 target = new Vector3(0, 25f, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 0.3f);
    }
}
