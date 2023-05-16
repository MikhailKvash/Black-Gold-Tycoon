using UnityEngine;
using TMPro;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private GameObject notEnoughMessage;

    [SerializeField] private GameObject oilLevelStoneDisplay;
    [SerializeField] private GameObject oilLevelWoodDisplay;
    [SerializeField] private GameObject oilLevelCoinsDisplay;
    
    [SerializeField] private GameObject oilCapacityCoinsDisplay;
    
    [SerializeField] private GameObject carrierCapacityCoinsDisplay;
    
    [SerializeField] private GameObject storageCapacityStoneDisplay;
    [SerializeField] private GameObject storageCapacityWoodDisplay;
    [SerializeField] private GameObject storageCapacityCoinsDisplay;
    
    [SerializeField] private GameObject upgradeStorageCapacityButton;
    [SerializeField] private GameObject upgradeStorageCapacityText;
    [SerializeField] private GameObject storageStoneValueIcon;
    [SerializeField] private GameObject storageWoodValueIcon;
    [SerializeField] private GameObject storageCoinsValueIcon;
    
    [SerializeField] private GameObject MainBuildingLevelFuelDisplay;
    [SerializeField] private GameObject MainBuildingLevelStoneDisplay;
    [SerializeField] private GameObject MainBuildingLevelWoodDisplay;
    [SerializeField] private GameObject MainBuildingLevelCoinsDisplay;

    [SerializeField] private OilTower oilTower;
    [SerializeField] private OilVillager oilCarrier;
    [SerializeField] private Storage storage;
    [SerializeField] private MainBuilding mainBuilding;
    [SerializeField] private XpRpManager xpRpManager;

    [SerializeField] private AudioManager audioManager;

    private int _oilLevelStoneValue = 4;
    private int _oilLevelWoodValue = 2;
    private int _oilLevelCoinsValue = 2000;

    private int _oilCapacityCoinsValue = 1000;
    
    private int _carrierCapacityCoinsValue = 1000;
    
    private int _storageCapacityStoneValue = 4;
    private int _storageCapacityWoodValue = 3;
    private int _storageCapacityCoinsValue = 1500;
    
    private int _mainBuildingLevelFuelValue = 2;
    private int _mainBuildingLevelStoneValue = 4;
    private int _mainBuildingLevelWoodValue = 4;
    private int _mainBuildingLevelCoinsValue = 2500;

    #region Public links
    public int OilLevelStoneValue
    {
        get => _oilLevelStoneValue;
        set => _oilLevelStoneValue = value;
    }
    public int OilLevelWoodValue
    {
        get => _oilLevelWoodValue;
        set => _oilLevelWoodValue = value;
    }
    public int OilLevelCoinsValue
    {
        get => _oilLevelCoinsValue;
        set => _oilLevelCoinsValue = value;
    }
    public int OilCapacityCoinsValue
    {
        get => _oilCapacityCoinsValue;
        set => _oilCapacityCoinsValue = value;
    }
    public int CarrierCapacityCoinsValue
    {
        get => _carrierCapacityCoinsValue;
        set => _carrierCapacityCoinsValue = value;
    }
    public int StorageCapacityStoneValue
    {
        get => _storageCapacityStoneValue;
        set => _storageCapacityStoneValue = value;
    }
    public int StorageCapacityWoodValue
    {
        get => _storageCapacityWoodValue;
        set => _storageCapacityWoodValue = value;
    }
    public int StorageCapacityCoinsValue
    {
        get => _storageCapacityCoinsValue;
        set => _storageCapacityCoinsValue = value;
    }
    public int MainBuildingLevelFuelValue
    {
        get => _mainBuildingLevelFuelValue;
        set => _mainBuildingLevelFuelValue = value;
    }
    public int MainBuildingLevelStoneValue
    {
        get => _mainBuildingLevelStoneValue;
        set => _mainBuildingLevelStoneValue = value;
    }
    public int MainBuildingLevelWoodValue
    {
        get => _mainBuildingLevelWoodValue;
        set => _mainBuildingLevelWoodValue = value;
    }
    public int MainBuildingLevelCoinsValue
    {
        get => _mainBuildingLevelCoinsValue;
        set => _mainBuildingLevelCoinsValue = value;
    }
    #endregion

    private void Update()
    {
        if (storage.OilCapacity < 80)
        {
            upgradeStorageCapacityText.GetComponent<TextMeshProUGUI>().text = "Улучшить хранилище";
            storageCapacityStoneDisplay.GetComponent<TextMeshProUGUI>().text = "" + _storageCapacityStoneValue;
            storageCapacityWoodDisplay.GetComponent<TextMeshProUGUI>().text = "" + _storageCapacityWoodValue;
            storageCapacityCoinsDisplay.GetComponent<TextMeshProUGUI>().text = "" + _storageCapacityCoinsValue;
        }
        else
        {
            upgradeStorageCapacityText.GetComponent<TextMeshProUGUI>().text = "Максимальное хранилище!";
            upgradeStorageCapacityButton.SetActive(false);
            storageStoneValueIcon.SetActive(false);
            storageWoodValueIcon.SetActive(false);
            storageCoinsValueIcon.SetActive(false);
        }

        oilLevelStoneDisplay.GetComponent<TextMeshProUGUI>().text = "" + _oilLevelStoneValue;
        oilLevelWoodDisplay.GetComponent<TextMeshProUGUI>().text = "" + _oilLevelWoodValue;
        oilLevelCoinsDisplay.GetComponent<TextMeshProUGUI>().text = "" + _oilLevelCoinsValue;
        
        oilCapacityCoinsDisplay.GetComponent<TextMeshProUGUI>().text = "" + _oilCapacityCoinsValue;
        
        carrierCapacityCoinsDisplay.GetComponent<TextMeshProUGUI>().text = "" + _carrierCapacityCoinsValue;
        
        MainBuildingLevelFuelDisplay.GetComponent<TextMeshProUGUI>().text = "" + _mainBuildingLevelFuelValue;
        MainBuildingLevelStoneDisplay.GetComponent<TextMeshProUGUI>().text = "" + _mainBuildingLevelStoneValue;
        MainBuildingLevelWoodDisplay.GetComponent<TextMeshProUGUI>().text = "" + _mainBuildingLevelWoodValue;
        MainBuildingLevelCoinsDisplay.GetComponent<TextMeshProUGUI>().text = "" + _mainBuildingLevelCoinsValue;
    }

    public void UpgradeOilLevel()
    {
        if (storage.Stone >= _oilLevelStoneValue && storage.Wood >= _oilLevelWoodValue && storage.Coins >= _oilLevelCoinsValue)
        {
            storage.Stone -= _oilLevelStoneValue;
            storage.Wood -= _oilLevelWoodValue;
            storage.Coins -= _oilLevelCoinsValue;
            _oilLevelStoneValue *= 2;
            _oilLevelWoodValue *= 2;
            _oilLevelCoinsValue *= 2;
            
            oilTower.Level += 1;
            xpRpManager.Xp += 0.3f;
            xpRpManager.Rp += 0.6f;
            audioManager.Play("Upgrade");
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "Недостаточно ресурсов!";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
            audioManager.Play("NotEnough");
        }
    }
    
    public void UpgradeOilCapacity()
    {
        if (storage.Coins >= _oilCapacityCoinsValue)
        {
            storage.Coins -= _oilCapacityCoinsValue;
            _oilCapacityCoinsValue *= 2;
            
            oilTower.Capacity += 10;
            xpRpManager.Xp += 0.3f;
            xpRpManager.Rp += 0.6f;
            audioManager.Play("Upgrade");
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "Недостаточно ресурсов!";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
            audioManager.Play("NotEnough");
        }
    }

    public void UpgradeCarrierCapacity()
    {
        if (storage.Coins >= _carrierCapacityCoinsValue)
        {
            storage.Coins -= _carrierCapacityCoinsValue;
            _carrierCapacityCoinsValue *= 2;
            
            oilCarrier.Capacity += 1;
            xpRpManager.Xp += 0.3f;
            xpRpManager.Rp += 0.6f;
            audioManager.Play("Upgrade");
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "Недостаточно ресурсов!";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
            audioManager.Play("NotEnough");
        }
    }

    public void UpgradeStorageCapacity()
    {
        if (storage.Stone >= _storageCapacityStoneValue && storage.Wood >= _storageCapacityWoodValue && 
            storage.Coins >= _storageCapacityCoinsValue || storage.OilCapacity == 80)
        {
            storage.Stone -= _storageCapacityStoneValue;
            storage.Wood -= _storageCapacityWoodValue;
            storage.Coins -= _storageCapacityCoinsValue;
            _storageCapacityStoneValue *= 2;
            _storageCapacityWoodValue *= 2;
            _storageCapacityCoinsValue *= 2;
            
            storage.OilCapacity += 10;
            storage.FuelCapacity += 10;
            storage.WoodCapacity += 10;
            storage.StoneCapacity += 10;
            xpRpManager.Xp += 0.3f;
            xpRpManager.Rp += 0.6f;
            audioManager.Play("Upgrade");
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "Недостаточно ресурсов!";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
            audioManager.Play("NotEnough");
        }
    }
    
    public void UpgradeMainBuildingLevel()
    {
        if (storage.Fuel >= _mainBuildingLevelFuelValue && storage.Stone >= _mainBuildingLevelStoneValue &&
            storage.Wood >= _mainBuildingLevelWoodValue && storage.Coins >= _mainBuildingLevelCoinsValue)
        {
            storage.Fuel -= _mainBuildingLevelFuelValue;
            storage.Stone -= _mainBuildingLevelStoneValue;
            storage.Wood -= _mainBuildingLevelWoodValue;
            storage.Coins -= _mainBuildingLevelCoinsValue;
            _mainBuildingLevelFuelValue *= 2;
            _mainBuildingLevelStoneValue *= 2;
            _mainBuildingLevelWoodValue *= 2;
            _mainBuildingLevelCoinsValue *= 2;
            
            mainBuilding.Level += 1;
            xpRpManager.RpLvl += 2f;
            xpRpManager.PlayRpUp();
            audioManager.Play("Upgrade");
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "Недостаточно ресурсов!";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
            audioManager.Play("NotEnough");
        }
    }
}
