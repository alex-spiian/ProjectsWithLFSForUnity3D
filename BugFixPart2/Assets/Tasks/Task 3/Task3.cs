using UnityEngine;

public class Task3 : MonoBehaviour
{
    [SerializeField] 
    private Transform _wallPrefab;
    
    private void Start()
    {
        _wallPrefab.GetComponent<Rigidbody>().isKinematic = false;
        Instantiate(_wallPrefab);
    }
}
