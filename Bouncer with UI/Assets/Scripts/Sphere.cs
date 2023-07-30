using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sphere : MonoBehaviour
{
    private Renderer _renderer;
    private readonly Color[] _colorsOfSphere = new[] { Color.red, Color.yellow, Color.green, };
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Renderer>().material.color = _renderer.material.color;
            _renderer.material.color = _colorsOfSphere[Random.Range(0, 3)];
            transform.position = new Vector3(Random.Range(-45f, 45f), 3.5f, Random.Range(-45f, 45f));
        }
    }
    
}
