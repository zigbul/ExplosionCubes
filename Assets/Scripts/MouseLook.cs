using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private enum _rotationAxes
    {
        MouseX = 0,
        MouseY = 1,
    }

    [SerializeField] private _rotationAxes _axe = _rotationAxes.MouseX;
    [SerializeField] private float _sensitivity = 9.0f;

    void Update()
    {
        float deltaY = _sensitivity * Input.GetAxis("Mouse X");
        float deltaX = _sensitivity * Input.GetAxis("Mouse Y");

        if (_axe == _rotationAxes.MouseX)
        {
            transform.Rotate(0, deltaY, 0);
        }
        else if (_axe == _rotationAxes.MouseY)
        {
            transform.Rotate(-deltaX, 0, 0);
        }
    }
}
