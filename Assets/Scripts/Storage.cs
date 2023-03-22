//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Storage : MonoBehaviour
{
    // Stores resourses and shows amounts in menu.
    
    [SerializeField] private float oil;
    [SerializeField] private int fuel;
    [SerializeField] private int wood;
    [SerializeField] private int stone;
    [SerializeField] private float coins;
    [SerializeField] private int gems;

    [SerializeField] private float capacity;

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
        set => oil = value;
    }

    public float Coins
    {
        get => coins;
        set => coins = value;
    }

    public float Capacity
    {
        get => capacity;
        set => capacity = value;
    }

    public int Fuel
    {
        get => fuel;
        set => fuel = value;
    }

    public int Wood
    {
        get => wood;
        set => wood = value;
    }

    public int Stone
    {
        get => stone;
        set => stone = value;
    }

    public int Gems
    {
        get => gems;
        set => gems = value;
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
        
        capacityDisplay.GetComponent<TextMeshProUGUI>().text = capacity + " ед МАХ";

        if (oil == capacity)
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