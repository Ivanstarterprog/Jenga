using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    public float cameraMoveSpeed = 2;
    public GameObject pointToMoveAround;
    private Vector3 _pointToMoveAroundPosition;

    void Start()
    {

        _pointToMoveAroundPosition = pointToMoveAround.transform.position;
        transform.LookAt(_pointToMoveAroundPosition);
    }

    void FixedUpdate()
    {
        gameObject.transform.RotateAround(_pointToMoveAroundPosition, Vector3.up, cameraMoveSpeed);
    }
}
