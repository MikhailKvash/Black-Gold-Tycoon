[System.Serializable]
public class ResourcesTimerData
{
    public float timeLeft;
    public float neededTime;
    public float passedTime;
    
    public bool takingAway;
    public bool timeIsDisplaying;

    public ResourcesTimerData(DeliverResourcesTimer resourcesTimer)
    {
        timeLeft = resourcesTimer.TimeLeft;
        neededTime = resourcesTimer.NeededTime;
        passedTime = resourcesTimer.PassedTime;

        takingAway = resourcesTimer.TakingAway;
        timeIsDisplaying = resourcesTimer.TimeIsDisplaying;
    }
}
