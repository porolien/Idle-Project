using UnityEngine;

public class ExplorationBehavior : Behavior
{
    public ExplorationBehavior(EntityChoice _entity) : base(_entity) { }

    public override void Start()
    {
        BehaviorImportance = 4;
        buildingType = "ExploreSpot";
    }

    public override bool Evaluate()
    {
        return true;
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
