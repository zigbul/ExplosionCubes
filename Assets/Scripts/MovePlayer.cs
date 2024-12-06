using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;

    private string _horizontalAxis = "Horizontal";
    private string _verticalAxis = "Vertical";

    private void Update()
    {
        float deltaX = Input.GetAxis(_horizontalAxis) * _speed * Time.deltaTime;
        float deltaZ = Input.GetAxis(_verticalAxis) * _speed * Time.deltaTime;

        transform.Translate(deltaX, 0, deltaZ);
    }
}
