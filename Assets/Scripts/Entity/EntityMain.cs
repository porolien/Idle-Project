using UnityEngine;

public class EntityMain : MonoBehaviour
{
    public EntityMovement Movement;
    public EntityStat Stat;
    public EntityEquipment Equipment;
    public EntityAttack Attack;
    public EntityChoice Choice;
    public EntityInfo Info;
    public EntityStateMachine StateMachine;
    public Team OwnTeam;

    private void Awake()
    {
        SendMessage("Init", this);
        Stat = new EntityStat();
        Info = new EntityInfo();
        Stat.Init(this);
    }

    public void TESTHP()
    {
        Debug.Log(Stat.Hp);
    }
}
