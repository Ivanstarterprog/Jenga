using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushJenga : MonoBehaviour
{
    public float pushForce = 5;
    private Ray _ray;
    private RaycastHit _hit;

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(_ray.origin, _ray.GetPoint(100));
            if (Physics.Raycast(_ray, out _hit, 100))
            {
                GameObject hitObject = _hit.transform.gameObject;
                if (hitObject.tag == "JengaWood")
                {
                    Rigidbody hitObjectRigidBody = hitObject.GetComponent<Rigidbody>();
                    Vector3 dir = _ray.origin - hitObjectRigidBody.transform.position;
                    dir.Normalize();
                    hitObjectRigidBody.AddForce(-1 * dir * pushForce, ForceMode.VelocityChange);
                }

            }
        }
    }
}
