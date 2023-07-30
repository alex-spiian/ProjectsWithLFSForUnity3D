using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ObjectController : MonoBehaviour
{
    private readonly Color[] _colorsOfCylinders = new[] { Color.red, Color.yellow, Color.green, };

    [SerializeField] private GameObject _cylinderPrefab;
    [SerializeField] private int _cylindersCount;
    [SerializeField] private GameObject _spherePrefab;
    private GameObject _sphere;
    private Renderer _sphereRenderer;

    private void Awake()
    {
        InstantiateCylindersOnScene();
        InstantiateSphereOnScene();
    }
    

    private void InstantiateCylindersOnScene()
    {
        for (int i = 0; i < _cylindersCount; i++)
        {
            var newCylinder = Instantiate(_cylinderPrefab);
            newCylinder.transform.position = new Vector3(Random.Range(-45f, 45f), 7.08f, Random.Range(-45f, 45f));
            Recoloring(newCylinder);
            var renderer = newCylinder.GetComponent<Renderer>();
            if (renderer.material.color == Color.red)
            {
                ScoresController.Instance._redCylinderCount++;
            }
            if (renderer.material.color == Color.green)
            {
                ScoresController.Instance._greenCylinderCount++;
            }
            if (renderer.material.color == Color.yellow)
            {
                ScoresController.Instance._yellowCylinderCount++;
            }
        }

    }
    
    private void InstantiateSphereOnScene()
    {
        var newSphere = Instantiate(_spherePrefab);
        newSphere.transform.position = new Vector3(Random.Range(-45f, 45f), 3.5f, Random.Range(-45f, 45f));
        Recoloring(newSphere);
        _sphere = newSphere;

    }

    private void Recoloring(GameObject objectForRecoloring)
    {
        var renderer = objectForRecoloring.GetComponent<Renderer>();
        renderer.material.color = _colorsOfCylinders[Random.Range(0, 3)];
        if (gameObject.CompareTag("Sphere"))
        {
            _sphereRenderer = objectForRecoloring.GetComponent<Renderer>();
        }
    }

}
