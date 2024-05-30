using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject settings;

    public GameObject wheelSpeedSliderObject;
    public Slider _wheelSpeedSlider;
    public GameObject cameraSpeedSliderObject;
    private Slider _cameraSpeedSlider;

    void Start()
    {
        _wheelSpeedSlider = wheelSpeedSliderObject.GetComponent<Slider>();
        _cameraSpeedSlider = cameraSpeedSliderObject.GetComponent<Slider>();
        _wheelSpeedSlider.value = GameManager.instance.mouseWheelSpeed;
        _cameraSpeedSlider.value = GameManager.instance.cameraMoveSpeed;
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
