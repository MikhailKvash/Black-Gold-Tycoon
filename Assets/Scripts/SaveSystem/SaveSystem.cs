using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveStorage(Storage storage)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/storage.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        StorageData data = new StorageData(storage);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static void SaveOilTower(OilTower oilTower)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/oilTower.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        OilTowerData data = new OilTowerData(oilTower);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static void SaveMainBuilding(MainBuilding mainBuilding)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/mainBuilding.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        MainBuildingData data = new MainBuildingData(mainBuilding);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static void SaveOilVillager(OilVillager oilVillager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/oilVillager.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        OilVillagerData data = new OilVillagerData(oilVillager);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static void SaveShipVillager(ShipVillager shipVillager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/shipVillager.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        ShipVillagerData data = new ShipVillagerData(shipVillager);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static void SaveShip(ShipMovement ship)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/ship.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        ShipData data = new ShipData(ship);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static void SaveTradeMenu(TradeMenu tradeMenu)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/tradeMenu.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        TradeMenuData data = new TradeMenuData(tradeMenu);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static void SaveUpgradeMenu(UpgradeMenu upgradeMenu)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/upgradeMenu.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        UpgradeMenuData data = new UpgradeMenuData(upgradeMenu);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static void SaveTimeManager(TimeManager timeManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/timeManager.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        TimeManagerData data = new TimeManagerData(timeManager);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static void SaveSaveManager(SaveManager saveManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveManager.sav";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        SaveManagerData data = new SaveManagerData(saveManager);
        
        formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static StorageData LoadStorage()
    {
        string path = Application.persistentDataPath + "/storage.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            StorageData data = formatter.Deserialize(stream) as StorageData;

            stream.Close();
            return data;
        } else {return null;}
    }
    
    public static OilTowerData LoadOilTower()
    {
        string path = Application.persistentDataPath + "/oilTower.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            OilTowerData data = formatter.Deserialize(stream) as OilTowerData;

            stream.Close();
            return data;
        } else {return null;}
    }
    
    public static MainBuildingData LoadMainBuilding()
    {
        string path = Application.persistentDataPath + "/mainBuilding.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            MainBuildingData data = formatter.Deserialize(stream) as MainBuildingData;

            stream.Close();
            return data;
        } else {return null;}
    }
    
    public static OilVillagerData LoadOilVillager()
    {
        string path = Application.persistentDataPath + "/oilVillager.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            OilVillagerData data = formatter.Deserialize(stream) as OilVillagerData;

            stream.Close();
            return data;
        } else {return null;}
    }
    
    public static ShipVillagerData LoadShipVillager()
    {
        string path = Application.persistentDataPath + "/shipVillager.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ShipVillagerData data = formatter.Deserialize(stream) as ShipVillagerData;

            stream.Close();
            return data;
        } else {return null;}
    }
    
    public static ShipData LoadShip()
    {
        string path = Application.persistentDataPath + "/ship.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ShipData data = formatter.Deserialize(stream) as ShipData;

            stream.Close();
            return data;
        } else {return null;}
    }
    
    public static TradeMenuData LoadTradeMenu()
    {
        string path = Application.persistentDataPath + "/tradeMenu.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            TradeMenuData data = formatter.Deserialize(stream) as TradeMenuData;

            stream.Close();
            return data;
        } else {return null;}
    }
    
    public static UpgradeMenuData LoadUpgradeMenu()
    {
        string path = Application.persistentDataPath + "/upgradeMenu.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            UpgradeMenuData data = formatter.Deserialize(stream) as UpgradeMenuData;

            stream.Close();
            return data;
        } else {return null;}
    }
    
    public static TimeManagerData LoadTimeManager()
    {
        string path = Application.persistentDataPath + "/timeManager.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            TimeManagerData data = formatter.Deserialize(stream) as TimeManagerData;

            stream.Close();
            return data;
        } else {return null;}
    }
    
    public static SaveManagerData LoadSaveManager()
    {
        string path = Application.persistentDataPath + "/saveManager.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveManagerData data = formatter.Deserialize(stream) as SaveManagerData;

            stream.Close();
            return data;
        } else {return null;}
    }
}
