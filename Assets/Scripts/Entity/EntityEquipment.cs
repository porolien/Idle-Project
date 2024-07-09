using System.Collections.Generic;

public class EntityEquipment
{
    private EntityStat stat;
    private List<Equipment> equippedEquipments = new List<Equipment>();
    public List<Equipment> EquippedEquipments { get { return equippedEquipments; } }

    public void Init(EntityStat _stat)
    {
        stat = _stat;
    }

    public void EquipItem(Equipment newEquipment)
    {
        equippedEquipments.Add(newEquipment);
        stat.ApplyEquipmentBonus(newEquipment);
    }

    public void UnequipItem(Equipment equipment)
    {
        if (equippedEquipments.Contains(equipment))
        {
            equippedEquipments.Remove(equipment);
            stat.RemoveEquipmentBonus(equipment);
        }
    }
    
}
