[System.Serializable]
public class TimeManagerData
{
    public float timeLeft;
    public float neededTime;
    public float passedTime;
    public bool takingAway;

    public TimeManagerData(TimeManager timeManager)
    {
        timeLeft = timeManager.TimeLeft;
        neededTime = timeManager.NeededTime;
        passedTime = timeManager.PassedTime;
        takingAway = timeManager.TakingAway;
    }
}