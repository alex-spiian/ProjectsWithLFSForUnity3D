using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    private const float outlineWidth = 2;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerOutline = _player.GetComponent<Outline>();
            playerOutline.OutlineWidth = outlineWidth;
            _player.IsPotionInPlayer = true;
            
            Destroy(gameObject);
        }
    }
}
