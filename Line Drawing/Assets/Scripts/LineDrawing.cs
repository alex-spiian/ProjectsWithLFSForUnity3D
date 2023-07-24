using UnityEngine;
using UnityEngine.Serialization;

public class LineDrawing : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _lineRenderer;
    [SerializeField]
    private float _lineWidth;

    private bool _isDrawing;
    private Vector3[] _linePositions;
    private int _linePositionIndex;

    private void Start()
    {
        _lineRenderer.startWidth = _lineWidth;
        _lineRenderer.endWidth = _lineWidth;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }

        if (Input.GetMouseButton(0))
        {
            ContinueDrawing();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopDrawing();
        }
    }

    private void StartDrawing()
    {
        _isDrawing = true;
        _lineRenderer.positionCount = 0;
        _linePositionIndex = 0;
    }

    private void ContinueDrawing()
    {
        if (!_isDrawing)
        {
            return;
        }

        var mousePosition = Input.mousePosition;
        mousePosition.z = 500f;

        var worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        _lineRenderer.positionCount = _linePositionIndex + 1;
        _lineRenderer.SetPosition(_linePositionIndex, worldPosition);

        _linePositionIndex++;
    }

    private void StopDrawing()
    {
        _isDrawing = false;
    }
}