using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timeRemaning;
    public GameManager gamemanager;

    // Update is called once per frame
    void Update()
    {
        if (timeRemaning > 0) 
        {
            timeRemaning -= Time.deltaTime;
        }
        else if (timeRemaning < 10) 
        {
            timeRemaning = 0;
            gamemanager.gameOver();
            Time.timeScale = 0;
            timerText.color = Color.red; 
        }
        int minutes = Mathf. FloorToInt(timeRemaning / 60); 
        int seconds = Mathf. FloorToInt(timeRemaning % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
