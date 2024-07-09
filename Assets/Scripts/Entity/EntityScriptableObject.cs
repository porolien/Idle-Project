using UnityEngine;

[CreateAssetMenu(fileName = "Entity", menuName = "NewAssets/Create a new Entity")]
public class EntityScriptableObject : ScriptableObject
{
    private string entityName;
    private int hp;
    private int attack;
    private int defense;
    private int attackSpeed;
    private float attackRange;
    
    public void Constructor(int _hp, int _attack, int _defense, int _attackSpeed, float _attackRange)
    {
        _hp += hp;
        _attack += attack;
        _defense += defense;
        _attackSpeed += attackSpeed;
        _attackRange += attackRange;
    }
}
