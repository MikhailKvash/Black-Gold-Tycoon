using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Fish : MonoBehaviour
{
    private GameObject _spawnPoint1;
    private GameObject _spawnPoint2;
    private GameObject _spawnPoint3;
    private GameObject _spawnPoint4;
    private GameObject _spawnPoint5;
    
    private GameObject _destinationPoint1;
    private GameObject _destinationPoint2;
    private GameObject _destinationPoint3;
    private GameObject _destinationPoint4;
    private GameObject _destinationPoint5;
    
    private NavMeshAgent _navMeshAgent;
    private int _speed;

    private void Awake()
    {
        _spawnPoint1 = GameObject.Find("FishSpawnPoint (0)");
        _spawnPoint2 = GameObject.Find("FishSpawnPoint (1)");
        _spawnPoint3 = GameObject.Find("FishSpawnPoint (2)");
        _spawnPoint4 = GameObject.Find("FishSpawnPoint (3)");
        _spawnPoint5 = GameObject.Find("FishSpawnPoint (4)");
        
        _destinationPoint1 = GameObject.Find("FishDestinationPoint (0)");
        _destinationPoint2 = GameObject.Find("FishDestinationPoint (1)");
        _destinationPoint3 = GameObject.Find("FishDestinationPoint (2)");
        _destinationPoint4 = GameObject.Find("FishDestinationPoint (3)");
        _destinationPoint5 = GameObject.Find("FishDestinationPoint (4)");
        
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _speed = Random.Range(3, 6);
    }    

    private void Update()
    {
        GetComponent<NavMeshAgent>().speed = _speed;
        
        var position = transform.position;
        var spawnPointDistance1 = Vector3.Distance(position, _spawnPoint1.transform.position);
        var spawnPointDistance2 = Vector3.Distance(position, _spawnPoint2.transform.position);
        var spawnPointDistance3 = Vector3.Distance(position, _spawnPoint3.transform.position);
        var spawnPointDistance4 = Vector3.Distance(position, _spawnPoint4.transform.position);
        var spawnPointDistance5 = Vector3.Distance(position, _spawnPoint5.transform.position);
        
        var destinationPointDistance1 = Vector3.Distance(position, _destinationPoint1.transform.position);
        var destinationPointDistance2 = Vector3.Distance(position, _destinationPoint2.transform.position);
        var destinationPointDistance3 = Vector3.Distance(position, _destinationPoint3.transform.position);
        var destinationPointDistance4 = Vector3.Distance(position, _destinationPoint4.transform.position);
        var destinationPointDistance5 = Vector3.Distance(position, _destinationPoint5.transform.position);

        if (spawnPointDistance1 <= 0.3f)
        {
            _navMeshAgent.destination = _destinationPoint1.transform.position;
        }
        if (spawnPointDistance2 <= 0.3f)
        {
            _navMeshAgent.destination = _destinationPoint2.transform.position;
        }
        if (spawnPointDistance3 <= 0.3f)
        {
            int randomDestination = Random.Range(0, 2);
            if (randomDestination == 0)
            {
                _navMeshAgent.destination = _destinationPoint3.transform.position;
            }
            else
            {
                _navMeshAgent.destination = _destinationPoint4.transform.position;
            }
        }
        if (spawnPointDistance4 <= 0.3f)
        {
            _navMeshAgent.destination = _destinationPoint5.transform.position;
        }
        if (spawnPointDistance5 <= 0.3f)
        {
            _navMeshAgent.destination = _destinationPoint5.transform.position;
        }

        if (destinationPointDistance1 <= 0.2 || destinationPointDistance2 <= 0.2 || destinationPointDistance3 <= 0.2 ||
            destinationPointDistance4 <= 0.2 || destinationPointDistance5 <= 0.2)
        {
            Destroy(gameObject);
        }
    }
}
