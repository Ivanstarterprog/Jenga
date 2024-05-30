using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject settings;

    void Start()
    {
        CloseSettings();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseSettings();
        }
    }

    public void OpenSettings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }

    public void CloseSettings()
    {
        menu.SetActive(true);
        settings.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
