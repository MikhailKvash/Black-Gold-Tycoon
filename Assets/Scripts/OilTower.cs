using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OilTower : MonoBehaviour
{
    // Generates oil automatically, stores it and shows amount in menu.
    
    [SerializeField] private GameObject oilDisplay;
    [SerializeField] private GameObject oilTowerLevelDisplay;
    [SerializeField] private GameObject oilTowerSpeedDisplay;
    [SerializeField] private GameObject oilTowerCapacityDisplay;
    
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private Slider oilFillSlider;
    
    [SerializeField] private float oil;
    [SerializeField] private float oilMax;
    [SerializeField] private float timeToGenerateOil;
    [SerializeField] private int oilLevel;
    
    private float _passedTimeToFillSlider;

    public float Oil
    {
        get => oil;
        set
        {
            oil = (float) Math.Round(value, 1);
        }
    }

    public float Capacity
    {
        get => oilMax;
        set => oilMax = value;
    }

    public float TimeToGenerateOil
    {
        get => timeToGenerateOil;
        set => timeToGenerateOil = value;
    }

    public int Level
    {
        get => oilLevel;
        set => oilLevel = value;
    }

    public float PassedTimeToFillSlider
    {
        get => _passedTimeToFillSlider;
        set => _passedTimeToFillSlider = value;
    }


    private void Start()
    {
        StartCoroutine(GenerateOil());
        
        if (!string.IsNullOrEmpty(saveManager.TimeWhenGameClosed))
        {
            DateTime parsingTime = DateTime.Parse(saveManager.TimeWhenGameClosed);
            TimeSpan passedTime = DateTime.Now - parsingTime;

            int generatedOil = (int) (passedTime.TotalSeconds / timeToGenerateOil);

            if (oil < oilMax)
            {
                if (oil + generatedOil > oilMax)
                {
                    oil = oilMax;
                }
                else
                {
                    oil += generatedOil;
                }
            }
        }
    }

    private void Update()
    {
        FillSlider();
        _passedTimeToFillSlider += Time.deltaTime;
        if (_passedTimeToFillSlider >= timeToGenerateOil)
        {
            _passedTimeToFillSlider = 0;
        }

        oilDisplay.GetComponent<TextMeshProUGUI>().text = "Нефть в вышке: " + oil + " / " + oilMax;
        oilTowerLevelDisplay.GetComponent<TextMeshProUGUI>().text = oilLevel + " ";
        oilTowerSpeedDisplay.GetComponent<TextMeshProUGUI>().text = oilLevel + " ед в " + timeToGenerateOil + " секунд";
        oilTowerCapacityDisplay.GetComponent<TextMeshProUGUI>().text = "Хранилище: " + oilMax;
    }

    public void TakeOil(float value)
    {
        oil -= value;
    }

    public void ClickOil()
    {
        if (oil < oilMax)
        {
            audioManager.Play("ClickOil");
            Oil += 0.1f;
        }
    }

    private void FillSlider()
    {
        oilFillSlider.value = _passedTimeToFillSlider/timeToGenerateOil;
    }

    private IEnumerator GenerateOil()
    {
        yield return new WaitForSeconds(timeToGenerateOil);
        
        if (oil == oilMax)
        {
            oil += 0;
        }
        if (oil < oilMax)
        {
            if (oil + oilLevel > oilMax)
            {
                oil = oilMax;
            }
            else
            {
                oil += oilLevel;
            }
        }
        StartCoroutine(GenerateOil()); 
    }
}
