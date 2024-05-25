using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float wheelSpeed = 100;
    public float cameraMoveSpeed = 2;
    public GameObject pointToMoveAround;
    private Vector3 _pointToMoveAroundPosition;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = GetComponent<Camera>();
        _pointToMoveAroundPosition = pointToMoveAround.transform.position;
    }

    private void Update()
    {
        transform.LookAt(pointToMoveAround.transform);
        
        ZoomAtJenga();
        LookAroundJenga();
        
    }

    private void ZoomAtJenga()
    {
        float scrollWheelAxis = Input.GetAxis("Mouse ScrollWheel");

        if (scrollWheelAxis != 0.0f && (_mainCamera.fieldOfView < 60 || _mainCamera.fieldOfView > 35))
        {
            _mainCamera.fieldOfView += scrollWheelAxis * -10;
        }
    }

    private void LookAroundJenga()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.RotateAround(_pointToMoveAroundPosition, Vector3.up, cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.RotateAround(_pointToMoveAroundPosition, Vector3.down, cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.W) && _mainCamera.transform.rotation.x <= 20)
        {
            gameObject.transform.RotateAround(_pointToMoveAroundPosition, transform.right, cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.S) && _mainCamera.transform.rotation.x >= 0)
        {
            gameObject.transform.RotateAround(_pointToMoveAroundPosition, -transform.right, cameraMoveSpeed);
        }
    }
}
