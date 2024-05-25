using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDjengaScript : MonoBehaviour
{
    Vector3 mousePosition;
    Vector3 velocity = Vector3.zero;
    Vector3 endPoint;
    public Vector3 targetPosition;
    public float smoothTime = 1f;
    public float speed = 4;
    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private Vector3 GetMousePosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }


    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition - GetMousePosition();
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
            _rigidBody.useGravity = false;
        }
        
    }

    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0)) 
        { 
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
            transform.position = Vector3.SmoothDamp(transform.position, endPoint, ref velocity, smoothTime, speed);
        }
        
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _rigidBody.useGravity = true;
            _rigidBody.AddForce(velocity, ForceMode.Impulse);
        }
    }
}
