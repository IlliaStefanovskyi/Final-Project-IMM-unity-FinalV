using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public void gameOver()
    {  gameOverPanel.SetActive(true); }

    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }
}
