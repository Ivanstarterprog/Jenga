using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject pointToMoveAround;
    private Vector3 _pointToMoveAroundPosition;
    private Camera _mainCamera;
    private Vector3 _startPosition;

    private void Start()
    {
        _mainCamera = GetComponent<Camera>();
        _pointToMoveAroundPosition = pointToMoveAround.transform.position;
        _startPosition = gameObject.transform.position;
    }

    private void Update()
    {
        transform.LookAt(_pointToMoveAroundPosition);
        if (!GameManager.instance.isPaused)
        {
            if (!Input.GetMouseButton(0) )
            {
                ZoomAtJenga();
            }
            LookAroundJenga();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.transform.position = _startPosition;
            }
        }
        
        
    }

    private void ZoomAtJenga()
    {
        float scrollWheelAxis = Input.GetAxis("Mouse ScrollWheel");

        if (scrollWheelAxis > 0.00f && _mainCamera.fieldOfView >= 25)
        {
            _mainCamera.fieldOfView -= GameManager.instance.mouseWheelSpeed;
        }
        if (scrollWheelAxis < 0.00f && _mainCamera.fieldOfView <= 60)
        {
            _mainCamera.fieldOfView += GameManager.instance.mouseWheelSpeed;
        }
    }

    private void LookAroundJenga()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.RotateAround(_pointToMoveAroundPosition, Vector3.up, GameManager.instance.cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.RotateAround(_pointToMoveAroundPosition, Vector3.down, GameManager.instance.cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.W) && _mainCamera.transform.position.y <= 6)
        {
            gameObject.transform.RotateAround(_pointToMoveAroundPosition, transform.right, GameManager.instance.cameraMoveSpeed);
        }
        if (Input.GetKey(KeyCode.S) && _mainCamera.transform.position.y >= 2)
        {
            gameObject.transform.RotateAround(_pointToMoveAroundPosition, -transform.right, GameManager.instance.cameraMoveSpeed);
        }
    }
}
