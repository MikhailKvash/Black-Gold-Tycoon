using UnityEngine;
using UnityEngine.AI;

public class ShipMovement : MonoBehaviour
{
    // Launches ship through waypoints, returns in to docks after delay timer, adds new coins and oil to storage
    
    [SerializeField] private Transform dockingPosition;
    [SerializeField] private Transform shipAwayTarget;
    [SerializeField] private Transform preDockingPosition;

    [SerializeField] private Storage storage;
    [SerializeField] private TradeMenu tradeMenu;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private XpRpManager xpRpManager;
    [SerializeField] private GameObject mapButton;

    private NavMeshAgent _navMeshAgent;
    private bool _singleDelivery = true;
    private bool _readyToReturnToDocks;

    private bool _goingAway;
    private bool _goingToLastPoint;
    private bool _goingDocks;

    #region Public links
    public bool SingleDelivery
    {
        get => _singleDelivery;
        set => _singleDelivery = value;
    }
    public bool ReadyToReturnToDocks
    {
        get => _readyToReturnToDocks;
        set => _readyToReturnToDocks = value;
    }
    public bool GoingAway
    {
        get => _goingAway;
        set => _goingAway = value;
    }
    public bool GoingToLastPoint
    {
        get => _goingToLastPoint;
        set => _goingToLastPoint = value;
    }
    public bool GoingDocks
    {
        get => _goingDocks;
        set => _goingDocks = value;
    }
    #endregion
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        var position = transform.position;
        var shipAwayDistance = Vector3.Distance(position, shipAwayTarget.position);
        var preDockingDistance = Vector3.Distance(position, preDockingPosition.position);
        var dockingDistance = Vector3.Distance(position, dockingPosition.position);

        if (_goingAway)
        {
            _navMeshAgent.destination = shipAwayTarget.position;
        }
        if (_goingToLastPoint)
        {
            _navMeshAgent.destination = preDockingPosition.position;
        }
        if (_goingDocks)
        {
            _navMeshAgent.destination = dockingPosition.position;
        }
            
        if (shipAwayDistance <= 0.4f)
        {
            _goingAway = false;
            _goingToLastPoint = true;
        }
        if (preDockingDistance <= 0.4f)
        {
            _goingToLastPoint = false;
            _singleDelivery = false;
            _readyToReturnToDocks = true;
        }
        if (_readyToReturnToDocks && timeManager.TimeLeft <= 0)
        {
            _goingDocks = true;
        }
        
        if (dockingDistance <= 0.3f && !_singleDelivery)
        {
            storage.Coins += tradeMenu.ProfitCoins;
            _singleDelivery = true;
            timeManager.PassedTime = 0;
            tradeMenu.ShipAway = false;
            tradeMenu.ResetTrading();
            audioManager.Play("ShipLeaveAndReturn");
            xpRpManager.Xp += 0.2f;
            xpRpManager.Rp += 0.3f;
        }
    }

    public void FollowPath()
    {
        _goingAway = true;
        _goingDocks = false;
        timeManager.StartShipTimer();
        _readyToReturnToDocks = false;
        tradeMenu.ShipAway = true;
        mapButton.SetActive(true);
        audioManager.Play("ShipLeaveAndReturn");
    }
}