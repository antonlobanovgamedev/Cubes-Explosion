using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CubesSpawner))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _divisionChance;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private CubesSpawner _spawner;
    
    public float DivisionChance => _divisionChance;
    
    public void Init(Vector3 size, float divisionChance)
    {
        transform.localScale = size;
        _divisionChance = divisionChance;
    }

    private void Awake()
    {
        _spawner = GetComponent<CubesSpawner>();
    }

    private void OnMouseUpAsButton()
    {
        if (WillDivide())
        {
            List<Cube> cubes = _spawner.CreateCubes();
            
            Explode(cubes);
        }
        
        Destroy(gameObject);
    }
    
    private void OnValidate()
    {
        _divisionChance = Mathf.Clamp(_divisionChance, 0, 1);
    }
    
    private void Explode(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            cube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
    
    private bool WillDivide()
    {
        return _divisionChance >= Random.Range(0f, 1f);
    }
}
