using System;
using UnityEngine;
using UnityEngine.Serialization;

public class MapBuilder : MonoBehaviour
{
    [SerializeField]
    private GameObject _grid;
    [SerializeField] private Color _redColor;
    [SerializeField] private Color _greenColor;

    private GameObject _selectedTile;

    [SerializeField] private GameObject _obstacleTile;
    [SerializeField] private GameObject _simpleTile;
    
    private Material[] _originalMaterialsOfObstacleTile;
    private Material[] _originalMaterialsOfSimpleTile;
    private Renderer[] _renderersOfCurrentTile;
    private RaycastHit[] _hitsInfo;

    /// <summary>
    /// Данный метод вызывается автоматически при клике на кнопки с изображениями тайлов.
    /// В качестве параметра передается префаб тайла, изображенный на кнопке.
    /// Вы можете использовать префаб tilePrefab внутри данного метода.
    /// </summary>
    private void Awake()
    {
        var obstacleTileRenderers = _obstacleTile.GetComponentsInChildren<Renderer>();
        var simpleTileRenderers = _simpleTile.GetComponentsInChildren<Renderer>();
        _originalMaterialsOfObstacleTile = GetOriginalMaterials(obstacleTileRenderers);
        _originalMaterialsOfSimpleTile = GetOriginalMaterials(simpleTileRenderers);
    }

    public void StartPlacingTile(GameObject tilePrefab)
    {
        _selectedTile = Instantiate(tilePrefab);
        _renderersOfCurrentTile = _selectedTile.GetComponentsInChildren<Renderer>();
    }
    

    private void Update()
    {
        MoveSelectedTile();
    }
    
    private void MoveSelectedTile()
    {
        
        if (_selectedTile != null)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo))
            {
                RaycastHit[] hits = Physics.RaycastAll(ray);
                _hitsInfo = hits;
                Vector3 localPosition = _grid.transform.InverseTransformPoint(hitInfo.point);
                Vector3 gridPosition = CalculateGridPosition(localPosition);

                var halfTileSize = Vector2.one / 2;

                var tilePosition = new Vector2(gridPosition.x, gridPosition.z) + halfTileSize;

                _selectedTile.transform.position = new Vector3(tilePosition.x, 0f, tilePosition.y);

                if (IsHittingRayInPlane(hits) && !IsHittingRayInTile(hits))
                {
                    SetGreenColor();
                }
                else
                {
                    SetRedColor();
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (IsHittingRayInPlane(_hitsInfo) && !IsHittingRayInTile(_hitsInfo))
            {
                SetOriginalColor();
                BoxCollider collider = _selectedTile.AddComponent<BoxCollider>();
                _selectedTile = null;
                _renderersOfCurrentTile = null;
                _hitsInfo = null;
            }
        }
        
        
    }
    
    private Vector3 CalculateGridPosition(Vector3 localPosition)
    {
        var cellSize = 1f;

        var x = Mathf.FloorToInt(localPosition.x / cellSize) * cellSize;
    
        var z = Mathf.FloorToInt(localPosition.z / cellSize) * cellSize;

        return new Vector3(x, 0f, z);
    }
    

    private void SetRedColor()
    {
        if (_renderersOfCurrentTile != null)
        {
            foreach (Renderer renderer in _renderersOfCurrentTile)
            {
                renderer.material.color = _redColor;
            }
        }
    }

    private void SetGreenColor()
    {
        if (_renderersOfCurrentTile != null)
        {
            foreach (Renderer renderer in _renderersOfCurrentTile)
            {
                renderer.material.color = _greenColor;
            }
        }
    }

    private void SetOriginalColor()
    {
        if (_originalMaterialsOfSimpleTile != null)
        {
            
            if (_selectedTile.transform.tag == "ObstacleTile")
            {
                
                for (var i = 0; i < _originalMaterialsOfObstacleTile.Length; i++)
                {
                    _renderersOfCurrentTile[i].material.color = _originalMaterialsOfObstacleTile[i].color;
                }
            }
           
            if (_selectedTile.transform.tag == "SimpleTile")
            {
                
                for (var i = 0; i < _originalMaterialsOfSimpleTile.Length; i++)
                {
                    _renderersOfCurrentTile[i].material.color = _originalMaterialsOfSimpleTile[i].color;
                }
            }

        }
    }

    private Material[] GetOriginalMaterials(Renderer[] renderers)
    {
        if (renderers != null)
        {
            Material[] materials = new Material[renderers.Length];

            for (var i = 0; i < renderers.Length; i++)
            {
                materials[i] = renderers[i].sharedMaterial;
            }
            return materials;
        }

        return null;
    }

    private bool IsHittingRayInPlane(RaycastHit[] hits)
    {
        var isHittingRayInPlane = false;
        if (hits != null)
        {
            for (var i = 0; i < hits.Length; i++)
            {
                if (hits[i].transform.tag == "Plane")
                {
                    isHittingRayInPlane = true;
                }
            }
        }

        return isHittingRayInPlane;
    }
    
    private bool IsHittingRayInTile(RaycastHit[] hits)
    {
        var isHittingRayInPlane = false;
        if (hits.Length > 0)
        {
            for (var i = 0; i < hits.Length; i++)
            {
                if (hits[i].transform.tag == "ObstacleTile" || hits[i].transform.tag == "SimpleTile")
                {
                    isHittingRayInPlane = true;
                }
            }
        }

        return isHittingRayInPlane;
    }
    
    
}