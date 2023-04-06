using UnityEngine;
using UnityEngine.AI;

public class ShipVillager : MonoBehaviour
{
    // Carries cargo from storage to ship, when called

    [SerializeField] private Transform storageEntrance;
    [SerializeField] private Transform shipEntrance;
    [SerializeField] private Transform waitingSpot;
    
    [SerializeField] private TradeMenu tradeMenu;
    [SerializeField] private ShipVillagerAnimation villagerAnimation;

    private NavMeshAgent _navMeshAgent;

    private bool _singleDelivery;
    [SerializeField] private bool _carryingCargo;
    private bool _tookCargo;
    private bool _box;

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
    public bool Box
    {
        get => _box;
        set => _box = value;
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
        
        if (!_carryingCargo && !_tookCargo)
        {
            _navMeshAgent.destination = waitingSpot.position;
        }
        
        if (storageDistance <= 0.2f)
        {
            _box = true;
            _tookCargo = true;
            tradeMenu.CargoWaiting = false;
        }
        if (shipDistance <= 0.2f && !_singleDelivery)
        {
            _box = false;
            _singleDelivery = true;
            tradeMenu.ShipLeaving();
            _carryingCargo = false;
            _tookCargo = false;
        }
        
        if (_box)
        {
            villagerAnimation.box = true;
        }
        else
        {
            villagerAnimation.box = false;
        }
    }

    public void CarryCargo()
    {
        _singleDelivery = false;
        _carryingCargo = true;
    }
}
