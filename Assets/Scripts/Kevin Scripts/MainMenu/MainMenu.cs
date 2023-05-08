using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("InsertLevelNameHere");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
