using System.Collections.Generic;
using static EquipmentType;

public class Shop : Building
{
    // Besoin d'une liste d'item
    public TownMain town;
    public int moneySold;
    public List<Equipment> equipments;
    public eEquipmentType EquipmentType;

    private void SoldItem()
    {
        town.GetMoney(moneySold);
    }
}
