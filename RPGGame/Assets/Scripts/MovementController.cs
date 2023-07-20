using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _destination;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Перемещаем персонажа в направлении _destination.
        if (_destination != null)
        {
            _navMeshAgent.SetDestination(_destination);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GetDestination();
        }
        
        // TODO: Получите точку, по которой кликнули мышью и задайте ее вектор в поле _destination.
    }

    private void GetDestination()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out  var hitInfo))
        {
            _destination = hitInfo.point;
        }
    }
}