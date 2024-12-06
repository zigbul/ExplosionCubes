using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLogic : MonoBehaviour
{
    private Spawner _spawner;
    private Explosion _explosion;
    private float _currentSplitChance = 1f;
    private float _splitChanceReductionFactor = 2f;

    private void Start()
    {
        _spawner = FindObjectOfType<Spawner>();
        _explosion = FindObjectOfType<Explosion>();
    }

    private void OnMouseDown()
    {
        if (_currentSplitChance < Random.value)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 curentPosition = gameObject.transform.position;
        Vector3 currentScale = gameObject.transform.localScale;

        List<GameObject> newCubes = _spawner.SpawnCubes(currentScale, curentPosition, _currentSplitChance);
        _explosion.Explode(curentPosition, newCubes);

        Destroy(gameObject);
    }

    public void ReduceChanceToSplit(float splitChance)
    {
        _currentSplitChance = splitChance / _splitChanceReductionFactor; 
    }
}
