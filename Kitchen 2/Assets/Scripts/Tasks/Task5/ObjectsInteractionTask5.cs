using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectsInteractionTask5 : MonoBehaviour
{
    [SerializeField] private Shelf _shelf1;
    [SerializeField] private Shelf _shelf2;
  
    private void Awake()
    {
       _shelf1.ItemSpawned += OnItemSpawned;
       _shelf2.ItemSpawned += OnItemSpawned;
    }
    
    private void OnItemSpawned()
    {
        if (_shelf1.ItemsCount > 3)
        {
            _shelf1.Fall();
        }
        
        if (_shelf2.ItemsCount > 3)
        {
            _shelf2.Fall();
        }
    }

    private void OnDestroy()
    {
        _shelf1.ItemSpawned -= OnItemSpawned;
        _shelf2.ItemSpawned -= OnItemSpawned;
    }
}