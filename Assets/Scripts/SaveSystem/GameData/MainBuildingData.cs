[System.Serializable]
public class MainBuildingData
{
    public int level;
    
    public MainBuildingData (MainBuilding mainBuilding)
    {
        level = mainBuilding.Level;
    }
}
