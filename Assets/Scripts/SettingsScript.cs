using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public Slider _wheelSpeedSlider;
    public Slider _cameraSpeedSlider;

    public static Action<float> onWheelSpeedChange;
    public static Action<float> onCameraSpeedChange;

    
    public void WheelSpeedUpdate()
    {
        onWheelSpeedChange?.Invoke(_wheelSpeedSlider.value);
    }

    public void CameraSpeedUpdate()
    {
        onCameraSpeedChange?.Invoke(_cameraSpeedSlider.value);
    }
}
