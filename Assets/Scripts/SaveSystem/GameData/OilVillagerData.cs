[System.Serializable]
public partial class OilVillagerData
{
    public float carryingOil;
    public float[] position;
    public int speed;
    public int capacity;
    public bool takeOilOnce;
    public bool dropOilOnce;
    public bool box;

    public OilVillagerData(OilVillager oilVillager)
    {
        carryingOil = oilVillager.CarryingOil;
        speed = oilVillager.Speed;
        capacity = oilVillager.Capacity;
        takeOilOnce = oilVillager.TakeOilOnce;
        dropOilOnce = oilVillager.DropOilOnce;
        box = oilVillager.Box;
        
        position = new float[3];
        position[0] = oilVillager.transform.position.x;
        position[1] = oilVillager.transform.position.y;
        position[2] = oilVillager.transform.position.z;
    }
}
