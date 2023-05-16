[System.Serializable]
public class UpgradeMenuData
{
    public int oilLevelStoneValue;
    public int oilLevelWoodValue;
    public int oilLevelCoinsValue;
    
    public int oilCapacityCoinsValue;
    
    public int carrierCapacityCoinsValue;
    
    public int storageCapacityStoneValue;
    public int storageCapacityWoodValue;
    public int storageCapacityCoinsValue;
    
    public int mainBuildingLevelFuelValue;
    public int mainBuildingLevelStoneValue;
    public int mainBuildingLevelWoodValue;
    public int mainBuildingLevelCoinsValue;

    public UpgradeMenuData(UpgradeMenu upgradeMenu)
    {
        oilLevelStoneValue = upgradeMenu.OilLevelStoneValue;
        oilLevelWoodValue = upgradeMenu.OilLevelWoodValue;
        oilLevelCoinsValue = upgradeMenu.OilLevelCoinsValue;
        
        oilCapacityCoinsValue = upgradeMenu.OilCapacityCoinsValue;
        
        carrierCapacityCoinsValue = upgradeMenu.CarrierCapacityCoinsValue;
        
        storageCapacityStoneValue = upgradeMenu.StorageCapacityStoneValue;
        storageCapacityWoodValue = upgradeMenu.StorageCapacityWoodValue;
        storageCapacityCoinsValue = upgradeMenu.StorageCapacityCoinsValue;
        
        mainBuildingLevelFuelValue = upgradeMenu.MainBuildingLevelFuelValue;
        mainBuildingLevelStoneValue = upgradeMenu.MainBuildingLevelStoneValue;
        mainBuildingLevelWoodValue = upgradeMenu.MainBuildingLevelWoodValue;
        mainBuildingLevelCoinsValue = upgradeMenu.MainBuildingLevelCoinsValue;
    }
}
