using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private RotationAxes _axe = RotationAxes.MouseX;
    [SerializeField] private float _sensitivity = 9.0f;

    private string _axisX = "Mouse X";
    private string _axisY = "Mouse Y";
    private float minimumAngle = -45.0f;
    private float maximumAngle = 45.0f;
    private float verticalRotation = 0;

    private enum RotationAxes
    {
        MouseX = 0,
        MouseY = 1,
    }

    private void Update()
    {
        float deltaY = _sensitivity * Input.GetAxis(_axisX);
        float deltaX = _sensitivity * Input.GetAxis(_axisY);

        if (_axe == RotationAxes.MouseX)
        {
            transform.Rotate(0, deltaY, 0);
        }
        else if (_axe == RotationAxes.MouseY)
        {
            verticalRotation -= deltaX;
            verticalRotation = Mathf.Clamp(verticalRotation, minimumAngle, maximumAngle);

            float horizontalRotation = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(verticalRotation, horizontalRotation, 0);
        }
    }
}
