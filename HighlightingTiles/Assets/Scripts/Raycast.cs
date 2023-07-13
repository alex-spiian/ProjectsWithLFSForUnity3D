using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Raycast : MonoBehaviour
{

    [SerializeField]
    private Collider _collider;

    [SerializeField]
    private Renderer _renderer;
    
    [SerializeField]
    private Color _activeColor;

    private Color _standardColor;
    
    void Start()
    {
        _standardColor = _renderer.material.color;
    }

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (_collider.Raycast(ray, out var hitInfo, 50f))
        {
            _renderer.material.color = _activeColor;
        }
        else
        {
            _renderer.material.color = _standardColor;
        }

    }
}
