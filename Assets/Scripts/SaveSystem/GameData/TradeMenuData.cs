[System.Serializable]
public class TradeMenuData
{
    public float oil;
    public float coins;
    
    public bool shipAway;
    public bool sentForCargo;
    public bool sendShipButtonOff;
    public bool sliderHandleOff;

    public TradeMenuData(TradeMenu tradeMenu)
    {
        oil = tradeMenu.OilAmount;
        coins = tradeMenu.ProfitCoins;
        
        shipAway = tradeMenu.ShipAway;
        sentForCargo = tradeMenu.SentForCargo;
        sendShipButtonOff = tradeMenu.SendShipButtonOff;
        sliderHandleOff = tradeMenu.SliderHandleOff;
    }
}
