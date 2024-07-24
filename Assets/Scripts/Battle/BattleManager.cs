using System;

public class BattleManager
{
    public Team EnnemyTeam;
    public Team EntityTeam;
    private event Action onAttack;

    public void StartBattle()
    {

    }

    public void EndBattle()
    {

    }

    public void Attack()
    {
        onAttack?.Invoke();
    }

}
