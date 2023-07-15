using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoorTrigger : MonoBehaviour
{

    [SerializeField] private Collider _collider;

    [SerializeField] private Door _door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (_collider.Raycast(ray, out var hitInfo, 50f) && Input.GetKeyDown(KeyCode.E))
        {
            _door.SwitchDoorState();
        }
        
    }
}
