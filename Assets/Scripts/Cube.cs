using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;

    private float _currentSplitChance = 1f;
    private float _splitChanceReductionFactor = 2f;

    public Rigidbody Rigidbody => GetComponent<Rigidbody>();

    private void OnMouseDown()
    {
        if (_currentSplitChance < Random.value)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 curentPosition = gameObject.transform.position;
        Vector3 currentScale = gameObject.transform.localScale;

        List<Cube> newCubes = _spawner.SpawnCubes(currentScale, curentPosition, _currentSplitChance);
        _explosion.Explode(curentPosition, newCubes);

        Destroy(gameObject);
    }

    public void Initialize(Spawner spawnerComponent, Explosion explosionComponent)
    {
        _spawner = spawnerComponent;
        _explosion = explosionComponent;
    }

    public void ReduceChanceToSplit(float splitChance)
    {
        _currentSplitChance = splitChance / _splitChanceReductionFactor; 
    }
}
