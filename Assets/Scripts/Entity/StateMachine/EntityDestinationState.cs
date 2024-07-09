using UnityEngine;

public class EntityDestinationState : IBaseEntityState
{
    public Vector3 Destination;
    private EntityStateMachine stateMachine;
    public override void OnEnter(EntityStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
        stateMachine.Main.Movement.NewDestination(Destination);
    }

    public override void Update()
    {
        if (stateMachine.Main.Movement.IsObjectifReached())
        {
            //Ajouter un moyen de changer la destination
            if (stateMachine.Main.Choice.NewDestination == "ExploreSpot")
            {
                stateMachine.Transition(stateMachine.ExploreState);
            }
            else
            {
                stateMachine.Transition(stateMachine.IdleState);
            }
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
