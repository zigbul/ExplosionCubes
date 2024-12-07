using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionRadius = 5f;
    [SerializeField] private float _upwardsModifier = 3f;

    private float CalculateExplosionForce(float scale)
    {
        Debug.Log($"ExplosionForce: {_explosionForce * (1 / scale)}");
        return _explosionForce * (1 / scale);
    }

    private float CalculateExplosionRadius(float scale)
    {
        Debug.Log($"ExplosionRadius: {_explosionRadius * (1 / scale)}");
        return _explosionRadius * (1 / scale);
    }

    public void ExplodeNewCubes(Vector3 explosionCenter, List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius); ;
        }
    }

    public void ExplodeAllCubesInRadius(Vector3 explosionCenter, Vector3 explosionScale)
    {
        float explosionForce = CalculateExplosionForce(explosionScale.magnitude);
        float explosionRadius = CalculateExplosionRadius(explosionScale.magnitude);

        Collider[] colliders = Physics.OverlapSphere(explosionCenter, _explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(explosionForce, explosionCenter, explosionRadius, _upwardsModifier);
            }
        }
    }
}
