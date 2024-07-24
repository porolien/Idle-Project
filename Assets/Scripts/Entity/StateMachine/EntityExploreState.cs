using UnityEngine;

public class EntityExploreState : IBaseEntityState
{
    public ExploreMain ExploreMain;
    private EntityStateMachine stateMachine;
    private GameObject unitToGo;
    public override void OnEnter(EntityStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
        if (ExploreMain.UnitNoNull())
        {
            ExploreMain.Spawn.SpawnUnit();
            ExploreMain.Spawn.SpawnUnit();
            ExploreMain.Spawn.SpawnUnit();
        }

        unitToGo = ExploreMain.FindTheClosestUnit(stateMachine.transform.position);
        stateMachine.Main.Movement.NewDestination(unitToGo.transform.position);
    }

    public override void Update()
    {
        if (stateMachine.Main.Movement.IsObjectifReached())
        {
            unitToGo.GetComponent<ExploreUnit>().UnitEffect(stateMachine.Main.OwnTeam);
        }
        else
        {
            stateMachine.Main.Movement.GoToTheDestination();
        }
    }

    public override void OnExit()
    {

    }
}
