[System.Serializable]
public class TradeMenuData
{
    public float oil;
    public float coins;
    public bool shipAway;
    public bool cargoWaiting;

    public TradeMenuData(TradeMenu tradeMenu)
    {
        oil = tradeMenu.OilAmount;
        coins = tradeMenu.ProfitCoins;
        shipAway = tradeMenu.ShipAway;
        cargoWaiting = tradeMenu.CargoWaiting;
    }
}
