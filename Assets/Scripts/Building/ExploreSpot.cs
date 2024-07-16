using UnityEngine;
public class ExploreSpot : Building
{
    public override IBaseEntityState ReturnTheNextState(EntityStateMachine _entity)
    {
        return _entity.ExploreState;
    }
}
