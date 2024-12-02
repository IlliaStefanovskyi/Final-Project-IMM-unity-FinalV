using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("Easy");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Easy()
    {
        SceneManager.LoadScene("Easy");
    }

    public void Medium()
    {
        SceneManager.LoadScene("Medium");
    }

    public void Hard()
    {
        SceneManager.LoadScene("Hard");
    }

}
