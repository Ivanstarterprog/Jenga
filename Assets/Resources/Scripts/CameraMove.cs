using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject pointToMoveAround;
    private Vector3 _pointToMoveAroundPosition;
    private Camera _mainCamera;
    private float _startZoom;
    private Vector3 _firstPlayerCameraStartPosition;
    private Vector3 _secondPlayerCameraStartPosition;

    private void Start()
    {
        _mainCamera = GetComponent<Camera>();
        _startZoom = _mainCamera.fieldOfView;
        _pointToMoveAroundPosition = pointToMoveAround.transform.position;
        _firstPlayerCameraStartPosition = gameObject.transform.position;
        _secondPlayerCameraStartPosition = new Vector3 (6.466586e-07f, 4.86f, 7.539999f);
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
                if (GameManager.instance.currentPlayer != "First")
                {
                    gameObject.transform.position = _firstPlayerCameraStartPosition;
                }
                else
                {
                    gameObject.transform.position = _secondPlayerCameraStartPosition;
                }
                _mainCamera.fieldOfView = _startZoom;
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
