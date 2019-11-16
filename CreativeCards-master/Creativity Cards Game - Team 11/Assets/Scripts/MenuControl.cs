using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject pnlCredits;
    public GameObject pnlPaused;
    private bool IsPaused = false;
    private Coroutine fadeCoroutine;

    [SerializeField] Image blackScreen;

    public void StartGame()
    {
        if (fadeCoroutine != null) return;
        fadeCoroutine = StartCoroutine(FadeInScene());
        Debug.Log("Coroutine Started");
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

    IEnumerator FadeInScene()
    {
        float alpha = 0;
        while (blackScreen.color.a < 1)
        {         
            alpha += 0.01f;

            blackScreen.color = new Vector4(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, alpha);
            yield return new WaitForEndOfFrame();
        }

        if (blackScreen.color.a > 1) { SceneManager.LoadScene(1); }

        yield return null;
    }

    void Update()
    {
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
    }
}
