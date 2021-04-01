using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
{
    public GameObject Mask;
    public GameObject Light;
    Vector3 target = new Vector3(0, 5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Light.SetActive(true);
        transform.position = Vector3.MoveTowards(transform.position, target, 0.3f);
        if(transform.position==target)
            Destroy(Mask);
    }
}
