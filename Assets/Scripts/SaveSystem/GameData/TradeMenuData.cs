[System.Serializable]
public class TradeMenuData
{
    public float oilSlider;
    public float oilAmount;
    public float coins;
    
    public bool shipAway;
    public bool sentForCargo;
    public bool sendShipButtonOff;
    public bool sliderHandleOff;

    public TradeMenuData(TradeMenu tradeMenu)
    {
        oilSlider = tradeMenu.OilSliderAmount;
        oilAmount = tradeMenu.OilAmount;
        coins = tradeMenu.ProfitCoins;
        
        shipAway = tradeMenu.ShipAway;
        sentForCargo = tradeMenu.SentForCargo;
        sendShipButtonOff = tradeMenu.SendShipButtonOff;
        sliderHandleOff = tradeMenu.SliderHandleOff;
    }
}
