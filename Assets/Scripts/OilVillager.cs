using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class OilVillager : MonoBehaviour
{
    // Takes oil from tower when available and carries it to storage.
    
    [SerializeField] private Transform storageEntrance;
    [SerializeField] private Transform oilTowerEntrance;
    [SerializeField] private Transform storageFullWaitSpot;

    [SerializeField] private Storage storage;
    [SerializeField] private OilTower oilTower;
    [SerializeField] private OilVillagerAnimation villagerAnimation;
    [SerializeField] private CarriedOilNumber carriedOilNumber;
    
    [SerializeField] private GameObject oilCapacityDisplay;
    
    [SerializeField] private int carryingOilMax;

    private NavMeshAgent _navMeshAgent;
    private float _carryingOil;
    private bool _takeOilOnce;
    private bool _dropOilOnce;
    private bool _box;

    #region Public links
    public int Capacity
    {
        get => carryingOilMax;
        set => carryingOilMax = value;
    }
    public float CarryingOil
    {
        get => _carryingOil;
        set => _carryingOil = value;
    }
    public bool TakeOilOnce
    {
        get => _takeOilOnce;
        set => _takeOilOnce = value;
    }
    public bool DropOilOnce
    {
        get => _dropOilOnce;
        set => _dropOilOnce = value;
    }
    public bool Box
    {
        get => _box;
        set => _box = value;
    }
    #endregion

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    private void Update()
    {
        oilCapacityDisplay.GetComponent<TextMeshProUGUI>().text = "Уносит за раз: " + carryingOilMax;

        if (storage.OilFull)
        {
            _navMeshAgent.destination = storageFullWaitSpot.position;
        }
        else if (_carryingOil <= 0 && oilTower.Oil >= 1)
        {
            _navMeshAgent.destination = oilTowerEntrance.position; 
        }
        else if (_carryingOil > 0)
        {
            _navMeshAgent.destination = storageEntrance.position;
        }

        if (_box)
        {
            villagerAnimation.box = true;
        }
        else
        {
            villagerAnimation.box = false;
        }

        var towerDistance = Vector3.Distance(transform.position, oilTowerEntrance.position);
        var storageDistance = Vector3.Distance(transform.position, storageEntrance.position);
            
        if (towerDistance <= 0.3f && !_takeOilOnce)
        {
            _box = true;
            if (oilTower.Oil >= carryingOilMax)
            {
                oilTower.TakeOil(carryingOilMax);
                _carryingOil += carryingOilMax;
                _takeOilOnce = true;
                _dropOilOnce = false;
            }
            else
            {
                float wholeOilAmount = Mathf.Floor(oilTower.Oil);
                _carryingOil += wholeOilAmount;
                oilTower.TakeOil(wholeOilAmount);
                _takeOilOnce = true;
                _dropOilOnce = false;
            }

            carriedOilNumber.CarriedOilNumber1 = _carryingOil;
            carriedOilNumber.SingleDelivery = false;
        }

        if (storageDistance <= 0.3f && !_dropOilOnce)
        {
            _box = false;
            if (_carryingOil > 0)
            {
                if (_carryingOil + storage.Oil <= storage.OilCapacity)
                {
                    storage.StoreOil(_carryingOil);
                    _carryingOil = 0;
                    _dropOilOnce = true;
                    _takeOilOnce = false;
                }
                else
                {
                    _carryingOil -= storage.OilCapacity - storage.Oil;
                    storage.StoreOil(storage.OilCapacity - storage.Oil);
                    _dropOilOnce = true;
                    _takeOilOnce = false;
                }
            }
        }
    }
}
