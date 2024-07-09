public class EnnemyStat
{
    public EnnemyScriptableObject EnnemyObject;

    private string ennemyName;
    public string EnnemyName { get { return ennemyName; } set { ennemyName = value; } }

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

    public void Init()
    {
        if (EnnemyObject != null)
        {
            EnnemyObject.Constructor(EnnemyName, MaxHp, Attack, Defense, AttackSpeed, AttackRange);
        }
    }
}
