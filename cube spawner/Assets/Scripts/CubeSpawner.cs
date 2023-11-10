
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float _rightBorder;
    [SerializeField] private float _leftBorder;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        { 
            Vector3 randomPosition = new Vector3(Random.Range(_leftBorder, _rightBorder), 10, 5);
            Instantiate(_cubePrefab, randomPosition, Quaternion.identity);
        }
    }
}
