[System.Serializable]
public class ShipData
{
    public float[] position;
    public bool singleDelivery;
    public bool readyToReturnToDocks;

    public bool goingAway;
    public bool goingToLastPoint;
    public bool goingDocks;

    public ShipData(ShipMovement ship)
    {
        singleDelivery = ship.SingleDelivery;
        readyToReturnToDocks = ship.ReadyToReturnToDocks;

        goingAway = ship.GoingAway;
        goingToLastPoint = ship.GoingToLastPoint;
        goingDocks = ship.GoingDocks;
        
        position = new float[3];
        position[0] = ship.transform.position.x;
        position[1] = ship.transform.position.y;
        position[2] = ship.transform.position.z;
    }
}
