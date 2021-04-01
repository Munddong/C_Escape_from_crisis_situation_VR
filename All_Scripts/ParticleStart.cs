using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStart : MonoBehaviour
{
    public ParticleSystem particle;
    public GameObject rocksFallParticle;
    public GameObject particlePlane;

    // Start is called before the first frame update
    void Start()
    {
        particlePlane.SetActive(true);
        particle.Play();
        StartCoroutine(particlePlaneDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator particlePlaneDestroy()
    {
        yield return new WaitForSeconds(7.0f);
        rocksFallParticle.SetActive(false);
        particlePlane.SetActive(false);
    }
}
