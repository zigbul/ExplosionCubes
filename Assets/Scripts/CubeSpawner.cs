using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private int _minCubes = 2;
    [SerializeField] private int _maxCubes = 6;
    [SerializeField] private float _spawnRadius = 2.0f;
    [SerializeField] private float _scaleReductionFactor = 0.5f;
    [SerializeField] private float _splitChanceReductionFactor = 2.0f;
    [SerializeField] private float _explosionForce = 500f;
    [SerializeField] private float _explosionRadius = 5f;

    private float _splitChance = 1f;

    private void OnMouseDown()
    {
        SpawnNewCubes();
        Destroy(gameObject);
    }
    
    private void SpawnNewCubes()
    {
        if (_splitChance < Random.value)
        {
            return;
        }

        _splitChance /= _splitChanceReductionFactor;

        int cubeCount = Random.Range(_minCubes, _maxCubes + 1);

        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 randomPosition = transform.position + (Vector3)Random.insideUnitCircle * _spawnRadius;
            GameObject newCube = Instantiate(_cube, randomPosition, Quaternion.identity);
            newCube.transform.localScale = transform.localScale * _scaleReductionFactor;

            Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            Renderer cubeRenderer = newCube.GetComponent<Renderer>();

            if (cubeRenderer != null)
            {
                cubeRenderer.material.color = randomColor;
            }

            Rigidbody rb = newCube.GetComponent<Rigidbody>();
            rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
