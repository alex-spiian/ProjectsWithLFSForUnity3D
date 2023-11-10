using UnityEngine;
using Random = UnityEngine.Random;

public class Recoloring : MonoBehaviour
{
    [SerializeField]
    private float _recoloringDuration;
    [SerializeField]
    private float _durationBetweenRecoloring;
    private float _currentTime;
    
    private Color _startColor;
    private Color _nextColor;
    private Renderer _renderer;
    

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV(0f, 1f, 0.8f, 1f, 1f, 1f);
        GenerateNextColor();
    }
    
    private void Update()
    {
        ChangeColor();
    }

    private void GenerateNextColor()
    {
        _nextColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 1f, 1f);
        _startColor = _renderer.material.color;
    }
    

    private void ChangeColor()
    {
        _currentTime += Time.deltaTime;
        var progress = _currentTime / _recoloringDuration;
        
        var currentColor = Color.Lerp(_startColor, _nextColor, progress);
        _renderer.material.color = currentColor;

        if (_currentTime >= _recoloringDuration)
        {
            _currentTime = 0f;
            _currentTime -= _durationBetweenRecoloring;
            GenerateNextColor();
        }
    }

}