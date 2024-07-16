using System;
using Unity.VisualScripting;
using UnityEngine;

public class ExploreMain : MonoBehaviour
{
    public SpawnExploreUnit Spawn;
    public int NumberOfTeam;
    public int DepthLevel;
    public ExploreZone Zone;

    private void Awake()
    {
        SendMessage("Init", this);
        TeamEnter();
    }

    public void TeamEnter()
    {
        NumberOfTeam++;
        if(NumberOfTeam == 1)
        {
            Spawn.InvokeRepeating("SpawnUnit", 2, 10);
        }
    }

    public void TeamLeft()
    {
        NumberOfTeam--;
    }

    public bool UnitNoNull()
    {
        return Spawn.ExploreSpots.Count + Spawn.Ennemies.Count == 0;
    }

    public GameObject FindTheClosestUnit(Vector3 _entityPosition)
    {
        float distance = 1000000000;
        GameObject closestUnit = null;
        for (int i = 0; i < Spawn.Ennemies.Count + Spawn.ExploreSpots.Count; i++)
        {
            if (i <= Spawn.Ennemies.Count - 1)
            {
                float distanceUnitEntity = GetDistance(Spawn.Ennemies[i].transform.position, _entityPosition);
                if (distanceUnitEntity < distance)
                {
                    distance = distanceUnitEntity;
                    closestUnit = Spawn.Ennemies[i];
                }
            }
            else
            {
                float distanceUnitEntity = GetDistance(Spawn.ExploreSpots[i - Spawn.Ennemies.Count].transform.position, _entityPosition);
                if (distanceUnitEntity < distance)
                {
                    distance = distanceUnitEntity;
                    closestUnit = Spawn.ExploreSpots[i - Spawn.Ennemies.Count];
                }
            }
        }

        return closestUnit;
    }

    private float GetDistance(Vector3 _unitPosition, Vector3 _entityPosition)
    {
        return Vector3.Distance(_unitPosition, _entityPosition);
    }

}
