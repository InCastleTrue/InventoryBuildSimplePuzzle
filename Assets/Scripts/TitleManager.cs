using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    private Button startButton;
    private Button endButton;

    private void Start()
    {
        Button startButton = GameObject.Find("StartButton").GetComponent<Button>();
        Button endButton = GameObject.Find("EndButton").GetComponent<Button>();
        startButton.onClick.AddListener(StartButtonClicked);
        endButton.onClick.AddListener(EndButtonClicked);
    }

    private void StartButtonClicked()
    {
        SceneManager.LoadScene("Maze");
    }

    private void EndButtonClicked()
    {
        Application.Quit();
    }
}
