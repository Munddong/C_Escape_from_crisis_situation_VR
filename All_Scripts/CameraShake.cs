using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float m_force = 0f;
    [SerializeField] Vector3 m_offset = Vector3.zero;
    Quaternion m_originRot;
    private AudioSource audioSource; // 카세트
    public AudioClip earthquakeSound; // 지진 소리
    public AudioClip rocksFallSound; // 돌 소리
    public AudioClip separateSound; // 갈라지는 소리
    public AudioClip fallSound; // 떨어지는 소리
    public AudioClip signFallingSound; // 떨어지는 소리
    public GameObject player;
    public GameObject mainCam;
    public GameObject collision1;
    public GameObject collision2;
    public GameObject collision3;
    public GameObject selectCanvas1;
    public GameObject select1_Die_Fade;
    public GameObject selectCanvas2;
    public GameObject select2_Die_Fade;
    public GameObject selectCanvas3;
    public GameObject select3_Die_Fade;
    public GameObject selectCanvas4;
    public GameObject select4_Die_Fade;
    public GameObject ending_Fade;
    public GameObject select1_Die_Image;
    public GameObject select2_Die_Image;
    public GameObject select3_Die_Image;
    public GameObject select4_Die_Image;
    public GameObject earthquakeVideo;
    public GameObject magicRing;
    public bool nice;
    public float speed;
    Crack crackScript_crackImage1;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
        audioSource = GetComponent<AudioSource>();
        m_originRot = transform.rotation;
        nice = false;
        crackScript_crackImage1 = GameObject.Find("CrackCanvas").GetComponent<Crack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Translate(mainCam.transform.TransformDirection(Vector3.forward) * speed * Time.deltaTime);
        }
        StartCoroutine(ShakeCoroutine());
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Shake"))
        {
            StopAllCoroutines();
            nice = true;
            audioSource.clip = earthquakeSound; // 짧은 소리, 노래는 Play()로;
            audioSource.Play(); // 지진 소리
            collision1.SetActive(false);
        }

        else if (other.transform.tag.Equals("Shake2"))
        {
            StopAllCoroutines();
            nice = true;
            audioSource.clip = earthquakeSound; // 짧은 소리, 노래는 Play()로;
            audioSource.Play(); // 지진 소리
            collision2.SetActive(false);
        }

        else if (other.transform.tag.Equals("Shake3"))
        {
            StopAllCoroutines();
            nice = true;
            audioSource.clip = earthquakeSound; // 짧은 소리, 노래는 Play()로;
            audioSource.Play(); // 지진 소리
            collision3.SetActive(false);
        }

        else if (other.transform.tag.Equals("SelectObject1"))
        {
            speed = 0f;
            StartCoroutine(SelectBox1());
        }

        else if (other.transform.tag.Equals("Select1_Die"))
        {
            StartCoroutine(Select1_Die());
        }

        else if (other.transform.tag.Equals("SelectObject2"))
        {
            speed = 0f;
            StartCoroutine(SelectBox2());
        }

        else if (other.transform.tag.Equals("Select2_Die"))
        {
            speed = 0f;
            StartCoroutine(crackScript_crackImage1.CrackingImage());
            StartCoroutine(Select2_Die());
        }

        else if (other.transform.tag.Equals("SelectObject3"))
        {
            speed = 0f;
            StartCoroutine(SelectBox3());
        }

        else if (other.transform.tag.Equals("Select3_Die"))
        {
            speed = 0f;
            StartCoroutine(Select3_Die());
        }

        else if (other.transform.tag.Equals("SelectObject4"))
        {
            speed = 0f;
            StartCoroutine(SelectBox4());
        }

        else if (other.transform.tag.Equals("Select4_Die"))
        {
            speed = 0f;
            StartCoroutine(Select4_Die());
        }

        else if (other.transform.tag.Equals("Ending"))
        {
            speed = 0f;
            StartCoroutine(Ending());
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

    IEnumerator SelectBox1()
    {
        selectCanvas1.SetActive(true);
        yield return null;
    }

    IEnumerator Select1_Die()
    {
        speed = 0f;
        select1_Die_Fade.SetActive(true);
        select1_Die_Image.SetActive(true);
        audioSource.clip = rocksFallSound; // 짧은 소리, 노래는 Play()로;
        audioSource.Play(); // 지진 소리
        yield return new WaitForSeconds(8.0f);
        audioSource.Stop();
        select1_Die_Fade.SetActive(false);
        select1_Die_Image.SetActive(false);
        SceneManager.LoadScene("EarthQuakeReplay");
        yield return null;
    }

    IEnumerator SelectBox2()
    {
        selectCanvas2.SetActive(true);
        yield return null;
    }

    IEnumerator Select2_Die()
    {
        yield return new WaitForSeconds(7.0f);
        select2_Die_Fade.SetActive(true);
        select2_Die_Image.SetActive(true);
        audioSource.clip = separateSound; // 짧은 소리, 노래는 Play()로;
        audioSource.Play(); // 지진 소리
        yield return new WaitForSeconds(8.0f);
        audioSource.Stop();
        select2_Die_Fade.SetActive(false);
        select2_Die_Image.SetActive(false);
        SceneManager.LoadScene("EarthQuakeReplay");
        yield return null;
    }

    IEnumerator SelectBox3()
    {
        selectCanvas3.SetActive(true);
        yield return null;
    }

    IEnumerator Select3_Die()
    {
        yield return new WaitForSeconds(1.0f);
        select3_Die_Fade.SetActive(true);
        select3_Die_Image.SetActive(true);
        audioSource.clip = fallSound; // 짧은 소리, 노래는 Play()로; 무너지는 소리로 바꿀것
        audioSource.Play(); // 지진 소리
        yield return new WaitForSeconds(8.0f);
        audioSource.Stop();
        select3_Die_Fade.SetActive(false);
        select3_Die_Image.SetActive(false);
        SceneManager.LoadScene("EarthQuakeReplay");
        yield return null;
    }

    IEnumerator SelectBox4()
    {
        selectCanvas4.SetActive(true);
        yield return null;
    }

    IEnumerator Select4_Die()
    {
        yield return new WaitForSeconds(1.0f);
        select4_Die_Fade.SetActive(true);
        select4_Die_Image.SetActive(true);
        audioSource.clip = signFallingSound; // 짧은 소리, 노래는 Play()로; 무너지는 소리로 바꿀것
        audioSource.Play(); // 지진 소리
        yield return new WaitForSeconds(8.0f);
        audioSource.Stop();
        select4_Die_Fade.SetActive(false);
        select4_Die_Image.SetActive(false);
        SceneManager.LoadScene("EarthQuakeReplay");
        yield return null;
    }

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(3.0f);
        ending_Fade.SetActive(true);
        earthquakeVideo.SetActive(true);
        magicRing.SetActive(false);
        yield return new WaitForSeconds(112.0f);
        earthquakeVideo.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("EarthQuakeReplay");
        yield return null;
    }
}
