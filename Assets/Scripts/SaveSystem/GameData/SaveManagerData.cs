[System.Serializable]
public class SaveManagerData
{
    public string timeWhenGameClosed;

    public SaveManagerData(SaveManager saveManager)
    {
        timeWhenGameClosed = saveManager.TimeWhenGameClosed;
    }
}
