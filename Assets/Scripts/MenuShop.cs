using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShop : MonoBehaviour
{
    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

}
