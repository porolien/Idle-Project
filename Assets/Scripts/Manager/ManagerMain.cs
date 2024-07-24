using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMain : MonoBehaviour
{
    private static ManagerMain _instance = null;

    public static ManagerMain Instance => _instance;

    public BuildingManager Building;
    public List<ExploreMain> Explores;

    public BattleManager Battle;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        SendMessage("Init", this);
    }
}
