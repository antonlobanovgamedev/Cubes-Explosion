using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class RandomColorSetter : MonoBehaviour
{
    private Material _material;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Start()
    {
        _material.color = Random.ColorHSV();
    }
}
