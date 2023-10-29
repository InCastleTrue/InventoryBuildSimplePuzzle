using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearFailManager : MonoBehaviour
{
    public Button restartMazeButton;
    public Button homeTitleButton;
    public Button restartLevelButton;
    public Button exitGameButton;

    public Text infoText;

    private float displayDuration = 5.0f;
    private float fadeDuration = 5.0f;

    private void Start()
    {
        restartMazeButton.onClick.AddListener(RestartButtonClicked1);
        homeTitleButton.onClick.AddListener(TitleButtonClicked1);

        restartLevelButton.onClick.AddListener(RestartButtonClicked2);
        exitGameButton.onClick.AddListener(TitleButtonClicked2);

        StartCoroutine(DisplayAndFadeText());
    }

    private void RestartButtonClicked1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void TitleButtonClicked1()
    {
        SceneManager.LoadScene("Title");
    }

    private void RestartButtonClicked2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void TitleButtonClicked2()
    {
        SceneManager.LoadScene("Title");
    }

    private IEnumerator DisplayAndFadeText()
    {

        infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(displayDuration);

        float startTime = Time.time;
        while (Time.time - startTime < fadeDuration)
        {
            float alpha = 1.0f - (Time.time - startTime) / fadeDuration;
            infoText.color = new Color(infoText.color.r, infoText.color.g, infoText.color.b, alpha);
            yield return null;
        }

        infoText.gameObject.SetActive(false);
    }
}
