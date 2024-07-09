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
}
