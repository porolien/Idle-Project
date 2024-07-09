using UnityEngine;
using System.Collections.Generic;

public class SpawnExploreUnit : MonoBehaviour
{
    public List<GameObject> ExploreSpots;
    public List<GameObject> Ennemies;

    [SerializeField]
    private List<GameObject> ExploreSpotsPrefabs;

    [SerializeField]
    private List<GameObject> EnnemiesPrefabs;

    [SerializeField]
    private int maxNumberOfUnits;

    [SerializeField]
    private int maxNumberOfEnnemySpawn;

    [SerializeField]
    private int maxNumberOfExploreSpotSpawn;

    private ExploreMain main;

    private void Init(ExploreMain _main)
    {
        _main.Spawn = this;
        main = _main;
    }

    public void SpawnUnit()
    {
        if (ExploreSpots.Count + Ennemies.Count < maxNumberOfUnits)
        {
            if (Random.Range(0, 2) == 0)
            {
                if (Ennemies.Count < maxNumberOfEnnemySpawn)
                {
                    SpawnNewUnit(Ennemies, EnnemiesPrefabs);
                }
                else
                {
                    SpawnNewUnit(ExploreSpots, ExploreSpotsPrefabs);
                }
            }
            else
            {
                if (ExploreSpots.Count < maxNumberOfExploreSpotSpawn)
                {
                    SpawnNewUnit(ExploreSpots, ExploreSpotsPrefabs);
                }
                else
                {
                    SpawnNewUnit(Ennemies, EnnemiesPrefabs);
                }
            }
        }
    }

    public void DespawnAllUnits()
    {
        ClearUnits(ExploreSpots);
        ClearUnits(Ennemies);
    }

    private void ClearUnits(List<GameObject> _listToClear)
    {
        for (int i = _listToClear.Count - 1; i >= 0; i--)
        {
            GameObject objectToClear = _listToClear[i];
            _listToClear.RemoveAt(i);
            Destroy(objectToClear);
            // ou bien créer un pool
        }
    }

    private void SpawnNewUnit(List<GameObject> _listToAdd, List<GameObject> _listToSearch)
    {
        GameObject newUnit = Instantiate(_listToSearch[Random.Range(0, _listToSearch.Count)], main.Zone.GetRandomPointInPolygon(), Quaternion.identity);
        _listToAdd.Add(newUnit);
    }
}
