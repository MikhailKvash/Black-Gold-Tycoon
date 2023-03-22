[System.Serializable]
public class OilTowerData
{
    public float oil;
    public float capacity;
    public float timeToGenerateOil;
    public int level;
    public float passedTimeToFillSlider;
    
    public OilTowerData (OilTower oilTower)
    {
        oil = oilTower.Oil;
        capacity = oilTower.Capacity;
        timeToGenerateOil = oilTower.TimeToGenerateOil;
        level = oilTower.Level;
        passedTimeToFillSlider = oilTower.PassedTimeToFillSlider;
    }
}
