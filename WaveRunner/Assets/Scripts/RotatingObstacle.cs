using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    private float _rotationSpeed;
    private Quaternion _rotation;
    void Start()
    {
        _rotation = transform.rotation;
        _rotationSpeed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        var step = _rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, step, Space.Self);
    }
}
