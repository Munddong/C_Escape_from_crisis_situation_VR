using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KidnapSelectButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MainMenuSelect()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ReplaySelect()
    {
        SceneManager.LoadScene("Kidnap");
    }

    public void QuitSelect()
    {
        Application.Quit();
    }
}
