using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_over : MonoBehaviour
{
    public Transform Player;
    public Animator ani;

    Factory_Narration_YSC FACTO_Narration;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Vill_Door_Col"))
        {
            Debug.Log(coll.name);
            ani.SetTrigger("WalkingToIdle");
            transform.LookAt(Player);
        }
    }
}
