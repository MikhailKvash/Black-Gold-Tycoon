[System.Serializable]
public class ShipVillagerData
{
    public float[] position;
    public bool singleDelivery;
    public bool carryingCargo;
    public bool tookCargo;
    public bool box;

    public ShipVillagerData(ShipVillager shipVillager)
    {
        singleDelivery = shipVillager.SingleDelivery;
        carryingCargo = shipVillager.CarryingCargo;
        tookCargo = shipVillager.TookCargo;
        box = shipVillager.Box;
        
        position = new float[3];
        position[0] = shipVillager.transform.position.x;
        position[1] = shipVillager.transform.position.y;
        position[2] = shipVillager.transform.position.z;
    }
}
