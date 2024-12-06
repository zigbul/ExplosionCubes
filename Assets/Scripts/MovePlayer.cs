using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;

    private void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float deltaZ = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        transform.Translate(deltaX, 0, deltaZ);
    }
}
