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
    [SerializeField] private TradeMenu tradeMenu;
    [SerializeField] private UpgradeMenu upgradeMenu;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private SaveManager saveManager;

    [SerializeField] private GameObject noLoadingText;
    private int _noLoadingPref;
    private string _timeWhenGameClosed;
    private bool _noLoading;

    public string TimeWhenGameClosed
    {
        get => _timeWhenGameClosed;
        set => _timeWhenGameClosed = value;
    }

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
        SaveSystem.SaveTradeMenu(tradeMenu);
        SaveSystem.SaveUpgradeMenu(upgradeMenu);
        SaveSystem.SaveTimeManager(timeManager);
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
        TradeMenuData tradeMenuData = SaveSystem.LoadTradeMenu();
        UpgradeMenuData upgradeMenuData = SaveSystem.LoadUpgradeMenu();
        TimeManagerData timeManagerData = SaveSystem.LoadTimeManager();
        SaveManagerData saveManagerData = SaveSystem.LoadSaveManager();
        

        storage.Oil = storageData.oil;
        storage.Fuel = storageData.fuel;
        storage.Stone = storageData.stone;
        storage.Wood = storageData.wood;
        storage.Gems = storageData.gems;
        storage.Coins = storageData.coins;
        storage.OilCapacity = storageData.capacity;

        oilTower.Oil = oilTowerData.oil;
        oilTower.Capacity = oilTowerData.capacity;
        oilTower.TimeToGenerateOil = oilTowerData.timeToGenerateOil;
        oilTower.Level = oilTowerData.level;
        oilTower.PassedTimeToFillSlider = oilTowerData.passedTimeToFillSlider;
        
        mainBuilding.Level = mainBuildingData.level;

        oilVillager.CarryingOil = oilVillagerData.carryingOil;
        oilVillager.Speed = oilVillagerData.speed;
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

        tradeMenu.OilAmount = tradeMenuData.oil;
        tradeMenu.ProfitCoins = tradeMenuData.coins;
        tradeMenu.ShipAway = tradeMenuData.shipAway;
        tradeMenu.CargoWaiting = tradeMenuData.cargoWaiting;
        tradeMenu.SendShipButtonOff = tradeMenuData.sendShipButtonOff;

        upgradeMenu.OilLevelValue = upgradeMenuData.oilLevelValue;
        upgradeMenu.OilCapacityValue = upgradeMenuData.oilCapacityValue;
        upgradeMenu.CarrierSpeedValue = upgradeMenuData.carrierSpeedValue;
        upgradeMenu.CarrierCapacityValue = upgradeMenuData.carrierCapacityValue;
        upgradeMenu.StorageCapacityValue = upgradeMenuData.storageCapacityValue;
        upgradeMenu.MainBuildingLevelValue = upgradeMenuData.mainBuildingLevelValue;

        timeManager.TimeLeft = timeManagerData.timeLeft;
        timeManager.NeededTime = timeManagerData.neededTime;
        timeManager.PassedTime = timeManagerData.passedTime;
        timeManager.TakingAway = timeManagerData.takingAway;

        saveManager.TimeWhenGameClosed = saveManagerData.timeWhenGameClosed;
    }
}
