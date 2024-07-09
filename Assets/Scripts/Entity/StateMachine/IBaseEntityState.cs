public abstract class IBaseEntityState
{
    public abstract void OnEnter(EntityStateMachine stateMachine);

    public abstract void Update();

    public abstract void OnExit();
}