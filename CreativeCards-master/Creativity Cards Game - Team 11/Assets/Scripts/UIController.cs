using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject pnlCredits;
    public GameObject pnlPaused;
    public GameObject pnlDead;
    public Text FinalScore;
    public Text TimerText;
    public Text ScoreText;
    public Scene CurrentScene;
    public float Score;
    private float TimeLasted;
    private bool IsPaused = false;
    public bool IsDead = false;

    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Quit()
    {
        Debug.Log("Quit Successful");
        Application.Quit();
    }

    public void ShowCredits()
    {
        pnlCredits.SetActive(true);
    }

    public void HideCredits()
    {
        pnlCredits.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
    }

    public void Main_Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void UnPause()
    {
        pnlPaused.SetActive(false);
        Time.timeScale = 1;
        IsPaused = false;
    }

    void Update()
    {

        TimeLasted += Time.deltaTime;
        TimerText.text = "Time: " + TimeLasted.ToString("00");

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (IsPaused == true)
            {
                pnlPaused.SetActive(false);
                Time.timeScale = 1;
            }
            if (IsPaused == false)
            {
                pnlPaused.SetActive(true);
                Time.timeScale = 0;
            }

            IsPaused = !IsPaused;
        }

        if (IsDead == true)
        {
            pnlDead.SetActive(true);
            FinalScore.text = "Final Score: " + (Score + TimeLasted).ToString("00");
            //Score.ToString() + TimeLasted.ToString("00");
        }
    }
}
