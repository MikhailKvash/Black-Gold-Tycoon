using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyingMenu : MonoBehaviour
{
    [SerializeField] private GameObject stoneDisplay;
    [SerializeField] private GameObject fuelDisplay;
    [SerializeField] private GameObject woodDisplay;
    [SerializeField] private GameObject coinsLeftDisplay;
    [SerializeField] private GameObject coinsLeftHeader;
    [SerializeField] private GameObject buyingResourceDisplay;
    [SerializeField] private GameObject maxResourceDisplay;
    
    [SerializeField] private GameObject currentResourceName;
    [SerializeField] private GameObject notEnoughMoneyDisplay;

    [SerializeField] private GameObject acceptAmountButton;
    [SerializeField] private GameObject callForResourceShipButton;

    [SerializeField] private Storage storage;
    [SerializeField] private DeliverResourcesTimer deliverTimer;
    [SerializeField] private Slider buyingSlider;
    [SerializeField] private GameObject sliderHandle;

    [SerializeField] private float coinsLeft;
    [SerializeField] private float orderCost;
    [SerializeField] private float stone;
    [SerializeField] private float fuel;
    [SerializeField] private float wood;
    [SerializeField] private float totalOrderAmount;

    private int _toggleNumber;

    private bool _stoneToggle;
    private bool _fuelToggle;
    private bool _woodToggle;

    private bool _resourcesOrdered;

    #region Public links
    public float CoinsLeft
    {
        get => coinsLeft;
        set => coinsLeft = value;
    }
    public float OrderCost
    {
        get => orderCost;
        set => orderCost = value;
    }
    public float Stone
    {
        get => stone;
        set => stone = value;
    }
    public float Fuel
    {
        get => fuel;
        set => fuel = value;
    }
    public float Wood
    {
        get => wood;
        set => wood = value;
    }
    public float TotalOrderAmount
    {
        get => totalOrderAmount;
        set => totalOrderAmount = value;
    }
    public int ToggleNumber
    {
        get => _toggleNumber;
        set => _toggleNumber = value;
    }
    public bool StoneToggle
    {
        get => _stoneToggle;
        set => _stoneToggle = value;
    }
    public bool FuelToggle
    {
        get => _fuelToggle;
        set => _fuelToggle = value;
    }
    public bool WoodToggle
    {
        get => _woodToggle;
        set => _woodToggle = value;
    }
    public bool ResourcesOrdered
    {
        get => _resourcesOrdered;
        set => _resourcesOrdered = value;
    }
    #endregion
    
    private void Update()
    {
        coinsLeft = storage.Coins - stone * 250 - fuel * 10000 - wood * 500;
        orderCost = stone * 250 + fuel * 10000 + wood * 500;

        if (_resourcesOrdered)
        {
            coinsLeftDisplay.SetActive(false);
            coinsLeftHeader.SetActive(false);
            acceptAmountButton.SetActive(false);
            sliderHandle.SetActive(false);
            buyingSlider.interactable = false;
            callForResourceShipButton.SetActive(false);
        }
        else
        {
            coinsLeftDisplay.SetActive(true);
            coinsLeftHeader.SetActive(true);
            acceptAmountButton.SetActive(true);
            sliderHandle.SetActive(true);
            buyingSlider.interactable = true;
        }
        
        stoneDisplay.GetComponent<TextMeshProUGUI>().text = stone + "";
        fuelDisplay.GetComponent<TextMeshProUGUI>().text = fuel + "";
        woodDisplay.GetComponent<TextMeshProUGUI>().text = wood + "";
        coinsLeftDisplay.GetComponent<TextMeshProUGUI>().text = coinsLeft + "";
        buyingResourceDisplay.GetComponent<TextMeshProUGUI>().text = buyingSlider.value + "";

        if (stone <= 0 && fuel <= 0 && wood <= 0)
        {
            callForResourceShipButton.SetActive(false);
        }
        else if (!_resourcesOrdered)
        {
            callForResourceShipButton.SetActive(true);
        }

        if (_toggleNumber == 0)
        {
            currentResourceName.GetComponent<TextMeshProUGUI>().text = "Купить камень";

            if (coinsLeft / 250 + stone > storage.StoneCapacity - storage.Stone)
            {
                buyingSlider.maxValue = storage.StoneCapacity - storage.Stone;
                maxResourceDisplay.GetComponent<TextMeshProUGUI>().text = "" + (storage.StoneCapacity - storage.Stone);
                notEnoughMoneyDisplay.GetComponent<TextMeshProUGUI>().text = "Склад почти полон!";
            }
            else
            {
                if (coinsLeft / 250 < 1)
                {
                    if (storage.Coins / 250 < 1)
                    {
                        notEnoughMoneyDisplay.GetComponent<TextMeshProUGUI>().text = "Недостаточно денег для покупки!";
                    }
                    else
                    {
                        notEnoughMoneyDisplay.GetComponent<TextMeshProUGUI>().text = "Все доступные деньги распределены по ресурсам!";
                    }
                
                    maxResourceDisplay.GetComponent<TextMeshProUGUI>().text = "0";
                    buyingSlider.maxValue = 0;
                }
                else
                {
                    notEnoughMoneyDisplay.GetComponent<TextMeshProUGUI>().text = "";
                    maxResourceDisplay.GetComponent<TextMeshProUGUI>().text = Mathf.FloorToInt((coinsLeft / 250f) + stone) + "";
                    buyingSlider.maxValue = Mathf.FloorToInt((coinsLeft / 250f) + stone);
                }
            }
        }
        
        if (_toggleNumber == 1)
        {
            currentResourceName.GetComponent<TextMeshProUGUI>().text = "Купить топливо";
            
            if (coinsLeft / 10000 + fuel > storage.FuelCapacity - storage.Fuel)
            {
                buyingSlider.maxValue = storage.FuelCapacity - storage.Fuel;
                maxResourceDisplay.GetComponent<TextMeshProUGUI>().text = "" + (storage.FuelCapacity - storage.Fuel);
                notEnoughMoneyDisplay.GetComponent<TextMeshProUGUI>().text = "Склад почти полон!";
            }
            else
            {
                if (coinsLeft / 10000 < 1)
                {
                    if (storage.Coins / 10000 < 1)
                    {
                        notEnoughMoneyDisplay.GetComponent<TextMeshProUGUI>().text = "Недостаточно денег для покупки!";
                    }
                    else
                    {
                        notEnoughMoneyDisplay.GetComponent<TextMeshProUGUI>().text = "Все доступные деньги распределены по ресурсам!";
                    }

                    maxResourceDisplay.GetComponent<TextMeshProUGUI>().text = "0";
                    buyingSlider.maxValue = 0;
                }
                else
                {
                    notEnoughMoneyDisplay.GetComponent<TextMeshProUGUI>().text = "";
                    maxResourceDisplay.GetComponent<TextMeshProUGUI>().text = Mathf.FloorToInt((coinsLeft / 10000f) + fuel) + "";
                    buyingSlider.maxValue = Mathf.FloorToInt((coinsLeft / 10000f) + fuel);
                }
            }
        }
        
        if (_toggleNumber == 2)
        {
            currentResourceName.GetComponent<TextMeshProUGUI>().text = "Купить дерево";
            
            if (coinsLeft / 500 + wood > storage.WoodCapacity - storage.Wood)
            {
                buyingSlider.maxValue = storage.WoodCapacity - storage.Wood;
                maxResourceDisplay.GetComponent<TextMeshProUGUI>().text = "" + (storage.WoodCapacity - storage.Wood);
                notEnoughMoneyDisplay.GetComponent<TextMeshProUGUI>().text = "Склад почти полон!";
            }
            else
            {
                if (coinsLeft / 500 < 1)
                {
                    if (storage.Coins / 500 < 1)
                    {
                        notEnoughMoneyDisplay.GetComponent<TextMeshProUGUI>().text = "Недостаточно денег для покупки!";
                    }
                    else
                    {
                        notEnoughMoneyDisplay.GetComponent<TextMeshProUGUI>().text = "Все доступные деньги распределены по ресурсам!";
                    }
                
                    maxResourceDisplay.GetComponent<TextMeshProUGUI>().text = "0";
                    buyingSlider.maxValue = 0;
                }
                else
                {
                    notEnoughMoneyDisplay.GetComponent<TextMeshProUGUI>().text = "";
                    maxResourceDisplay.GetComponent<TextMeshProUGUI>().text = Mathf.FloorToInt((coinsLeft / 500f) + wood) + "";
                    buyingSlider.maxValue = Mathf.FloorToInt((coinsLeft / 500f) + wood);
                }
            }
        }
    }

    public void AcceptAmount()
    {
        if (_toggleNumber == 0)
        {
            stone = buyingSlider.value;
        }
        
        if (_toggleNumber == 1)
        {
            fuel = buyingSlider.value;
        }
        
        if (_toggleNumber == 2)
        {
            wood = buyingSlider.value;
        }
    }
    
    public void ToggleStone()
    {
        buyingSlider.value = 0;
        _toggleNumber = 0;
    }
    
    public void ToggleFuel()
    {
        buyingSlider.value = 0;
        _toggleNumber = 1;
    }
    
    public void ToggleWood()
    {
        buyingSlider.value = 0;
        _toggleNumber = 2;
    }

    public void RequestShip()
    {
        totalOrderAmount = stone + fuel + wood;
        deliverTimer.StartShipTimer();
        storage.Coins -= orderCost;
        _resourcesOrdered = true;
        deliverTimer.TimeIsDisplaying = true;
    }
}
