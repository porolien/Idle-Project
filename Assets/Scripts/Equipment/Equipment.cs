using UnityEngine;
using static EquipmentType;

[CreateAssetMenu(fileName = "Equipment", menuName = "NewAssets/Create a new Equipment")]
public class Equipment : ScriptableObject
{
    public string EquipmentName;
    public int HpBonus;
    public int AttackBonus;
    public int DefenseBonus;
    public int AttackSpeedBonus;
    public float AttackRangeBonus;
    public int EquipmentCost;
    public int ImportanceLevel;
    public eEquipmentType EquipmentType;
}