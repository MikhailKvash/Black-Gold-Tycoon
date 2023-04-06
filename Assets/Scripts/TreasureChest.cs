using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class TreasureChest : MonoBehaviour
{
    [SerializeField] private Storage storage;
    [SerializeField] private GameObject timerText;
    [SerializeField] private Animator treasureAnimator;
    
    private DateTime lastClicked;
    
    private float _oilReward;
    private float _fuelReward;
    private float _woodReward;
    private float _stoneReward;
    private float _coinsReward;
    private float _gemsReward;

    private void Start()
    {
        string lastClickedPref = PlayerPrefs.GetString("TreasureChestLastClicked", "");
        SetReward();
        
        if (lastClickedPref != "")
        {
            lastClicked = DateTime.Parse(lastClickedPref);
        }
        else
        {
            lastClicked = DateTime.MinValue;
        }
    }

    private void Update()
    {
        if (DateTime.Now.Date > lastClicked.Date)
        {
            treasureAnimator.SetBool("Ready", true);
        }
        else
        {
            treasureAnimator.SetBool("Ready", false);
        }
    }

    public void SetReward()
    {
        _oilReward = Random.Range(1,5);
        _fuelReward = Random.Range(1,5);
        _woodReward = Random.Range(1,5);
        _stoneReward = Random.Range(1,5);
        _coinsReward = Random.Range(100,2000);
        _gemsReward = Random.Range(1,3);
    }
    
    public void GetReward()
    {
        TimeSpan timeSinceLastClicked = DateTime.Now - lastClicked;
        TimeSpan timeUntilNextClick = TimeSpan.FromDays(1) - timeSinceLastClicked;

        if (DateTime.Now.Date > lastClicked.Date || lastClicked == DateTime.MinValue)
        {
            if (_oilReward + storage.Oil <= storage.OilCapacity) { storage.Oil += _oilReward; }
            else { storage.Oil += storage.OilCapacity - storage.Oil; }
            
            if (_fuelReward + storage.Fuel <= storage.FuelCapacity) { storage.Fuel += _fuelReward; }
            else { storage.Fuel += storage.FuelCapacity - storage.Fuel; }
            
            if (_woodReward + storage.Wood <= storage.WoodCapacity) { storage.Wood += _woodReward; }
            else { storage.Wood += storage.WoodCapacity - storage.Wood; }
            
            if (_stoneReward + storage.Stone <= storage.StoneCapacity) { storage.Stone += _stoneReward; }
            else { storage.Stone += storage.StoneCapacity - storage.Stone; }
            
            storage.Coins += _coinsReward;
            storage.Gems += _gemsReward;
            
            lastClicked = DateTime.Now;
            PlayerPrefs.SetString("TreasureChestLastClicked", lastClicked.ToString());
            SetReward();
        }
        else
        {
            timerText.GetComponent<TextMeshProUGUI>().text = "Сундук будет доступен через " + timeUntilNextClick.ToString(@"hh\:mm\:ss");;
            timerText.GetComponent<Animation>().Play("NotEnoughTradeAnim");
        }
    }

    public void ResetTreasureTimer()
    {
        lastClicked = DateTime.MinValue;
        PlayerPrefs.SetString("TreasureChestLastClicked", lastClicked.ToString());
    }
}
