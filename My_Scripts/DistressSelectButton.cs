using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthQuakeSelectButton : MonoBehaviour
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
        SceneManager.LoadScene("Again");
    }

    public void QuitSelect()
    {
        Application.Quit();
    }
}
