using UnityEngine;

public class EntityStateMachine : MonoBehaviour
{
    public IBaseEntityState CurrentState;
    public EntityIdleState IdleState;
    public EntityDestinationState DestinationState;
    public EntityExploreState ExploreState;
    public EntityBattleState BattleState;
    public EntityDeadState DeadState;
    public EntityMain Main;

    private void Init(EntityMain _main)
    {
        Main = _main;
        _main.StateMachine = this;
        IdleState = new EntityIdleState();
        DestinationState = new EntityDestinationState();
        ExploreState = new EntityExploreState();
        BattleState = new EntityBattleState();
        DeadState = new EntityDeadState();
    }

    private void Start()
    {
        Transition(IdleState);
    }

    void FixedUpdate()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }

    public void Transition(IBaseEntityState _theNewState)
    {
        if (CurrentState != null)
        {
            CurrentState.OnExit();
        }

        CurrentState = _theNewState;
        CurrentState.OnEnter(this);
    }
}
