using System;
using TMPro;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Storage storage;
    [SerializeField] private OilTower oilTower;
    [SerializeField] private MainBuilding mainBuilding;
    [SerializeField] private OilVillager oilVillager;
    [SerializeField] private ShipVillager shipVillager;
    [SerializeField] private ShipMovement ship;
    [SerializeField] private ResourceShip resourceShip;
    [SerializeField] private TradeMenu tradeMenu;
    [SerializeField] private BuyingMenu buyingMenu;
    [SerializeField] private UpgradeMenu upgradeMenu;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private DeliverResourcesTimer resourcesTimer;
    [SerializeField] private XpRpManager xpRpManager;
    [SerializeField] private SaveManager saveManager;

    [SerializeField] private GameObject noLoadingText;
    private int _noLoadingPref;
    private string _timeWhenGameClosed;
    private bool _noLoading;

    #region Public links
    public string TimeWhenGameClosed
    {
        get => _timeWhenGameClosed;
        set => _timeWhenGameClosed = value;
    }
    #endregion

    private void Start()
    {
        _noLoadingPref = PlayerPrefs.GetInt("NoLoading");

        if (_noLoadingPref == 1) {_noLoading = true;}
        if (_noLoadingPref == 0) {_noLoading = false;}
        
        if (!_noLoading) {LoadProgress();}
    }

    private void Update()
    {
        if (_noLoading)
        {
            noLoadingText.GetComponent<TextMeshProUGUI>().text = "Не загружать";
        }
        else
        {
            noLoadingText.GetComponent<TextMeshProUGUI>().text = "Загружать";
        }
    }

    public void LoadOrNo()
    {
        if (!_noLoading)
        {
            _noLoading = true;
            PlayerPrefs.SetInt("NoLoading", 1);
        }
        else
        {
            _noLoading = false;
            PlayerPrefs.SetInt("NoLoading", 0);
        }
    }

    private void OnApplicationPause(bool isPaused)
    {
        if (isPaused)
        {
            _timeWhenGameClosed = DateTime.Now.ToString();
            SaveProgress();
        }
    }

    private void OnApplicationQuit()
    {
        _timeWhenGameClosed = DateTime.Now.ToString();
        SaveProgress();
    }

    public void SaveProgress()
    {
        SaveSystem.SaveStorage(storage);
        SaveSystem.SaveOilTower(oilTower);
        SaveSystem.SaveMainBuilding(mainBuilding);
        SaveSystem.SaveOilVillager(oilVillager);
        SaveSystem.SaveShipVillager(shipVillager);
        SaveSystem.SaveShip(ship);
        SaveSystem.SaveResourceShip(resourceShip);
        SaveSystem.SaveTradeMenu(tradeMenu);
        SaveSystem.SaveBuyingMenu(buyingMenu);
        SaveSystem.SaveUpgradeMenu(upgradeMenu);
        SaveSystem.SaveTimeManager(timeManager);
        SaveSystem.SaveDeliverResourcesTimer(resourcesTimer);
        SaveSystem.SaveXpRpManager(xpRpManager);
        SaveSystem.SaveSaveManager(saveManager);
    }

    public void LoadProgress()
    {
        StorageData storageData = SaveSystem.LoadStorage();
        OilTowerData oilTowerData = SaveSystem.LoadOilTower();
        MainBuildingData mainBuildingData = SaveSystem.LoadMainBuilding();
        OilVillagerData oilVillagerData = SaveSystem.LoadOilVillager();
        ShipVillagerData shipVillagerData = SaveSystem.LoadShipVillager();
        ShipData shipData = SaveSystem.LoadShip();
        ResourceShipData resourceShipData = SaveSystem.LoadResourceShip();
        TradeMenuData tradeMenuData = SaveSystem.LoadTradeMenu();
        BuyingMenuData buyingMenuData = SaveSystem.LoadBuyingMenu();
        UpgradeMenuData upgradeMenuData = SaveSystem.LoadUpgradeMenu();
        TimeManagerData timeManagerData = SaveSystem.LoadTimeManager();
        ResourcesTimerData resourcesTimerData = SaveSystem.LoadDeliverResourcesTimer();
        XpRpData xpRpData = SaveSystem.LoadXpRpManager();
        SaveManagerData saveManagerData = SaveSystem.LoadSaveManager();
        

        storage.Oil = storageData.oil;
        storage.Fuel = storageData.fuel;
        storage.Stone = storageData.stone;
        storage.Wood = storageData.wood;
        storage.Gems = storageData.gems;
        storage.Coins = storageData.coins;
        storage.OilCapacity = storageData.oilCapacity;
        storage.FuelCapacity = storageData.fuelCapacity;
        storage.WoodCapacity = storageData.woodCapacity;
        storage.StoneCapacity = storageData.stoneCapacity;

        oilTower.Oil = oilTowerData.oil;
        oilTower.Capacity = oilTowerData.capacity;
        oilTower.TimeToGenerateOil = oilTowerData.timeToGenerateOil;
        oilTower.Level = oilTowerData.level;
        oilTower.PassedTimeToFillSlider = oilTowerData.passedTimeToFillSlider;
        
        mainBuilding.Level = mainBuildingData.level;

        oilVillager.CarryingOil = oilVillagerData.carryingOil;
        oilVillager.Capacity = oilVillagerData.capacity;
        oilVillager.TakeOilOnce = oilVillagerData.takeOilOnce;
        oilVillager.DropOilOnce = oilVillagerData.dropOilOnce;
        oilVillager.Box = oilVillagerData.box;
        Vector3 oilVillagerPosition;
        oilVillagerPosition.x = oilVillagerData.position[0];
        oilVillagerPosition.y = oilVillagerData.position[1];
        oilVillagerPosition.z = oilVillagerData.position[2];
        oilVillager.transform.position = oilVillagerPosition;

        shipVillager.SingleDelivery = shipVillagerData.singleDelivery;
        shipVillager.CarryingCargo = shipVillagerData.carryingCargo;
        shipVillager.TookCargo = shipVillagerData.tookCargo;
        shipVillager.Box = shipVillagerData.box;
        Vector3 shipVillagerPosition;
        shipVillagerPosition.x = shipVillagerData.position[0];
        shipVillagerPosition.y = shipVillagerData.position[1];
        shipVillagerPosition.z = shipVillagerData.position[2];
        shipVillager.transform.position = shipVillagerPosition;
        
        ship.SingleDelivery = shipData.singleDelivery;
        ship.ReadyToReturnToDocks = shipData.readyToReturnToDocks;
        ship.GoingAway = shipData.goingAway;
        ship.GoingToLastPoint = shipData.goingToLastPoint;
        ship.GoingDocks = shipData.goingDocks;
        Vector3 shipPosition;
        shipPosition.x = shipData.position[0];
        shipPosition.y = shipData.position[1];
        shipPosition.z = shipData.position[2];
        ship.transform.position = shipPosition;

        resourceShip.SingleDelivery = resourceShipData.singleDelivery;
        resourceShip.GoingAway = resourceShipData.goingAway;
        resourceShip.GoingDocks = resourceShipData.goingDocks;
        resourceShip.IsWaiting = resourceShipData.isWaiting;
        Vector3 resourceShipPosition;
        resourceShipPosition.x = resourceShipData.position[0];
        resourceShipPosition.y = resourceShipData.position[1];
        resourceShipPosition.z = resourceShipData.position[2];
        resourceShip.transform.position = resourceShipPosition;

        tradeMenu.OilSliderAmount = tradeMenuData.oilSlider;
        tradeMenu.OilAmount = tradeMenuData.oilAmount;
        tradeMenu.ProfitCoins = tradeMenuData.coins;
        tradeMenu.ShipAway = tradeMenuData.shipAway;
        tradeMenu.SentForCargo = tradeMenuData.sentForCargo;
        tradeMenu.SendShipButtonOff = tradeMenuData.sendShipButtonOff;
        tradeMenu.SliderHandleOff = tradeMenuData.sliderHandleOff;

        buyingMenu.CoinsLeft = buyingMenuData.coinsLeft;
        buyingMenu.OrderCost = buyingMenuData.orderCost;
        buyingMenu.Stone = buyingMenuData.stone;
        buyingMenu.Fuel = buyingMenuData.fuel;
        buyingMenu.Wood = buyingMenuData.wood;
        buyingMenu.TotalOrderAmount = buyingMenuData.totalOrderAmount;
        buyingMenu.ToggleNumber = buyingMenuData.toggleNumber;
        buyingMenu.StoneToggle = buyingMenuData.stoneToggle;
        buyingMenu.FuelToggle = buyingMenuData.fuelToggle;
        buyingMenu.WoodToggle = buyingMenuData.woodToggle;
        buyingMenu.ResourcesOrdered = buyingMenuData.resourcesOrdered;

        upgradeMenu.OilLevelStoneValue = upgradeMenuData.oilLevelStoneValue;
        upgradeMenu.OilLevelWoodValue = upgradeMenuData.oilLevelWoodValue;
        upgradeMenu.OilLevelCoinsValue = upgradeMenuData.oilLevelCoinsValue;
        upgradeMenu.OilCapacityCoinsValue = upgradeMenuData.oilCapacityCoinsValue;
        upgradeMenu.CarrierCapacityCoinsValue = upgradeMenuData.carrierCapacityCoinsValue;
        upgradeMenu.StorageCapacityStoneValue = upgradeMenuData.storageCapacityStoneValue;
        upgradeMenu.StorageCapacityWoodValue = upgradeMenuData.storageCapacityWoodValue;
        upgradeMenu.StorageCapacityCoinsValue = upgradeMenuData.storageCapacityCoinsValue;
        upgradeMenu.MainBuildingLevelFuelValue = upgradeMenuData.mainBuildingLevelFuelValue;
        upgradeMenu.MainBuildingLevelStoneValue = upgradeMenuData.mainBuildingLevelStoneValue;
        upgradeMenu.MainBuildingLevelWoodValue = upgradeMenuData.mainBuildingLevelWoodValue;
        upgradeMenu.MainBuildingLevelCoinsValue = upgradeMenuData.mainBuildingLevelCoinsValue;

        timeManager.TimeLeft = timeManagerData.timeLeft;
        timeManager.NeededTime = timeManagerData.neededTime;
        timeManager.PassedTime = timeManagerData.passedTime;
        timeManager.TakingAway = timeManagerData.takingAway;

        resourcesTimer.TimeLeft = resourcesTimerData.timeLeft;
        resourcesTimer.NeededTime = resourcesTimerData.neededTime;
        resourcesTimer.PassedTime = resourcesTimerData.passedTime;
        resourcesTimer.TakingAway = resourcesTimerData.takingAway;
        resourcesTimer.TimeIsDisplaying = resourcesTimerData.timeIsDisplaying;

        xpRpManager.Xp = xpRpData.xp;
        xpRpManager.Rp = xpRpData.rp;
        xpRpManager.XpLvl = xpRpData.xpLvl;
        xpRpManager.RpLvl = xpRpData.rpLvl;

        saveManager.TimeWhenGameClosed = saveManagerData.timeWhenGameClosed;
    }
}
