using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnFire : MonoBehaviour
{

    [SerializeField]
    private GameObject _fire;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _fire.SetActive(true);
        }
    }
}
