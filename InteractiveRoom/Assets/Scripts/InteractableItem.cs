using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class InteractableItem : MonoBehaviour
{
    [SerializeField]
    private int _highlightIntensity = 4;   
    [SerializeField]
    private Transform _handTransform;
    [SerializeField]
    private GameObject _hand;
    private Outline _outline;
    
    private FixedJoint _fixedJoint;
    private Collider _collider;
    private Rigidbody _rigidbody;
    private Rigidbody _rigidbodyOfCurrentItemInHand;
    private GameObject _currentItemInHand;
    private readonly float _itemVelocity = 10f;
    
    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _fixedJoint = _hand.GetComponent<FixedJoint>();
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (_collider.Raycast(ray, out var hitInfo, 50))
        {
            SetFocus();
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUpItem();
            }
            
        }
        else
        {
            RemoveFocus();
        }

        if (Input.GetMouseButtonDown(0))
        {
            ThrowItemForward();
        }
    }


    private void SetFocus()
    {
        _outline.OutlineWidth = _highlightIntensity;
    }
    
    private void RemoveFocus()
    {
        _outline.OutlineWidth = 0;
    }

    private void PickUpItem()
    {
        if (_fixedJoint.connectedBody != null)
        {
            DropItemOnTheGround();
        }

        _rigidbody.isKinematic = false;
        transform.position = _handTransform.position;
        _fixedJoint.connectedBody = _rigidbody;
        _currentItemInHand = gameObject;
    }

    private void DropItemOnTheGround()
    {
        _rigidbody.isKinematic = true;
        _fixedJoint.connectedBody = null;

    }

    private void ThrowItemForward()
    {
        if (_currentItemInHand != null)
        {
            _fixedJoint.connectedBody = null;
            
            _rigidbody = _currentItemInHand.GetComponent<Rigidbody>();
            _rigidbody.velocity = _hand.transform.forward * _itemVelocity;
            _currentItemInHand = null;
        }
    }
}