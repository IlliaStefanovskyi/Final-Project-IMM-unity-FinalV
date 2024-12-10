using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public void gameOver()
    {  gameOverPanel.SetActive(true); }

    public void Easy()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Easy");
    }

    public void Medium()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Medium");
    }

    public void Hard()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Hard");
    }

    public void Victory()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Victory");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
