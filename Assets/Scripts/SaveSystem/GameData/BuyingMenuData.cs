    [System.Serializable]
public class BuyingMenuData
{
    public float coinsLeft;
    public float orderCost;
    public float stone;
    public float fuel;
    public float wood;
    public float totalOrderAmount;

    public int toggleNumber;

    public bool stoneToggle;
    public bool fuelToggle;
    public bool woodToggle;

    public bool resourcesOrdered;

    public BuyingMenuData(BuyingMenu buyingMenu)
    {
        coinsLeft = buyingMenu.CoinsLeft;
        orderCost = buyingMenu.OrderCost;
        stone = buyingMenu.Stone;
        fuel = buyingMenu.Fuel;
        wood = buyingMenu.Wood;
        totalOrderAmount = buyingMenu.TotalOrderAmount;

        toggleNumber = buyingMenu.ToggleNumber;

        stoneToggle = buyingMenu.StoneToggle;
        fuelToggle = buyingMenu.FuelToggle;
        woodToggle = buyingMenu.WoodToggle;

        resourcesOrdered = buyingMenu.ResourcesOrdered;
    }
}
