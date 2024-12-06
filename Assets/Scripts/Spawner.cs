using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private int _minCubes = 2;
    [SerializeField] private int _maxCubes = 6;
    [SerializeField] private float _spawnRadius = 2.0f;
    [SerializeField] private float _scaleReductionFactor = 0.5f;
    
    public List<GameObject> SpawnCubes(Vector3 scale, Vector3 position, float splitChance)
    {
        List<GameObject> cubes = new();

        int cubesCount = Random.Range(_minCubes, _maxCubes + 1);
        
        for (int i = 0; i < cubesCount; i++)
        {
            Vector3 newPosition = position + Random.insideUnitSphere * _spawnRadius;
            GameObject newCube = Instantiate(_cube, newPosition, Quaternion.identity);

            SetRandomColor(ref newCube);
            newCube.transform.localScale = scale * _scaleReductionFactor;
            newCube.GetComponent<CubeLogic>().ReduceChanceToSplit(splitChance);

            Debug.Log($"Split chance: {splitChance * 100}%");
            cubes.Add(newCube);
        }

        return cubes;
    }

    private void SetRandomColor(ref GameObject cube)
    {
        Renderer cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material.color = new Color(
            Random.value,
            Random.value,
            Random.value
        );
    }
}
