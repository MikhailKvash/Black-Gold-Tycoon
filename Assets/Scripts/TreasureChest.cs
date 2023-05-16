using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;

public class TreasureChest : MonoBehaviour
{
    [SerializeField] private Storage storage;
    [SerializeField] private XpRpManager xpRpManager;
    [SerializeField] private AudioManager audioManager;
    
    [SerializeField] private GameObject readyIcon;
    [SerializeField] private GameObject timerText;
    [SerializeField] private Animator treasureAnimator;
    
    [SerializeField] private GameObject resourcesDisplay;
    [SerializeField] private GameObject fuelDisplay;
    [SerializeField] private GameObject stoneDisplay;
    [SerializeField] private GameObject woodDisplay;
    [SerializeField] private GameObject coinsDisplay;
    [SerializeField] private GameObject gemsDisplay;

    private DateTime lastClicked;
    
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
            readyIcon.SetActive(true);
        }
        else
        {
            treasureAnimator.SetBool("Ready", false);
            readyIcon.SetActive(false);
        }
        
    }

    public void SetReward()
    {
        _fuelReward = Random.Range(0, 2);
        _woodReward = Random.Range(1,11);
        _stoneReward = Random.Range(1,11);
        _coinsReward = Random.Range(500,4000);
        _gemsReward = Random.Range(1,3);
    }
    
    public void GetReward()
    {
        TimeSpan timeSinceLastClicked = DateTime.Now - lastClicked;
        TimeSpan timeUntilNextClick = TimeSpan.FromDays(1) - timeSinceLastClicked;
    
        if (DateTime.Now.Date > lastClicked.Date || lastClicked == DateTime.MinValue)
        {
            StartCoroutine(ResourcesAppear());
            
            if (_fuelReward + storage.Fuel <= storage.FuelCapacity) { storage.Fuel += _fuelReward; }
            else { storage.Fuel += storage.FuelCapacity - storage.Fuel; }
            
            if (_woodReward + storage.Wood <= storage.WoodCapacity) { storage.Wood += _woodReward; }
            else { storage.Wood += storage.WoodCapacity - storage.Wood; }
            
            if (_stoneReward + storage.Stone <= storage.StoneCapacity) { storage.Stone += _stoneReward; }
            else { storage.Stone += storage.StoneCapacity - storage.Stone; }
            
            storage.Coins += _coinsReward;
            storage.Gems += _gemsReward;
            
            xpRpManager.Xp += 0.1f;
            
            lastClicked = DateTime.Now;
            PlayerPrefs.SetString("TreasureChestLastClicked", lastClicked.ToString());
            
            fuelDisplay.GetComponent<TextMeshProUGUI>().text = "" + _fuelReward;
            stoneDisplay.GetComponent<TextMeshProUGUI>().text = "" + _stoneReward;
            woodDisplay.GetComponent<TextMeshProUGUI>().text = "" + _woodReward;
            coinsDisplay.GetComponent<TextMeshProUGUI>().text = "" + _coinsReward;
            gemsDisplay.GetComponent<TextMeshProUGUI>().text = "" + _gemsReward;
            
            audioManager.Play("TreasureChest");
        }
        else
        {
            timerText.GetComponent<TextMeshProUGUI>().text = "Сундук будет доступен через " + timeUntilNextClick.ToString(@"hh\:mm\:ss");;
            timerText.GetComponent<Animation>().Play("NotEnoughTradeAnim");
            audioManager.Play("NotEnough");
        }
    }

    public void ResetTreasureTimer()
    {
        lastClicked = DateTime.MinValue;
        PlayerPrefs.SetString("TreasureChestLastClicked", lastClicked.ToString());
    }
    
    private IEnumerator ResourcesAppear ()
    {
        resourcesDisplay.SetActive(true);
        yield return new WaitForSeconds(3f);
        resourcesDisplay.SetActive(false);
        SetReward();
    }
}
