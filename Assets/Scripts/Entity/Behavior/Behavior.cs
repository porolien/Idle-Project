using UnityEngine;
public abstract class Behavior
{
    public int BehaviorImportance;
    protected EntityChoice entity;
    protected string buildingType;
    protected bool needAwait;

    public Behavior(EntityChoice _entity)
    {
        entity = _entity;
    }
    public abstract void Start();
    public abstract bool Evaluate();
    public abstract Vector3 Execute();
}