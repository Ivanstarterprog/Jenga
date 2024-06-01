using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDjengaScript : MonoBehaviour
{
    public Vector3 targetPosition;
    public float smoothTime = 1f;
    public float speed = 4;

    private Vector3 _mousePosition;
    private Vector3 _velocity = Vector3.zero;
    private Vector3 _endPoint;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.WoodColidedWithEndingZone();
    }

    private void OnTriggerExit(Collider other)
    {
        GameManager.instance.WoodLeftEndingZone();
    }

    private Vector3 GetMousePosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void RotateJenga()
    {
        if (Input.GetKey(KeyCode.Q) && !GameManager.instance.isPaused && !GameManager.instance.isGameEnded)
        {
            transform.Rotate(0, -1, 0);
        }
        if(Input.GetKey(KeyCode.E) && !GameManager.instance.isPaused)
        {
            transform.Rotate(0, 1, 0);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.instance.isPaused && !GameManager.instance.isGameEnded)
        {
            _mousePosition = Input.mousePosition - GetMousePosition();
            _endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
            _rigidBody.useGravity = false;
            _rigidBody.freezeRotation = true;
            transform.eulerAngles = new Vector3(0, _rigidBody.transform.eulerAngles.y, 0);
        }
        
    }

    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0) && !GameManager.instance.isPaused && !GameManager.instance.isGameEnded) 
        { 
            _endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition - _mousePosition);
            transform.position = Vector3.SmoothDamp(transform.position, _endPoint, ref _velocity, smoothTime, speed);
            RotateJenga();
        }       
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _rigidBody.useGravity = true;
            _rigidBody.freezeRotation = false;
            _rigidBody.AddForce(_velocity, ForceMode.Impulse);
        }
    }
}
