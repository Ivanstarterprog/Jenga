using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField] GameObject winnerPlayerTextObject;
    private TextMeshProUGUI _winnerPlayerText;

    public Slider _wheelSpeedSlider;
    public Slider _cameraSpeedSlider;

    void Start()
    {
        roundEnd.SetActive(false);
        _currentPlayerText = currentPlayerTextObject.GetComponent<TextMeshProUGUI>();
        _firstPlayerScoreText = firstPlayerScoreTextObject.GetComponent<TextMeshProUGUI>();
        _secondPlayerScoreText = secondPlayerScoreTextObject.GetComponent<TextMeshProUGUI>();
        _winnerPlayerText = winnerPlayerTextObject.GetComponent<TextMeshProUGUI>();
        _wheelSpeedSlider.value = GameManager.instance.mouseWheelSpeed;
        _cameraSpeedSlider.value = GameManager.instance.cameraMoveSpeed;
        ContinueGame();
    }

    private void OnEnable()
    {
        GameManager.onRoundEnding += EndRoundUI;
        GameManager.onGameReload += RestartLevel;
    }

    private void OnDisable()
    {
        GameManager.onRoundEnding -= EndRoundUI;
        GameManager.onGameReload -= RestartLevel;
    }

    private void EndRoundUI(string winner)
    {
        menu.SetActive(false);
        settings.SetActive(false);
        playerUI.SetActive(false);
        roundEnd.SetActive(true);
        _winnerPlayerText.text = winner;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.isGameEnded)
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
        GameManager.instance.PauseUnpressed();
        GameManager.instance.isGameEnded = false;
        ReloadScoreUI();
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
        GameManager.instance.ColidersAndTriggerReset();
        SceneManager.LoadScene("Menu");
    }
    public void RestartLevel()
    {
        GameManager.instance.isGameEnded = false;
        GameManager.instance.currentPlayer = "First";
        GameManager.instance.ColidersAndTriggerReset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReloadScoreUI()
    {
        _firstPlayerScoreText.text = $"Первый игрок: {GameManager.instance.firstPlayerWins}";
        _secondPlayerScoreText.text = $"Второй игрок: {GameManager.instance.secondPlayerWins}";
    }
}
