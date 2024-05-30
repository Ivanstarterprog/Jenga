using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameScript : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject playerUI;

    void Start()
    {
        ContinueGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Instance.isPaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void OpenSettings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void OpenPauseMenu()
    {
        menu.SetActive(true);
        settings.SetActive(false);
        playerUI.SetActive(false);
    }

    public void ClosePauseMenu()
    {
        menu.SetActive(false);
        settings.SetActive(false);
        playerUI.SetActive(true);
    }

    public void ContinueGame()
    {
        GameManager.Instance.PauseUnpressed();
        ClosePauseMenu();
    }

    public void PauseGame()
    {
        OpenPauseMenu();
        GameManager.Instance.PausePressed();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
