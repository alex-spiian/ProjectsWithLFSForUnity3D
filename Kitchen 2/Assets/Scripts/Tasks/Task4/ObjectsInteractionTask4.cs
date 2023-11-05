using System;
using UnityEngine;

public class ObjectsInteractionTask4 : MonoBehaviour
{
    [SerializeField] private GameObject _waffleRoot;

    [SerializeField] private Waffle _waffle;

    [SerializeField] private Toaster _toaster;

    private void Awake()
    {
        _toaster.TimerIsUp += CreateWaffle;
    }

    public void CreateWaffle()
    {
        Instantiate(_waffle, _waffleRoot.transform);
    }
    
    private void OnDestroy()
    {
        _toaster.TimerIsUp -= CreateWaffle;
    }
}