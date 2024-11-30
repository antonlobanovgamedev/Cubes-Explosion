using System.Collections.Generic;
using UnityEngine;

public class CubesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float _newCubesSizeMultiplier;
    [SerializeField] private float _divisionMultiplier;

    [SerializeField] private int _minNewCubesCount;
    [SerializeField] private int _maxNewCubesCount;

    private void OnValidate()
    {
        if (_minNewCubesCount < 0)
            _minNewCubesCount = 0;
        
        if(_maxNewCubesCount < _minNewCubesCount)
            _maxNewCubesCount = _minNewCubesCount;
    }
    
    public List<Cube> CreateCubes()
    {
        int count = GetNewCubesCount(_minNewCubesCount, _maxNewCubesCount);
        
        List<Cube> cubes = new List<Cube>(count);

        for (int i = 0; i < count; i++)
        {
            Cube cube = Instantiate(_cubePrefab).GetComponent<Cube>();
            cube.Init(GetNewCubeSize(_newCubesSizeMultiplier), GetNewCubeDivisionChance(_divisionMultiplier));
            
            cubes.Add(cube);
        }
        
        return cubes;
    }
    
    private int GetNewCubesCount(int minCount, int maxCount)
    {
        return Random.Range(minCount, maxCount);
    }
    
    private float GetNewCubeDivisionChance(float multiplier)
    {
        return GetComponent<Cube>().DivisionChance * multiplier;
    }
    
    private Vector3 GetNewCubeSize(float multiplier)
    {
        Vector3 currentSize = transform.localScale;
        Vector3 size = currentSize * multiplier;
        
        return size;
    }
}
