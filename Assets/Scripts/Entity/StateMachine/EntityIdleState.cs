using System.Threading.Tasks;

public class EntityIdleState : IBaseEntityState
{
    public IBaseEntityState NextEntityState;
    public Building BuildingJob;
    public bool NeedAwaitJob;
    private EntityStateMachine stateMachine;

    public override void OnEnter(EntityStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
        if (NeedAwaitJob)
        {
            OnWaitJob();
        }
        else
        {
            OnJob();
        }
    }

    public override void Update()
    {

    }

    public override void OnExit()
    {

    }
    
    /// <summary>
    /// Va ce lancer lorsque le pnj aura fini son job
    /// </summary>
    private async void OnJob()
    {
        if (BuildingJob != null)
        {
            await Task.Delay(BuildingJob.DurationJob);
        }

        OnCompleted();
    }

    private async void OnWaitJob()
    {
        await BuildingJob.BuildingTask(stateMachine.Main);
        OnCompleted();
    }

    private void OnCompleted()
    {
        if (BuildingJob != null)
        {
            NextEntityState = BuildingJob.ReturnTheNextState(stateMachine);
        }
        
        if (NextEntityState == stateMachine.DestinationState)
        {
            stateMachine.DestinationState.Destination = stateMachine.Main.Choice.ChooseADestination();
        }

        stateMachine.Transition(NextEntityState);
    }

}
