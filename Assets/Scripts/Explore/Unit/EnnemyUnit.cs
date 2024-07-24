using UnityEngine;

public class EnnemyUnit : ExploreUnit
{
    public override void UnitEffect(Team _entityTeam)
    {
        Battle newBattle = new Battle();
        _entityTeam.ActualBattle = newBattle;
        newBattle.EnnemyTeam = GetComponent<Team>();
        newBattle.EntityTeam = _entityTeam;
        Debug.Log("EnnemyUnit");
    }
}
