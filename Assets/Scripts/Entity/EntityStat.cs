public class EntityStat
{
    public EntityScriptableObject EntityObject;

    private int maxHp;
    public int MaxHp { get { return maxHp; } set { maxHp = value; } }

    private int hp;
    public int Hp { get { return hp; } set { hp = value; } }

    private int attack;
    public int Attack { get { return attack; } set { attack = value; } }

    private int defense;
    public int Defense { get { return defense; } set { defense = value; } }

    private int attackSpeed;
    public int AttackSpeed { get { return attackSpeed; } set { attackSpeed = value; } }

    private float attackRange;
    public float AttackRange { get { return attackRange; } set { attackRange = value; } }

    public void Init(EntityMain _main)
    {
        _main.Equipment = new EntityEquipment();
        _main.Equipment.Init(this);
        Hp = 3;
        MaxHp = 10;
        if (EntityObject != null)
        {
            EntityObject.Constructor(MaxHp, Attack, Defense, AttackSpeed, AttackRange);
        }
    }

    //Méthode pour appliquer les bonus d'équipement
    public void ApplyEquipmentBonus(Equipment equipment)
    {
        MaxHp += equipment.HpBonus;
        Attack += equipment.AttackBonus;
        Defense += equipment.DefenseBonus;
        AttackSpeed += equipment.AttackSpeedBonus;
        AttackRange += equipment.AttackRangeBonus;
    }

    // Méthode pour retirer les bonus d'équipement
    public void RemoveEquipmentBonus(Equipment equipment)
    {
        MaxHp -= equipment.HpBonus;
        Attack -= equipment.AttackBonus;
        Defense -= equipment.DefenseBonus;
        AttackSpeed -= equipment.AttackSpeedBonus;
        AttackRange -= equipment.AttackRangeBonus;
    }
}
