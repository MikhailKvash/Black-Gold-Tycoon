using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private Storage storage;
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private TradeMenu tradeMenu;
    [SerializeField] private AudioManager audioManager;
    
    [SerializeField] private GameObject timeLeftDisplay;
    [SerializeField] private GameObject notEnoughMessage;
    [SerializeField] private GameObject returnShipButton;
    
    [SerializeField] private float timeLeft;
    [SerializeField] private float neededTime;
    [SerializeField] private float passedTime;
    [SerializeField] private bool takingAway;

    #region Public links
    public float TimeLeft
    {
        get => timeLeft;
        set => timeLeft = value;
    }
    public float NeededTime
    {
        get => neededTime;
        set => neededTime = value;
    }
    public float PassedTime
    {
        get => passedTime;
        set => passedTime = value;
    }
    public bool TakingAway
    {
        get => takingAway;
        set => takingAway = value;
    }
    #endregion
    
    private void Start()
    {
        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);
        
        StartCoroutine(ShipTimer());
        
        timeLeftDisplay.GetComponent<TextMeshProUGUI>().text = string.Format("Корабль вернётся через {0:00}:{1:00}", minutes, seconds);
        
        if (!string.IsNullOrEmpty(saveManager.TimeWhenGameClosed))
        {
            DateTime parsingTime = DateTime.Parse(saveManager.TimeWhenGameClosed);
            TimeSpan passedSinceClosingTime = DateTime.Now - parsingTime;

            float passedSinceClosingShipTime = (float) passedSinceClosingTime.TotalSeconds + 0;

            if (timeLeft <= passedSinceClosingTime.TotalSeconds)
            {
                EndShipTimerOnStart();
            }
            else
            {
                timeLeft -= passedSinceClosingShipTime;
                passedTime += passedSinceClosingShipTime;
            }
        }
    }

    private void Update()
    {
        if (!takingAway && timeLeft > 0)
        {
            StartCoroutine(ShipTimer());
        }

        if (timeLeft <= 0)
        {
            returnShipButton.SetActive(false);
        }
        else
        {
            returnShipButton.SetActive(true);
        }
    }

    public void StartShipTimer()
    {
        if (tradeMenu.OilAmount <= 5)
        {
            timeLeft += 180;
            neededTime = 180;
        }
        else if (tradeMenu.OilAmount > 5 && tradeMenu.OilAmount <= 20)
        {
            timeLeft += 360;
            neededTime = 360;
        }
        else if (tradeMenu.OilAmount > 20 && tradeMenu.OilAmount <= 50)
        {
            timeLeft += 720;
            neededTime = 720;
        }
        else if (tradeMenu.OilAmount > 50)
        {
            timeLeft += 1080;
            neededTime = 1080;
        }
        
        StartCoroutine(ShipTimer());
    }

    public void EndShipTimer()
    {
        if (storage.Gems >= 1)
        {
            timeLeft = 0;
            passedTime = neededTime;
            storage.Gems -= 1;
        }
        else
        {
            notEnoughMessage.GetComponent<TextMeshProUGUI>().text = "Недостаточно ресурсов!";
            notEnoughMessage.GetComponent<Animation>().Play("NotEnoughTradeAnim");
            audioManager.Play("NotEnough");
        }
    }
    
    void EndShipTimerOnStart()
    {
        timeLeft = 0;
        passedTime = neededTime;
    }

    IEnumerator ShipTimer()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        timeLeft -= 1;
        if (timeLeft >= 0)
        {
            if (passedTime >= neededTime)
            {
                passedTime = neededTime;
            }
            else
            {
                passedTime += 1; 
            }
        }
        
        if (timeLeft < 0)
        {
            timeLeft = 0;
        }

        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);

        if (timeLeft <= 0)
        {
            timeLeftDisplay.GetComponent<TextMeshProUGUI>().text = "Корабль подходит к берегу!";
        }
        else
        {
            timeLeftDisplay.GetComponent<TextMeshProUGUI>().text = string.Format("Корабль вернётся через {0:00}:{1:00}", minutes, seconds);
        }
        takingAway = false;
    }
}
