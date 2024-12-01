using System.Collections.Generic;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private float _sizeMultiplier;
    [SerializeField] private float _divisionChanceMultiplier;

    [SerializeField] private int _minNewCubesCount;
    [SerializeField] private int _maxNewCubesCount;

    private void OnValidate()
    {
        if (_minNewCubesCount < 0)
            _minNewCubesCount = 0;
        
        if(_maxNewCubesCount < _minNewCubesCount)
            _maxNewCubesCount = _minNewCubesCount;
    }
    
    public List<Cube> CreateCubes(Cube parentCube)
    {
        int count = GetNewCubesCount(_minNewCubesCount, _maxNewCubesCount);
        
        List<Cube> cubes = new List<Cube>(count);

        for (int i = 0; i < count; i++)
        {
            Cube cube = Instantiate(_cubePrefab, parentCube.transform.position, parentCube.transform.rotation);
            cube.Init(GetNewSize(parentCube, _sizeMultiplier), GetNewDivisionChance(parentCube, _divisionChanceMultiplier), this);
            
            cubes.Add(cube);
        }
        
        return cubes;
    }
    
    private int GetNewCubesCount(int minCount, int maxCount)
    {
        return Random.Range(minCount, maxCount);
    }
    
    private float GetNewDivisionChance(Cube parentCube, float multiplier)
    {
        return parentCube.DivisionChance * multiplier;
    }
    
    private Vector3 GetNewSize(Cube parentCube, float multiplier)
    {
        Vector3 currentSize = parentCube.transform.localScale;
        
        return currentSize * multiplier;
    }
}
