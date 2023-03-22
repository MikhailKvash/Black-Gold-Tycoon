[System.Serializable]
public class UpgradeMenuData
{
    public int oilLevelValue;
    public int oilCapacityValue;
    public int carrierSpeedValue;
    public int carrierCapacityValue;
    public int storageCapacityValue;
    public int mainBuildingLevelValue;

    public UpgradeMenuData(UpgradeMenu upgradeMenu)
    {
        oilLevelValue = upgradeMenu.OilLevelValue;
        oilCapacityValue = upgradeMenu.OilCapacityValue;
        carrierSpeedValue = upgradeMenu.CarrierSpeedValue;
        carrierCapacityValue = upgradeMenu.CarrierCapacityValue;
        storageCapacityValue = upgradeMenu.StorageCapacityValue;
        mainBuildingLevelValue = upgradeMenu.MainBuildingLevelValue;
    }
}
