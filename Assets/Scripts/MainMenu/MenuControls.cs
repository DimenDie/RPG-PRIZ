using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public GameObject menuSlider;
    public GameObject anywhereButton;
    public GameObject anywhereText;
    public AudioSource menuMusic;
    public GameObject loadingGame;

    public void SlideMenu()
    {
        menuSlider.GetComponent<Animation>().Play("MenuSlide");
        anywhereButton.SetActive(false);
        anywhereText.SetActive(false);
    }

    public void NewGame()
    {
        menuMusic.Stop();
        loadingGame.SetActive(true);
        SceneManager.LoadScene(1);
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
