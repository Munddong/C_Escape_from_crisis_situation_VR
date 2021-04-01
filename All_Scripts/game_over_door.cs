using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_over_door : MonoBehaviour
{
    public Transform Player;
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
        transform.LookAt(Player);

        if (FACTO_Narration.Vill_Move == true)
        {
            ani.SetTrigger("IdleToWalking");
            if(FACTO_Narration.Vill_Hit == true)
            {
                ani.SetTrigger("Idle0ToSwing");

            }

        }

    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Stop_point_for_Player"))
        {
            Debug.Log(coll.name);
            ani.SetTrigger("WalkingToIdle0");
        }
    }
}
