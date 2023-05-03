using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyingMenu : MonoBehaviour
{
    [SerializeField] private GameObject stoneDisplay;
    [SerializeField] private GameObject fuelDisplay;
    [SerializeField] private GameObject woodDisplay;
    [SerializeField] private GameObject coinsLeftDisplay;
    [SerializeField] private GameObject buyingResourceDisplay;
    [SerializeField] private GameObject maxResourceDisplay;
    
    [SerializeField] private GameObject currentResourceName;
    [SerializeField] private GameObject notEnoughMoneyDisplay;

    [SerializeField] private GameObject acceptAmountButton;
    [SerializeField] private GameObject callForResourceShip;

    [SerializeField] private Storage storage;
    [SerializeField] private Slider buyingSlider;
    [SerializeField] private GameObject sliderHandle;

    [SerializeField] private float coinsLeft;
    [SerializeField] private float stone;
    [SerializeField] private float fuel;
    [SerializeField] private float wood;

    private int _toggleNumber;

    private bool _stoneToggle;
    private bool _fuelToggle;
    private bool _woodToggle;

    private void Update()
    {
        coinsLeft = storage.Coins - stone * 250 - fuel * 10000 - wood * 500;

        stoneDisplay.GetComponent<TextMeshProUGUI>().text = stone + "";
        fuelDisplay.GetComponent<TextMeshProUGUI>().text = fuel + "";
        woodDisplay.GetComponent<TextMeshProUGUI>().text = wood + "";
        coinsLeftDisplay.GetComponent<TextMeshProUGUI>().text = coinsLeft + "";
        buyingResourceDisplay.GetComponent<TextMeshProUGUI>().text = buyingSlider.value + "";

        if (stone <= 0 && fuel <= 0 && wood <= 0)
        {
            callForResourceShip.SetActive(false);
        }
        else
        {
            callForResourceShip.SetActive(true);
        }

        if (_toggleNumber == 0)
        {
            currentResourceName.GetComponent<TextMeshProUGUI>().text = "Купить камень";
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
                maxResourceDisplay.GetComponent<TextMeshProUGUI>().text = coinsLeft / 250 + stone + "";
                buyingSlider.maxValue = coinsLeft / 250 + stone;
            }
        }
        
        if (_toggleNumber == 1)
        {
            currentResourceName.GetComponent<TextMeshProUGUI>().text = "Купить топливо";
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
                maxResourceDisplay.GetComponent<TextMeshProUGUI>().text = coinsLeft / 10000 + fuel + "";
                buyingSlider.maxValue = coinsLeft / 10000 + fuel;
            }
        }
        
        if (_toggleNumber == 2)
        {
            currentResourceName.GetComponent<TextMeshProUGUI>().text = "Купить дерево";
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
                maxResourceDisplay.GetComponent<TextMeshProUGUI>().text = coinsLeft / 500 + wood + "";
                buyingSlider.maxValue = coinsLeft / 500 + wood;
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
}
