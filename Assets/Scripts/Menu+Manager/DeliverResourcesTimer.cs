using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DeliverResourcesTimer : MonoBehaviour
{
    [SerializeField] private Storage storage;
    [SerializeField] private SaveManager saveManager;
    [SerializeField] private BuyingMenu buyingMenu;
    [SerializeField] private AudioManager audioManager;
    
    [SerializeField] private GameObject timeLeftDisplay;
    [SerializeField] private GameObject notEnoughMessage;
    [SerializeField] private GameObject returnShipButton;
    
    [SerializeField] private float timeLeft;
    [SerializeField] private float neededTime;
    [SerializeField] private float passedTime;
    [SerializeField] private bool takingAway;

    private bool _timeIsDisplaying;

    #region Public Links
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
    public bool TimeIsDisplaying
    {
        get => _timeIsDisplaying;
        set => _timeIsDisplaying = value;
    }
    #endregion

    private void Start()
    {
        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);
        
        StartCoroutine(ResourcesTimer());
        
        timeLeftDisplay.GetComponent<TextMeshProUGUI>().text = string.Format("Корабль с ресурсами прибудет через {0:00}:{1:00}", minutes, seconds);
        
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
            StartCoroutine(ResourcesTimer());
        }
        
        if (timeLeft <= 0)
        {
            returnShipButton.SetActive(false);
        }
        else
        {
            returnShipButton.SetActive(true);
        }

        if (_timeIsDisplaying) {timeLeftDisplay.SetActive(true);}
        else {timeLeftDisplay.SetActive(false);}
    }

    public void StartShipTimer()
    {
        if (buyingMenu.TotalOrderAmount <= 5)
        {
            timeLeft += 180;
            neededTime = 180;
        }
        else if (buyingMenu.TotalOrderAmount > 5 && buyingMenu.TotalOrderAmount <= 10)
        {
            timeLeft += 360;
            neededTime = 360;
        }
        else if (buyingMenu.TotalOrderAmount > 10 && buyingMenu.TotalOrderAmount <= 20)
        {
            timeLeft += 720;
            neededTime = 720;
        }
        else if (buyingMenu.TotalOrderAmount > 30)
        {
            timeLeft += 1080;
            neededTime = 1080;
        }
        StartCoroutine(ResourcesTimer());
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

    IEnumerator ResourcesTimer()
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
            timeLeftDisplay.GetComponent<TextMeshProUGUI>().text = string.Format("Корабль с ресурсами прибудет через {0:00}:{1:00}", minutes, seconds);
        }
        takingAway = false;
    }
}
