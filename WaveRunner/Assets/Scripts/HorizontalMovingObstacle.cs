using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HorizontalMovingObstacle : MonoBehaviour
{
    private float _speed;
    private float _currentTime;

    private Vector3 _startPosition;
    private Vector3 _endPosition;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 10;
        _startPosition = transform.position;
        _endPosition = _startPosition;
        _endPosition.x -= 5;
        _startPosition.x = 5;
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
        var progress = (Mathf.Sin(_currentTime) + 1) / 2;
        
        var newPosition = Vector3.Lerp(_startPosition, _endPosition, progress);
        transform.position = newPosition;
    }
}
