using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFunctionality : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("ShootingReflectingLevel");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void StartLevelButton()
    {
        SceneManager.LoadScene("ShootingReflectingLevel");
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("ShootingReflectingLevel");
    }
}
