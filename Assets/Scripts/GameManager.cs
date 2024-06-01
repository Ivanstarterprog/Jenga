using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public float mouseWheelSpeed;
    public float cameraMoveSpeed;

    public static Action<string> onRoundEnding;


    public string currentPlayer;
    public bool isPaused;
    public bool isGameEnded;
    public int firstPlayerWins;
    public int secondPlayerWins;
    public int woodsTouchingEndingZone;
    public int woodsTouchingTable;

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
        mouseWheelSpeed = 1f;
        cameraMoveSpeed = 1f;
        SettingsScript.onWheelSpeedChange += MouseWheelSpeedUpdate;
        SettingsScript.onCameraSpeedChange += CameraSpeedUpdate;
        PlayersWinsReset();
        ColidersAndTriggerReset();
        PauseUnpressed();
    }

    public void CameraSpeedUpdate(float newCameraSpeed)
    {
        cameraMoveSpeed = newCameraSpeed;
    }

    public void MouseWheelSpeedUpdate(float newMouseWheelSpeed)
    {
        mouseWheelSpeed = newMouseWheelSpeed;
    }

    public void PlayersWinsReset()
    {
        firstPlayerWins = 0;
        secondPlayerWins = 0;
    }

    public void ColidersAndTriggerReset()
    {
        woodsTouchingEndingZone = 0;
        woodsTouchingTable = 0;

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
        if (woodsTouchingEndingZone <= 1 && !isGameEnded)
        {
            RoundEnd();
            isGameEnded = true;
        }
    }

    public void WoodColidedWithTable()
    {
        ++woodsTouchingTable;
        if (woodsTouchingTable > 4 && !isGameEnded)
        {
            RoundEnd();
            isGameEnded = true;
        }
    }

    public void WoodLeftTable()
    {
        --woodsTouchingTable;
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

    public void ResetLevel()
    {
        isGameEnded = false;
        ColidersAndTriggerReset();
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu" && isPaused)
        {
            PauseUnpressed();
        }
    }
}
