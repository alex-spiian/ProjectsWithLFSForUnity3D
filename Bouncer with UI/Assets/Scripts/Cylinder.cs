using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    private Renderer _renderer;
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.GetComponent<Renderer>().material.color == _renderer.material.color)
        {
            if (_renderer.material.color == Color.red)
            {
                ScoresController.Instance._redCylinderCount--;
            }
            if (_renderer.material.color == Color.green)
            {
                ScoresController.Instance._greenCylinderCount--;
            }
            if (_renderer.material.color == Color.yellow)
            {
                ScoresController.Instance._yellowCylinderCount--;
            }
            Destroy(gameObject);
        }
    }
}
