using System.Collections.Generic;
using UnityEngine;

public class EntityChoice : MonoBehaviour
{
    public string NewDestination;
    public Vector3 Destination;
    public EntityMain Main;

    private List<Behavior> behaviors = new List<Behavior>();

    private void Init(EntityMain _main)
    {
        Main = _main;
        _main.Choice = this;
    }

    /// <summary>
    /// Faire le choix entre toutes les destinations
    /// </summary>
    /// <returns></returns>
    public Vector3 ChooseADestination()
    {
        if (behaviors.Count == 0)
        {
            AddBehaviors();
        }

        return ChooseTheMostImportantDestination();
    }

    public Vector3 GiveTheDestination()
    {
        int random = Random.Range(0, ManagerMain.Instance.Building.BuildingsByType[NewDestination].Count);
        Destination = ManagerMain.Instance.Building.BuildingsByType[NewDestination][random].position;
        foreach (Building _building in ManagerMain.Instance.Building.Buildings)
        {
            if (_building.EnterTransform == ManagerMain.Instance.Building.BuildingsByType[NewDestination][random])
            {
                Main.StateMachine.IdleState.BuildingJob = _building;
            }
        }

        return Destination;
    }

    private Vector3 ChooseTheMostImportantDestination()
    {
        foreach (Behavior behavior in behaviors)
        {
            if (behavior.Evaluate())
            {
                return behavior.Execute();
            }
        }

        return Destination;
    }

    /// <summary>
    /// Ajoute tout les comportements et va les trier en fonction de leurs importance
    /// </summary>
    private void AddBehaviors()
    {
        BuyBehavior buy = new BuyBehavior(this);
        behaviors.Add(buy);

        ExplorationBehavior explore = new ExplorationBehavior(this);
        behaviors.Add(explore);

        RestBehavior rest = new RestBehavior(this);
        behaviors.Add(rest);

        ReviveBehavior revive = new ReviveBehavior(this);
        behaviors.Add(revive);

        foreach (Behavior behavior in behaviors)
        {
            behavior.Start();
        }

        behaviors.Sort(new BehaviorComparer());
    }
}
