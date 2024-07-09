public class EntityBattleState : IBaseEntityState
{
    private EntityStateMachine stateMachine;
    public override void OnEnter(EntityStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public override void Update()
    {

    }

    public override void OnExit()
    {

    }
}
