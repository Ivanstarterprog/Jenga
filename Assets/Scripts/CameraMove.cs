using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject pointToMoveAround;

    private void Start()
    {
        transform.LookAt(pointToMoveAround.transform);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.RotateAround(pointToMoveAround.transform.position, Vector3.up, 5);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.RotateAround(pointToMoveAround.transform.position, Vector3.down, 5);
        }
    }
}
