using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ResourceShip : MonoBehaviour
{
    [SerializeField] private Transform dockingPosition;
    [SerializeField] private Transform preDockingPosition;

    [SerializeField] private Storage storage;
    [SerializeField] private BuyingMenu buyingMenu;
    [SerializeField] private DeliverResourcesTimer deliverTimer;
    [SerializeField] private XpRpManager xpRpManager;
    [SerializeField] private AudioManager audioManager;
    
    private NavMeshAgent _navMeshAgent;
    private bool _singleDelivery = true;

    private bool _goingAway;
    private bool _goingDocks;
    private bool _isWaiting;

    #region Public links
    public bool SingleDelivery
    {
        get => _singleDelivery;
        set => _singleDelivery = value;
    }
    public bool GoingAway
    {
        get => _goingAway;
        set => _goingAway = value;
    }
    public bool GoingDocks
    {
        get => _goingDocks;
        set => _goingDocks = value;
    }
    public bool IsWaiting
    {
        get => _isWaiting;
        set => _isWaiting = value;
    }
    #endregion
    
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        var position = transform.position;
        var dockingDistance = Vector3.Distance(position, dockingPosition.position);
        
        if (_goingAway)
        {
            _navMeshAgent.destination = preDockingPosition.position;
        }
        if (_goingDocks)
        {
            _navMeshAgent.destination = dockingPosition.position;
        }

        if (buyingMenu.ResourcesOrdered && deliverTimer.TimeLeft <= 0)
        {
            _singleDelivery = false;
            _goingDocks = true;
            _goingAway = false;
        }

        if (dockingDistance <= 0.4f && !_singleDelivery)
        {
            _singleDelivery = true;
            buyingMenu.ResourcesOrdered = false;
            storage.Stone += buyingMenu.Stone;
            storage.Fuel += buyingMenu.Fuel;
            storage.Wood += buyingMenu.Wood;
            buyingMenu.Stone = 0;
            buyingMenu.Fuel = 0;
            buyingMenu.Wood = 0;
            deliverTimer.TimeIsDisplaying = false;
            StartCoroutine(WaitAtDocks());
            audioManager.Play("ShipLeaveAndReturn");
            xpRpManager.Xp += 0.2f;
            xpRpManager.Rp += 0.3f;
        }
        
        if(_isWaiting) {StartCoroutine(WaitAtDocks());}
        
    }

    IEnumerator WaitAtDocks ()
    {
        _isWaiting = true;
        yield return new WaitForSeconds(5);
        _goingDocks = false;
        _goingAway = true;
        _isWaiting = false;
    }
}
