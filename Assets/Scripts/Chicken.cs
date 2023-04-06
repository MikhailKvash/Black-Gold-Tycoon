using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class Chicken : MonoBehaviour
{
    [SerializeField] private Transform chickenPath;
    
    private NavMeshAgent _navMeshAgent;
    private List<Transform> _currentWaypoint;
    private int _randomWaypoint;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _currentWaypoint = GetChickenWaypoints();
        _randomWaypoint = Random.Range(0, 10);
    }

    private void Update()
    {
        var waypointDistance = Vector3.Distance(transform.position, _currentWaypoint[_randomWaypoint].position);
        
        _navMeshAgent.destination = _currentWaypoint[_randomWaypoint].position;

        if (waypointDistance <= 0.2f)
        {
            _randomWaypoint = Random.Range(0, 10);
            _navMeshAgent.destination = _currentWaypoint[_randomWaypoint].position;
        }
    }
    
    private List<Transform> GetChickenWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in chickenPath)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
}
