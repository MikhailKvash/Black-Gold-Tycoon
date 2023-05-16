[System.Serializable]
public class XpRpData
{
    public float xp;
    public float rp;

    public float xpLvl;
    public float rpLvl;

    public XpRpData(XpRpManager xpRPManager)
    {
        xp = xpRPManager.Xp;
        rp = xpRPManager.Rp;
        xpLvl = xpRPManager.XpLvl;
        rpLvl = xpRPManager.RpLvl;
    }
}
