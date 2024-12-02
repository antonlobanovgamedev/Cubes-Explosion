using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Exploder))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _divisionChance;
    [SerializeField] private CubesSpawner _spawner;
    
    private Exploder _exploder;
    
    public float DivisionChance => _divisionChance;

    private void OnValidate()
    {
        _divisionChance = Mathf.Clamp(_divisionChance, 0, 1);
    }
    
    private void Awake()
    {
        _exploder = GetComponent<Exploder>();
    }

    private void OnMouseUpAsButton()
    {
        if (CanDivide())
            _spawner.CreateCubes(this);
        else
            _exploder.Explode();
        
        Destroy(gameObject);
    }
    
    public void Init(Vector3 size, float divisionChance, CubesSpawner spawner)
    {
        transform.localScale = size;
        _divisionChance = divisionChance;
        _spawner = spawner;
        
        _exploder.ChangeExplosionPowerWithMultiplier();
    }
    
    private bool CanDivide()
    {
        return _divisionChance >= Random.Range(0f, 1f);
    }
}
