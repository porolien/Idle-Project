using static EquipmentType;
using UnityEngine;

public class BuyBehavior : Behavior
{
    public BuyBehavior(EntityChoice _entity) : base(_entity) { }

    private string shopTag;
    private Equipment equipementEvaluate;

    public override void Start()
    {
        BehaviorImportance = 3;
        buildingType = "Shop";
    }

    /// <summary>
    /// Permet d'avoir les prérequis du comportement
    /// </summary>
    /// <returns></returns>
    public override bool Evaluate()
    {
        bool pnjWillBuySomething = false;
        if (entity.Main.Equipment.EquippedEquipments.Count != 0)
        {
            int importanceEquipment = 0;
            foreach (Equipment equipement in entity.Main.Equipment.EquippedEquipments)
            {
                if (!pnjWillBuySomething || equipement.ImportanceLevel < importanceEquipment)
                {
                    if (SearchShop(equipement))
                    {
                        equipementEvaluate = equipement;
                        importanceEquipment = equipement.ImportanceLevel;
                        pnjWillBuySomething = true;
                        FindShopType(equipement.EquipmentType);
                    }
                }
            }
        }

        return pnjWillBuySomething;
    }

    /// <summary>
    /// Sera executé si c'est le bon comportement
    /// </summary>
    public override Vector3 Execute()
    {
        entity.NewDestination = buildingType;
        return entity.GiveTheDestination();
    }
    
    /// <summary>
    /// Va rechercher le bon shop & si le pnj à un intérêt à acheter un équipement
    /// </summary>
    /// <param name="_equipement"></param>
    /// <returns></returns>
    private bool SearchShop(Equipment _equipement)
    {
        foreach (Building building in entity.Main.Info.Town.Buildings)
        {
            if (building.gameObject.tag == shopTag)
            {
                Shop shop = building.GetComponent<Shop>();
                if (shop.EquipmentType == _equipement.EquipmentType)
                {
                    foreach (Equipment _equipmentInShop in shop.equipments)
                    {
                        if (_equipmentInShop.ImportanceLevel > _equipement.ImportanceLevel && _equipmentInShop.EquipmentCost < entity.Main.Info.Money)
                        {
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }

    private void FindShopType(eEquipmentType _type)
    {
        switch (_type)
        {
            case eEquipmentType.Weapon:
                buildingType = "WeaponShop";
                break;
            case eEquipmentType.Armor:
                buildingType = "ArmorShop";
                break;
            case eEquipmentType.Accessory:
                buildingType = "AccessoryShop";
                break;
        }
    }
}
