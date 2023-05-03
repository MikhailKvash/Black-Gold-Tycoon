using UnityEngine;
using UnityEngine.AI;

public class ResourceShip : MonoBehaviour
{
    [SerializeField] private Transform dockingPosition;
    [SerializeField] private Transform preDockingPosition;
    
    [SerializeField] private BuyingMenu buyingMenu;
    //TimerForResourceShip
    [SerializeField] private AudioManager audioManager;
    
    private NavMeshAgent _navMeshAgent;
    private bool _singleDelivery = true;
    
    private bool _goingAway;
    private bool _goingDocks;
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        var position = transform.position;
        var preDockingDistance = Vector3.Distance(position, preDockingPosition.position);
        var dockingDistance = Vector3.Distance(position, dockingPosition.position);
        
        if (_goingAway)
        {
            _navMeshAgent.destination = preDockingPosition.position;
        }
        if (_goingDocks)
        {
            _navMeshAgent.destination = dockingPosition.position;
        }
    }

    public void DeliverResources()
    {
        _goingDocks = true;
        _goingAway = false;
        //StartShipTimer
    }
}
