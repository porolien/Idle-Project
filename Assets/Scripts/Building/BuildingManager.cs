using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public Dictionary<string, List<Transform>> BuildingsByType = new Dictionary<string, List<Transform>>();
    public List<Building> Buildings = new List<Building>();
    public List<Behavior> Behaviors = new List<Behavior>();

    private void GetAllNavigationPoint()
    {
        foreach (Building building in Buildings)
        {
            Transform _building = building.EnterTransform;
            if (!BuildingsByType.ContainsKey(_building.tag))
            {
                BuildingsByType[_building.tag] = new List<Transform>();
            }

            BuildingsByType[_building.tag].Add(_building);
        }
    }

    private void Init(ManagerMain _main)
    {
        _main.Building = this;
        GetAllNavigationPoint();

    }
}
