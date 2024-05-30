using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDjengaScript : MonoBehaviour
{
    
    private Vector3 mousePosition;
    private Vector3 velocity = Vector3.zero;
    private Vector3 endPoint;
    public Vector3 targetPosition;
    public float smoothTime = 1f;
    public float speed = 4;
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
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -1, 0);
        }
        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 1, 0);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition - GetMousePosition();
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
            _rigidBody.useGravity = false;
            _rigidBody.freezeRotation = true;
            transform.eulerAngles = new Vector3(0, _rigidBody.transform.eulerAngles.y, 0);
        }
        
    }

    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0)) 
        { 
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
            transform.position = Vector3.SmoothDamp(transform.position, endPoint, ref velocity, smoothTime, speed);
            RotateJenga();
        }       
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _rigidBody.useGravity = true;
            _rigidBody.freezeRotation = false;
            _rigidBody.AddForce(velocity, ForceMode.Impulse);
        }
    }
}
