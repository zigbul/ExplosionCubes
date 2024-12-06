using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionRadius = 5f;

    public void Explode(Vector3 explosionCenter, List<GameObject> cubes)
    {
        foreach (GameObject cube in cubes)
        {
            Rigidbody rigidbody = cube.GetComponent<Rigidbody>();
            rigidbody.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius);
        }
    }
}
