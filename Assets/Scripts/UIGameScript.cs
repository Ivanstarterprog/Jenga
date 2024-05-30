using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameScript : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject settings;
    [SerializeField] GameObject roundEnd;
    [SerializeField] GameObject playerUI;

    [SerializeField] GameObject currentPlayerTextObject;
    private TextMeshProUGUI _currentPlayerText;
    [SerializeField] GameObject firstPlayerScoreTextObject;
    private TextMeshProUGUI _firstPlayerScoreText;
    [SerializeField] GameObject secondPlayerScoreTextObject;
    private TextMeshProUGUI _secondPlayerScoreText;

    void Start()
    {
        ContinueGame();
        roundEnd.SetActive(false);
        _currentPlayerText = currentPlayerTextObject.GetComponent<TextMeshProUGUI>();
        _firstPlayerScoreText = firstPlayerScoreTextObject.GetComponent<TextMeshProUGUI>();
        _secondPlayerScoreText = secondPlayerScoreTextObject.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        GameManager.onRoundEnding += EndRoundUI;
    }

    private void OnDisable()
    {
        GameManager.onRoundEnding -= EndRoundUI;
    }

    private void EndRoundUI(string winner)
    {
        menu.SetActive(false);
        settings.SetActive(false);
        playerUI.SetActive(false);
        roundEnd.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.instance.isPaused)
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
            GameManager.instance.ChangePlayer();
            if (GameManager.instance.currentPlayer == "First")
            {
                _currentPlayerText.text = "��� ������� ������";
            }
            else
            {
                _currentPlayerText.text = "��� ������� ������";
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
        GameManager.instance.PauseUnpressed();
       // ReloadScoreUI();
        ClosePauseMenu();
    }

    public void PauseGame()
    {
        OpenPauseMenu();
        GameManager.instance.PausePressed();
    }

    public void GoToMainMenu()
    {
        GameManager.instance.PlayersWinsReset();
        SceneManager.LoadScene("Menu");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReloadScoreUI()
    {
        _firstPlayerScoreText.text = $"������ �����: {GameManager.instance.firstPlayerWins}";
        _secondPlayerScoreText.text = $"������ �����: {GameManager.instance.secondPlayerWins}";
    }
}
