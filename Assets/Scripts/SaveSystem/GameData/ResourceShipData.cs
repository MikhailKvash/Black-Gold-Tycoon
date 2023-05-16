[System.Serializable]
public class ResourceShipData
{
    public float[] position;
    public bool singleDelivery;

    public bool goingAway;
    public bool goingDocks;
    public bool isWaiting;

    public ResourceShipData(ResourceShip resourceShip)
    {
        singleDelivery = resourceShip.SingleDelivery;

        goingAway = resourceShip.GoingAway;
        goingDocks = resourceShip.GoingDocks;
        isWaiting = resourceShip.IsWaiting;
        
        position = new float[3];
        position[0] = resourceShip.transform.position.x;
        position[1] = resourceShip.transform.position.y;
        position[2] = resourceShip.transform.position.z;
    }
}
