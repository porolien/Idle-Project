using UnityEngine;

public class RestBehavior : Behavior
{
    public RestBehavior(EntityChoice _entity) : base(_entity) { }

    public override void Start()
    {
        BehaviorImportance = 2;
        buildingType = "Hotel";
    }

    public override bool Evaluate()
    {
        return entity.Main.Stat.Hp < entity.Main.Stat.MaxHp;
    }

    /// <summary>
    /// Execute sera executé via un update
    /// </summary>
    public override Vector3 Execute()
    {
        entity.NewDestination = buildingType;
        return entity.GiveTheDestination();
    }
}
