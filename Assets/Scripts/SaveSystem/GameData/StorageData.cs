[System.Serializable]
public class StorageData
{
    public float oil;
    public int fuel;
    public int wood;
    public int stone;
    public float coins;
    public int gems;

    public float capacity;

    public StorageData (Storage storage)
    {
        oil = storage.Oil;
        fuel = storage.Fuel;
        wood = storage.Wood;
        stone = storage.Stone;
        gems = storage.Gems;
        coins = storage.Coins;
        capacity = storage.Capacity;
    }
}
