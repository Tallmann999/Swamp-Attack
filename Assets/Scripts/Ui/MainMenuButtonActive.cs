using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonActive : MonoBehaviour
{
   public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnAutorButton()
    {
        SceneManager.LoadScene(2);
    }

    public void OnExitButton()
    {
        Application.Quit();
    }
}
