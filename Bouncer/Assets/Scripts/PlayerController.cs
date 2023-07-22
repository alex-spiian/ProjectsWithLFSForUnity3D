using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Color = System.Drawing.Color;

public class PlayerController : MonoBehaviour
{
    private Vector3 _destination;
    private Rigidbody _rigidbody;
    private const float _forceMagnitude = 0.5f;

    [SerializeField] private GameObject _floor;
    [SerializeField] private GameObject _playerPrefab;
    private GameObject _currentPlayer;
    private UnityEngine.Color _previousColor;
    private bool _isItFirstInstantiatingOfPlayer;
    private void Awake()
    {
        InstantiatePlayer();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetDestination();
            
            MovePlayer();
        }

        if (_currentPlayer.transform.position.y < -3)
        {
            _previousColor = _currentPlayer.GetComponent<Renderer>().material.color;
            BackToStartPosition();
        }
    }

    private void GetDestination()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            _destination = hitInfo.point;
        }
        
    }

    private void MovePlayer()
    {
        _rigidbody = _currentPlayer.GetComponent<Rigidbody>(); 
        if (_rigidbody != null)
        {
            _rigidbody.AddForce(_destination * _forceMagnitude, ForceMode.VelocityChange);
        }
        
    }

    private void BackToStartPosition()
    {
        Destroy(_currentPlayer);
        InstantiatePlayer();
    }

    private void InstantiatePlayer()
    {
        _currentPlayer = Instantiate(_playerPrefab, Vector3.zero, Quaternion.identity);
        
        if (_isItFirstInstantiatingOfPlayer)
        {
            _currentPlayer.GetComponent<Renderer>().material.color = _previousColor;
        }

        _isItFirstInstantiatingOfPlayer = true;
    }
}
