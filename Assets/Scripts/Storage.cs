using System;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Storage : MonoBehaviour
{
    // Stores resourses and shows amounts in menu.
    
    [SerializeField] private float oil;
    [SerializeField] private float fuel;
    [SerializeField] private float wood;
    [SerializeField] private float stone;
    [SerializeField] private float coins;
    [SerializeField] private float gems;

    [SerializeField] private float oilCapacity;
    [SerializeField] private float fuelCapacity;
    [SerializeField] private float woodCapacity;
    [SerializeField] private float stoneCapacity;

    [SerializeField] private GameObject fuelDisplay;
    [SerializeField] private GameObject oilDisplay;
    [SerializeField] private GameObject stoneDisplay;
    [SerializeField] private GameObject woodDisplay;
    [SerializeField] private GameObject coinsDisplay;
    [SerializeField] private GameObject gemsDisplay;
    
    [SerializeField] private GameObject fuelStorageDisplay;
    [SerializeField] private GameObject oilStorageDisplay;
    [SerializeField] private GameObject stoneStorageDisplay;
    [SerializeField] private GameObject woodStorageDisplay;
    [SerializeField] private GameObject coinsStorageDisplay;
    [SerializeField] private GameObject gemsStorageDisplay;
    
    [SerializeField] private GameObject capacityDisplay;

    private bool _oilCapacityFull;

    public float Oil
    {
        get => oil;
        set
        {
            oil = (float) Math.Round(value, 1);
        }
    }
    
    public float Fuel
    {
        get => fuel;
        set => fuel = value;
    }
    
    public float Wood
    {
        get => wood;
        set => wood = value;
    }

    public float Stone
    {
        get => stone;
        set => stone = value;
    }
    
    public float Coins
    {
        get => coins;
        set => coins = value;
    }

    public float Gems
    {
        get => gems;
        set => gems = value;
    }
    
    public float OilCapacity
    {
        get => oilCapacity;
        set => oilCapacity = value;
    }

    public float FuelCapacity
    {
        get => fuelCapacity;
        set => fuelCapacity = value;
    }

    public float WoodCapacity
    {
        get => woodCapacity;
        set => woodCapacity = value;
    }

    public float StoneCapacity
    {
        get => stoneCapacity;
        set => stoneCapacity = value;
    }

    public bool OilFull => _oilCapacityFull;

    private void Update()
    {
        fuelDisplay.GetComponent<TextMeshProUGUI>().text = fuel.ToString();
        oilDisplay.GetComponent<TextMeshProUGUI>().text = oil.ToString();
        stoneDisplay.GetComponent<TextMeshProUGUI>().text = stone.ToString();
        woodDisplay.GetComponent<TextMeshProUGUI>().text = wood.ToString();
        coinsDisplay.GetComponent<TextMeshProUGUI>().text = coins.ToString();
        gemsDisplay.GetComponent<TextMeshProUGUI>().text = gems.ToString();
        
        fuelStorageDisplay.GetComponent<TextMeshProUGUI>().text = fuel.ToString();
        oilStorageDisplay.GetComponent<TextMeshProUGUI>().text = oil.ToString();
        stoneStorageDisplay.GetComponent<TextMeshProUGUI>().text = stone.ToString();
        woodStorageDisplay.GetComponent<TextMeshProUGUI>().text = wood.ToString();
        coinsStorageDisplay.GetComponent<TextMeshProUGUI>().text = coins.ToString();
        gemsStorageDisplay.GetComponent<TextMeshProUGUI>().text = gems.ToString();
        
        capacityDisplay.GetComponent<TextMeshProUGUI>().text = oilCapacity + " ед МАХ";

        if (oil == oilCapacity)
        {
            _oilCapacityFull = true;
        }
        else
        {
            _oilCapacityFull = false;
        }
    }
    
    public void StoreOil(float value)
    {
        oil += value;
    }
}