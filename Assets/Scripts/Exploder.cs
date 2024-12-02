using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _forceMultiplier;
    [SerializeField] private float _radiusMultiplier;

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider collider in colliders)
        {
            if(collider.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    public void ChangeExplosionPowerWithMultiplier()
    {
        _explosionForce *= _forceMultiplier;
        _explosionRadius *= _radiusMultiplier;
    }
}
