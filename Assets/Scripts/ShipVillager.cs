using UnityEngine;
using UnityEngine.AI;

public class ShipVillager : MonoBehaviour
{
    // Carries cargo from storage to ship, when called

    [SerializeField] private Transform storageEntrance;
    [SerializeField] private Transform shipEntrance;
    [SerializeField] private Transform waitingSpot;
    [SerializeField] private TradeMenu tradeMenu;

    private NavMeshAgent _navMeshAgent;

    private bool _singleDelivery;
    private bool _carryingCargo;
    private bool _tookCargo;

    public bool SingleDelivery
    {
        get => _singleDelivery;
        set => _singleDelivery = value;
    }
    public bool CarryingCargo
    {
        get => _carryingCargo;
        set => _carryingCargo = value;
    }
    public bool TookCargo
    {
        get => _tookCargo;
        set => _tookCargo = value;
    }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        var storageDistance = Vector3.Distance(transform.position, storageEntrance.position);
        var shipDistance = Vector3.Distance(transform.position, shipEntrance.position);

        if (_carryingCargo && !_singleDelivery && !_tookCargo)
        {
            _navMeshAgent.destination = storageEntrance.position;
        }

        if (_carryingCargo && !_singleDelivery && _tookCargo)
        {
            _navMeshAgent.destination = shipEntrance.position;
        }
        
        if (!_carryingCargo && _singleDelivery && !_tookCargo)
        {
            _navMeshAgent.destination = waitingSpot.position;
        }
        
        if (storageDistance <= 0.2f)
        {
            _tookCargo = true;
            tradeMenu.CargoWaiting = false;
        }
        if (shipDistance <= 0.2f && !_singleDelivery)
        {
            _singleDelivery = true;
            tradeMenu.ShipLeaving();
            _carryingCargo = false;
            _tookCargo = false;
        }
    }

    public void CarryCargo()
    {
        _singleDelivery = false;
        _carryingCargo = true;
    }
}
