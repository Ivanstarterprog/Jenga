using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [Range(1f, 2f)] public float mouseWheelSpeed = 1.5f;
    [Range(1f, 3f)] public float cameraMoveSpeed = 2f;

    public static Action<string> onRoundEnding;

    public string currentPlayer;
    public bool isPaused;
    public int firstPlayerWins;
    public int secondPlayerWins;
    public int woodsTouchingEndingZone;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeManager();
            return;
        }
        Destroy(this.gameObject);

    }

    private void InitializeManager()
    {
        currentPlayer = "First";
        PlayersWinsReset();
        PauseUnpressed();
    }

    public void PlayersWinsReset()
    {
        firstPlayerWins = 0;
        secondPlayerWins = 0;
    }

    public void RoundEnd()
    {
        if (currentPlayer == "First")
        {
            PlayerTwoWin();
        }
        else
        {
            PlayerOneWin();
        }
        onRoundEnding?.Invoke(currentPlayer);
    }

    public void PlayerOneWin()
    {
        ++firstPlayerWins;
    }

    public void PlayerTwoWin()
    {
        ++secondPlayerWins;
    }

    public void WoodColidedWithEndingZone()
    {
        ++woodsTouchingEndingZone;
    }

    public void WoodLeftEndingZone()
    {
        --woodsTouchingEndingZone;
        if (woodsTouchingEndingZone <= 2)
        {
            RoundEnd();
        }
    }

    public void ChangeMouseWheelSpeed(float newSpeed)
    {
        mouseWheelSpeed = newSpeed;
    }

    public void PauseUnpressed()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
    }

    public void PausePressed()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
    }

    public void ChangePlayer()
    {
        if (currentPlayer == "First")
        {
            currentPlayer = "Second";
        }
        else
        {
            currentPlayer = "First";
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu" && isPaused)
        {
            PauseUnpressed();
        }
    }
}
