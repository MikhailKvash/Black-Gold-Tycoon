[System.Serializable]
public class StorageData
{
    public float oil;
    public float fuel;
    public float wood;
    public float stone;
    public float coins;
    public float gems;

    public float capacity;

    public StorageData (Storage storage)
    {
        oil = storage.Oil;
        fuel = storage.Fuel;
        wood = storage.Wood;
        stone = storage.Stone;
        gems = storage.Gems;
        coins = storage.Coins;
        capacity = storage.OilCapacity;
    }
}
