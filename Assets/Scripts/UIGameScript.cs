using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameScript : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject currentPlayerTextObject;
    private TextMeshProUGUI _currentPlayerText;

    void Start()
    {
        ContinueGame();
        _currentPlayerText = currentPlayerTextObject.GetComponent<TextMeshProUGUI>();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.ChangePlayer();
            if (GameManager.Instance.currentPlayer == "First")
            {
                _currentPlayerText.text = "Ход первого игрока";
            }
            else
            {
                _currentPlayerText.text = "Ход второго игрока";
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
