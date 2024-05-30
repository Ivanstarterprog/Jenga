using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Range(1f, 2f)] public float mouseWheelSpeed = 1.5f;
    [Range(1f, 3f)] public float cameraMoveSpeed = 2f;

    public string currentPlayer;
    public bool isPaused;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeManager();
            return;
        }
        Destroy(this.gameObject);

    }

    private void InitializeManager()
    {
        currentPlayer = "First";
        PauseUnpressed();
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
