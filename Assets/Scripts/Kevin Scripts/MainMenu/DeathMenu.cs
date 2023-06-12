using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    public void TryAgain()
    {
        SceneManager.LoadScene("TutorialLevel Kevin");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
