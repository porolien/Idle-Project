using UnityEngine;

public class Battle : MonoBehaviour
{
    public Team EntityTeam;
    public Team EnnemyTeam;

    public Team GetOtherTeam(Team _unitTeam)
    {
        Team teamToFight = EntityTeam;
        if (_unitTeam == EntityTeam)
        {
            teamToFight = EnnemyTeam;
        }

        return teamToFight;
    }
    public GameObject SearchTheClosestEnnemy(GameObject _ownUnit, Team _otherTeam)
    {
        GameObject closestEnnemy = null;
        float distance = 1000000;
        foreach (GameObject otherUnit in _otherTeam.UnitTeam)
        {
            float actualDistance = Vector3.Distance(_ownUnit.transform.position, otherUnit.transform.position);
            if (actualDistance < distance)
            {
                distance = actualDistance;
                closestEnnemy = otherUnit;
            }
        }

        return closestEnnemy;
    }
}
