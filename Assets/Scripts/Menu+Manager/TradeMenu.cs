using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TradeMenu : MonoBehaviour
{
    // Allows buying/selling oils when possible, commands ship launch
    
    [SerializeField] private GameObject oilDisplay;
    [SerializeField] private GameObject coinDisplay;
    [SerializeField] private GameObject notEnoughMessage;
    [SerializeField] private GameObject cargoReady;
    [SerializeField] private GameObject currentOilDisplay;
    [SerializeField] private GameObject currentSliderOilDisplay;
    
    [SerializeField] private GameObject sellOilButton;
    [SerializeField] private GameObject sellLessOilButton;
    [SerializeField] private GameObject sellSliderOilButton;
    [SerializeField] private GameObject sendShipButton;
    [SerializeField] private GameObject mapButton;

    [SerializeField] private GameObject mapMenu;
    
    [SerializeField] private Storage storage;
    [SerializeField] private Slider oilToSellSlider;

    [SerializeField] private float oilAmount;
    [SerializeField] private float coinAmount;

    private float _oilOnSlider;
    private bool _shipAway;
    private bool _cargoWaiting;
    private bool _sendShipButtonOff;
    
    public float ProfitCoins
    {
        get => coinAmount;
        set => coinAmount = value;
    }

    public float OilAmount
    {
        get => oilAmount;
        set => oilAmount = value;
    }

    public bool ShipAway
    {
        get => _shipAway;
        set => _shipAway = value;
    }

    public bool CargoWaiting
    {
        get => _cargoWaiting;
        set => _cargoWaiting = value;
    }

    public bool SendShipButtonOff
    {
        get => _sendShipButtonOff;
        set => _sendShipButtonOff = value;
    }

    private void Update()
    {
        coinAmount = oilAmount * 100;

        if (_sendShipButtonOff)
        {
            sendShipButton.SetActive(false);
        }
        else
        {
            sendShipButton.SetActive(true);
        }
        
        if (oilAmount <= 0)
        {
            _sendShipButtonOff = true;
        }

        if (_shipAway)
        {
            _sendShipButtonOff = true;
            sellOilButton.SetActive(false);
            sellLessOilButton.SetActive(false);
            mapButton.SetActive(true);
        }
        else
        {
            mapButton.SetActive(false);
            mapMenu.SetActive(false);
        }

        if(_cargoWaiting){cargoReady.SetActive(true);} else {cargoReady.SetActive(false);}

        oilDisplay.GetComponent<TextMeshProUGUI>().text = oilAmount + "";
        coinDisplay.GetComponent<TextMeshProUGUI>().text = "Ожидаемый заработок: " + coinAmount;

        currentOilDisplay.GetComponent<TextMeshProUGUI>().text = storage.Oil + "";
        currentSliderOilDisplay.GetComponent<TextMeshProUGUI>().text = oilToSellSlider.value + "";
        
        oilToSellSlider.maxValue = storage.Oil;
        _oilOnSlider = oilToSellSlider.value;
    }

    public void SellOil ()
    {
        if (storage.Oil > oilAmount)
        {
            oilAmount += 1;
            _sendShipButtonOff = false;
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "Недостаточно нефти!";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
        }
    }

    public void SellLessOil()
    {
        if (oilAmount > 0)
        {
            oilAmount -= 1;
        }
    }

    public void SellSliderOil()
    {
        if (_oilOnSlider >= 0)
        {
            oilAmount = _oilOnSlider;
            _sendShipButtonOff = false;
        }
    }

    public void CallSendShip()
    {
        FindObjectOfType<ShipVillager>().CarryCargo();
        _cargoWaiting = true;
        sellOilButton.SetActive(false);
        sellLessOilButton.SetActive(false);
        sellSliderOilButton.SetActive(false);
        _sendShipButtonOff = true;
        storage.Oil -= oilAmount;
    }

    public void ShipLeaving()
    {
        FindObjectOfType<ShipMovement>().FollowPath();
    }

    public void ResetTrading()
    {
        oilAmount = 0;
        coinAmount = 0;
        sellOilButton.SetActive(true);
        sellLessOilButton.SetActive(true);
        sellSliderOilButton.SetActive(true);
        _sendShipButtonOff = false;
    }
}