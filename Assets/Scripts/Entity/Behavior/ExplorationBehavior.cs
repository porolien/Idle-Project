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
        entity.Main.StateMachine.ExploreState.ExploreMain = ManagerMain.Instance.Explores[0];
        entity.Main.StateMachine.IdleState.NextEntityState = entity.Main.StateMachine.DestinationState;
        entity.NewDestination = buildingType;
        entity.Main.StateMachine.IdleState.NeedAwaitJob = needAwait;
        return entity.GiveTheDestination();
    }
}
