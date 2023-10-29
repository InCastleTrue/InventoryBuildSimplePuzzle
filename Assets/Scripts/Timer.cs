using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 60.0f;
    public Text timerText;
    public GameObject gameOverPanel;
    public GameObject timerObject;

    public float currentTime = 0;



    private void Start()
    {
        gameOverPanel.SetActive(false);
        currentTime = totalTime;
        InvokeRepeating("UpdateTimer", 0f, 1f); // 1초마다 업데이트
    }
    private void UpdateTimer()
    {
        currentTime -= 1;

        timerText.text = Mathf.Floor(currentTime).ToString();

        if (currentTime <= 0)
        {
            gameOverPanel.SetActive(true);
            CancelInvoke("UpdateTimer");
            timerObject.SetActive(false);
        }
    }
}
