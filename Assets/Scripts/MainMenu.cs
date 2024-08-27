using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Canvas mainMenuBtns;
    public Canvas nameX;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowNameXin()
    {
        mainMenuBtns.GetComponent<Canvas>().enabled = false;
        nameX.GetComponent<Canvas>().enabled = true;
    }

    public void BackNameXin()
    {
        mainMenuBtns.GetComponent<Canvas>().enabled = true;
        nameX.GetComponent<Canvas>().enabled = false;
    }
}
