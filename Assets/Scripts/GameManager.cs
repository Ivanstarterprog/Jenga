using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Range(1f, 2f)] public float mouseWheelSpeed = 1.5f;
    [Range(1f, 3f)] public float cameraMoveSpeed = 2f;

    public string currentPlayer = "First";

    private void Awake()
    { 
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void ChangeMouseWheelSpeed(float newSpeed)
    {
        mouseWheelSpeed = newSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
