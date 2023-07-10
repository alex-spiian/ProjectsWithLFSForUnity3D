using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChangingObstacle : MonoBehaviour
{

    private Vector3 _startScale;
    private Vector3 _finalScale;
    private float _currentTime;
    
    // Start is called before the first frame update
    void Start()
    {
        _startScale = transform.localScale;
        _finalScale = transform.localScale;
        _finalScale.x += 1.5f;
        _finalScale.y += 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
        var progress = (Mathf.Sin(_currentTime) + 1) / 2;
        transform.localScale = Vector3.Lerp(_startScale, _finalScale, progress);

    }
}
