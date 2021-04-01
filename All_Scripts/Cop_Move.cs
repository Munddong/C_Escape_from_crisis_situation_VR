using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cop_Move : MonoBehaviour
{
    public bool ShootV = false;
    public Transform Villain;
    public Vector3 VillainPosition;
    public Transform Player;
    public Vector3 PlayerPosition;
    public Vector3 now_posi;
    public Animator ani;
    public bool stoping = false;

    Factory_Narration_YSC FACTO_Narration;

    void Start()
    {
        ani = GetComponent<Animator>();
        FACTO_Narration = GameObject.Find("head").GetComponent<Factory_Narration_YSC>();
        now_posi = VillainPosition;
    }

    // Update is called once per frame
    void Update()
    {
        VillainPosition = new Vector3(Villain.position.x + -0.5f, Villain.position.y, Villain.position.z);
        PlayerPosition = new Vector3(Player.position.x + -0.5f, Player.position.y, Player.position.z);

        transform.LookAt(now_posi);

        if (FACTO_Narration.Shoot_V_and_P == true)
        {
            ani.SetTrigger("IdleGoShoot");
            ani.SetTrigger("ShootGoIdle0");
            if (ani.GetCurrentAnimatorStateInfo(0).IsName("idle 0"))
            {
                now_posi = PlayerPosition;
                ani.SetTrigger("Idle0GoShoot0");
                ani.SetTrigger("Shoot0GoIdle1");
            }
        }
        else if(FACTO_Narration.Shoot_V == true)
        {
            ani.SetTrigger("IdleGoShoot");
            ani.SetTrigger("ShootGoIdle0");
            ani.SetTrigger("Idle0GoShoot0");
            ani.SetTrigger("Shoot0GoIdle1");
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Stop_point"))
        {
            Debug.Log(coll.name);
            ani.SetTrigger("RunGoIdle");
        }
    }

}
