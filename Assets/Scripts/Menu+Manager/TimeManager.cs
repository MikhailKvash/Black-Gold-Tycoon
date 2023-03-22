using System.Collections;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private ShipMovement shipMovement;
    
    [SerializeField] private GameObject timeLeftDisplay;
    [SerializeField] private int timeLeft;
    [SerializeField] private float neededTime;
    [SerializeField] private float passedTime;
    [SerializeField] private bool takingAway;

    public int TimeLeft
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
        timeLeftDisplay.GetComponent<TextMeshProUGUI>().text = "Корабль вернётся через 00:00";
    }

    private void Update()
    {
        if (takingAway == false && timeLeft > 0)
        {
            StartCoroutine(ShipTimer());
        }

        //if (timeLeft <= 0)
        //{
        //    StopCoroutine(ShipTimer());
        //}
    }

    public void StartShipTimer()
    {
        timeLeft += 90;
        neededTime = 90;
        StartCoroutine(ShipTimer());
    }

    public void EndShipTimer()
    {
        timeLeft = 0;
        passedTime = neededTime;
    }

    //public void StartTimerAfterLoad()
    //{
    //    StartCoroutine(ShipTimer());
    //}

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
