using UnityEngine;
using System.Collections;
public class Boom : MonoBehaviour
{
    public GameObject boom;
    public GameObject Door;
    public GameObject Explo;
    public Rigidbody Door_rd;
    public float radius = 50.0f;
    public float power = 400.0f;

    // Start is called before the first frame update
    void Start()
    {
        Door_rd = Door.GetComponent<Rigidbody>();
        Vector3 explosionPos = boom.transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Explo.SetActive(true);
                Door_rd.constraints = RigidbodyConstraints.None;
                rb.AddExplosionForce(power, explosionPos, radius, 0.0f);
               
            }
        }
        Destroy(Explo, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}