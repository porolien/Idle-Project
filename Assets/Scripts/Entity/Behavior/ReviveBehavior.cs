using UnityEngine;

public class ReviveBehavior : Behavior
{
    public ReviveBehavior(EntityChoice _entity) : base(_entity) { }

    public override void Start()
    {
        BehaviorImportance = 1;
        buildingType = "Hospital";
        needAwait = true;
    }

    public override bool Evaluate()
    {
        return entity.Main.Stat.Hp < entity.Main.Stat.MaxHp * 0.6f;
    }

    public override Vector3 Execute()
    {
        entity.Main.StateMachine.IdleState.NextEntityState = entity.Main.StateMachine.DestinationState;
        entity.NewDestination = buildingType;
        entity.Main.StateMachine.IdleState.NeedAwaitJob = needAwait;
        return entity.GiveTheDestination();
    }
}
