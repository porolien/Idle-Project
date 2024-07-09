using UnityEngine;

[CreateAssetMenu(fileName = "Ennemy", menuName = "NewAssets/Create a new Ennemy")]
public class EnnemyScriptableObject : ScriptableObject
{
    private string ennemyName;
    private int hp;
    private int attack;
    private int defense;
    private int attackSpeed;
    private float attackRange;

    public void Constructor(string _name, int _hp, int _attack, int _defense, int _attackSpeed, float _attackRange)
    {
        _name = ennemyName;
        _hp += hp;
        _attack += attack;
        _defense += defense;
        _attackSpeed += attackSpeed;
        _attackRange += attackRange;
    }
}
