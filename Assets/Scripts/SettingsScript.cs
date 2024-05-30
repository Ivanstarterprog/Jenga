using System;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsScript : MonoBehaviour
{
    public GameObject wheelSpeedSliderObject;
    public GameObject cameraSpeedSliderObject;
    private Slider _wheelSpeedSlider;
    private Slider _cameraSpeedSlider;

    public static Action<float> onWheelSpeedChange;
    public static Action<float> onCameraSpeedChange;


    private void Start()
    {
        _wheelSpeedSlider = wheelSpeedSliderObject.GetComponent<Slider>();
        _cameraSpeedSlider = cameraSpeedSliderObject.GetComponent<Slider>();
    }
    
    public void WheelSpeedUpdate()
    {
        onWheelSpeedChange?.Invoke(_wheelSpeedSlider.value);
    }

    public void CameraSpeedUpdate()
    {
        onCameraSpeedChange?.Invoke(_cameraSpeedSlider.value);
    }
}
