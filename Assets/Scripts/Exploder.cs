using UnityEngine;
using System.Collections.Generic;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    
    public void Explode(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            if(cube.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
