using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour
{
    public Transform Cop;
    public Transform Player;
    //public Vector3 CopPosition;
    public Animator ani;
    Factory_Narration_YSC FACTO_Narration;
    // Start is called before the first frame update
    void Start()
    {
        FACTO_Narration = GameObject.Find("head").GetComponent<Factory_Narration_YSC>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(FACTO_Narration.Boom_on == false)
        {
            transform.LookAt(Player);
        }
        else if(FACTO_Narration.Boom_on == true)
        {
            transform.LookAt(Cop);
        }

        //CopPosition = new Vector3(Cop.position.x + -1.5f, Cop.position.y, Cop.position.z);
        if (FACTO_Narration.die == true)
        {
            ani.SetTrigger("IdleToDie");
        }
    }
}
