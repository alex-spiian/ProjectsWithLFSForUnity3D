using UnityEngine;

public class Task4 : MonoBehaviour
{
    [SerializeField] 
    private Transform _shelfPrefab;
    private Transform _createdShelf;

    private void Start()
    {
        _createdShelf = Instantiate(_shelfPrefab); // Эту строку кода удалять нельзя
        Destroy(_createdShelf.gameObject);
    }
}

