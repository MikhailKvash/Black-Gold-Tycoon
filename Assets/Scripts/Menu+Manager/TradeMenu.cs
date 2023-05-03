using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TradeMenu : MonoBehaviour
{
    // Allows buying/selling oils when possible, commands ship launch
    
    [SerializeField] private GameObject oilDisplay;
    [SerializeField] private GameObject coinDisplay;
    [SerializeField] private GameObject cargoReady;
    [SerializeField] private GameObject currentOilDisplay;

    [SerializeField] private GameObject sendShipButton;
    [SerializeField] private GameObject mapButton;
    [SerializeField] private GameObject mapMenu;
    
    [SerializeField] private Storage storage;
    [SerializeField] private Slider oilToSellSlider;
    [SerializeField] private GameObject sliderHandle;

    [SerializeField] private float oilAmount;
    [SerializeField] private float coinAmount;
    
    private bool _shipAway;
    private bool _sentForCargo;
    private bool _sendShipButtonOff;
    private bool _sliderHandleOff;
    
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

    public bool SentForCargo
    {
        get => _sentForCargo;
        set => _sentForCargo = value;
    }

    public bool SendShipButtonOff
    {
        get => _sendShipButtonOff;
        set => _sendShipButtonOff = value;
    }

    public bool SliderHandleOff
    {
        get => _sliderHandleOff;
        set => _sliderHandleOff = value;
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

        if (_sliderHandleOff)
        {
            oilToSellSlider.interactable = false;
            sliderHandle.SetActive(false);
        }
        else
        {
            oilToSellSlider.interactable = true;
            sliderHandle.SetActive(true);
        }
        
        if (oilAmount <= 0)
        {
            _sendShipButtonOff = true;
        }
        
        if (oilAmount > 0 && !_sentForCargo)
        {
            _sendShipButtonOff = false;
        }

        if (_shipAway)
        {
            _sendShipButtonOff = true;
            _sliderHandleOff = true;
            mapButton.SetActive(true);
        }
        else
        {
            mapButton.SetActive(false);
            mapMenu.SetActive(false);
        }

        oilDisplay.GetComponent<TextMeshProUGUI>().text = oilAmount + "";
        coinDisplay.GetComponent<TextMeshProUGUI>().text = "Ожидаемый заработок: " + coinAmount;
        currentOilDisplay.GetComponent<TextMeshProUGUI>().text = storage.Oil + "";
        
        oilAmount = oilToSellSlider.value;
        oilToSellSlider.maxValue = storage.Oil;
    }

    public void CallSendShip()
    {
        FindObjectOfType<ShipVillager>().CarryCargo();
        _sentForCargo = true;
        _sendShipButtonOff = true;
        _sliderHandleOff = true;
        storage.Oil -= oilAmount;
    }

    public void ShipLeaving()
    {
        FindObjectOfType<ShipMovement>().FollowPath();
        StartCoroutine(CargoAppears());
    }

    public void ResetTrading()
    {
        oilAmount = 0;
        coinAmount = 0;
        _sentForCargo = false;
        _sendShipButtonOff = false;
        _sliderHandleOff = false;
    }

    private IEnumerator CargoAppears ()
    {
        cargoReady.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        cargoReady.SetActive(false);
    }
}