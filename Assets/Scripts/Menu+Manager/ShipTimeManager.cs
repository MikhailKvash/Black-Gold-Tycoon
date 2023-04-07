using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private SaveManager saveManager;
    
    [SerializeField] private GameObject timeLeftDisplay;
    
    [SerializeField] private float timeLeft;
    [SerializeField] private float neededTime;
    [SerializeField] private float passedTime;
    [SerializeField] private bool takingAway;

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
    
    
    private void Start()
    {
        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);
        
        StartCoroutine(ShipTimer());
        
        timeLeftDisplay.GetComponent<TextMeshProUGUI>().text = string.Format("Корабль вернётся через {0:00}:{1:00}", minutes, seconds);
        
        //if (!string.IsNullOrEmpty(saveManager.TimeWhenGameClosed))
        //{
        //    DateTime parsingTime = DateTime.Parse(saveManager.TimeWhenGameClosed);
        //    TimeSpan passedSinceClosingTime = DateTime.Now - parsingTime;
//
        //    float passedSinceClosingShipTime = (float) passedSinceClosingTime.TotalSeconds + 0;
//
        //    if (timeLeft <= passedSinceClosingTime.TotalSeconds)
        //    {
        //        timeLeft = 0;
        //        passedTime = neededTime;
        //    }
        //    else
        //    {
        //        timeLeft -= passedSinceClosingShipTime;
        //        passedTime += passedSinceClosingShipTime;
        //    }
        //}
    }

    private void Update()
    {
        if (!takingAway && timeLeft > 0)
        {
            StartCoroutine(ShipTimer());
        }
    }

    public void StartShipTimer()
    {
        timeLeft += 90;
        neededTime = 90;
        StartCoroutine(ShipTimer());
    }//

    public void EndShipTimer()
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
