using System;
using UnityEngine;

public class ObjectsInteractionTask2 : MonoBehaviour
{
    [SerializeField] private GameObject _lamp;
    [SerializeField] private GameObject _lampRoot;

    private void Awake()
    {
        Instantiate(_lamp, _lampRoot.transform);

    }
}