using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Camera_Shake : MonoBehaviour
{
    [SerializeField] float m_force = 0f;
    [SerializeField] Vector3 m_offset = Vector3.zero;
    Quaternion m_originRot;
    private AudioSource audioSource; // 카세트
    public AudioClip earthquakeSound; // 지진 소리
    public AudioClip rocksFallSound; //돌 소리
    public GameObject camera_;
    public GameObject cameraBack;
    public GameObject selectObject;
    public bool nice;
        CameraShake cameraShakeScriptSpeed_Camera_Shake;

    // Start is called before the first frame update
    void Start()
    {
        cameraShakeScriptSpeed_Camera_Shake = GameObject.Find("Player").GetComponent<CameraShake>();
        audioSource = GetComponent<AudioSource>();
        m_originRot = transform.rotation;
        nice = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ShakeCoroutine());
        StartCoroutine(CameraBack());
    }

    IEnumerator ShakeCoroutine()
    {
        Vector3 t_originEuler = transform.eulerAngles;
        while (nice)
        {
            float t_rotX = Random.Range(-m_offset.x, m_offset.x);
            float t_rotY = Random.Range(-m_offset.y, m_offset.y);
            float t_rotZ = Random.Range(-m_offset.z, m_offset.z);

            Vector3 t_randomRot = t_originEuler + new Vector3(t_rotX, t_rotY, t_rotZ);
            Quaternion t_rot = Quaternion.Euler(t_randomRot);

            while (Quaternion.Angle(transform.rotation, t_rot) > 0.1f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, t_rot, m_force * Time.deltaTime);
                yield return null;

                yield return new WaitForSeconds(6.0f);
                StopAllCoroutines();
                StartCoroutine(Reset());
            }
            yield return null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag.Equals("Shake"))
        {
            StopAllCoroutines();
            nice = true;
            audioSource.clip = rocksFallSound; // 짧은 소리, 노래는 Play()로;
            audioSource.Play(); // 지진 소리
            other.gameObject.SetActive(false);
        }
    }

    IEnumerator Reset()
    {
        while (Quaternion.Angle(transform.rotation, m_originRot) > 0f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, m_originRot, m_force * Time.deltaTime);
            nice = false;
            audioSource.Stop();
            yield return null;
        }
    }

    IEnumerator CameraBack()
    {
        yield return new WaitForSeconds(7.0f);
        camera_.SetActive(false);
        cameraBack.SetActive(true);
        selectObject.SetActive(false);

        cameraShakeScriptSpeed_Camera_Shake.speed = 1.5f;
    }
}
