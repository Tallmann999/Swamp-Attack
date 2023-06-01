using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainmenu : MonoBehaviour
{
    public void ReturnMainmenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
